using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Diagnostics;

namespace Motion_Designer
{

	static class CCommandTx
	{
		private const byte STX = 0x02;
		private const byte ETX = 0x03;
        public const byte ACK = 0x06;
		private const byte NAK = 0x15;

		public const int REQ_LEN = 64;
		private const int REQ_LOG_NUM = 30;

		private const int TAD_LOG_WK_SIZE = 56;
		private const int TAD_LOG_WK_NUM = LogWork.KindNum;

		private const int TAD_LOG_FB_SIZE = 16;
		private const int TAD_LOG_FB_NUM = LogWork.MonNum;

		private const int RES_LOG_WK_NUM = REQ_LOG_NUM;
		private const int RES_LOG_WK_LEN = REQ_LOG_NUM * TAD_LOG_WK_SIZE + 8;

		private const int RES_LOG_FB_NUM = REQ_LOG_NUM;
		private const int RES_LOG_FB_LEN = REQ_LOG_NUM * TAD_LOG_FB_SIZE + 8;

		private const int FRQ_SWEEP_LEN = 500;
		private const int RES_FRQ_LEN = FRQ_SWEEP_LEN * 4 + 8;

 		private const int RES_SVALL_LEN = 1032;
		private const int RES_SVRD_LEN = 252;
		private const int RES_SVWR_LEN = 252;
		private const int SVMON_NUM = RES_SVRD_LEN / 4;

		static private byte[] UsbTxBuf = new byte[64];
	
		static private byte[] UsbRxBuf = new byte[16384];
		static private byte[] UsbRsBuf = new byte[16384];

		static public int MonitorNum
		{
			get { return SVMON_NUM; }
		}

		static public int RequestLogNum
		{
			get { return RES_LOG_WK_NUM; }
		}

		static public bool ReadLogData(ref int[] data, ref int log_num, bool fft_on)
		{
			UsbTxBuf[0] = STX;
			UsbTxBuf[1] = Convert.ToByte('l');
			UsbTxBuf[2] = 0;	//null
			UsbTxBuf[3] = 0;	//null

			if (!fft_on) { UsbTxBuf[2] = 1; }

			byte sum = new byte();

			sum = 0;

			for (int i = 1; i < 62; i++)
			{
				if (i >= 4) { UsbTxBuf[i] = 0; }
				sum += UsbTxBuf[i];
			}

			UsbTxBuf[62] = ETX;
			UsbTxBuf[63] = sum;

			if (!CUsb.WriteFile(UsbTxBuf, REQ_LEN))
			{
				return false;
			}

			bool rx_2x = new bool();

			int rx_num = new int();
			int rs_num = new int();

			int res_log_len = new int();
			int tad_log_num = new int();
			int tad_log_size = new int();

			if (fft_on)
			{
				res_log_len = RES_LOG_WK_LEN;
				tad_log_num = TAD_LOG_WK_NUM;
				tad_log_size = TAD_LOG_WK_SIZE;
			}
			else
			{
				res_log_len = RES_LOG_FB_LEN;
				tad_log_num = TAD_LOG_FB_NUM;
				tad_log_size = TAD_LOG_FB_SIZE;
			}

			if (!CUsb.ReadFile(UsbRxBuf, res_log_len, ref rx_num))
			{
				//SerialPortクラスは何故かUSBデータが正常に通信しても、バッファー更新されない時がある。

				if (!CUsb.WriteFile(UsbTxBuf, REQ_LEN))
				{
					return false;		//2回連続はエラー
				}

				if (!CUsb.ReadFile(UsbRsBuf, res_log_len, ref rs_num))
				{
					return false;		//2回連続はエラー
				}
				else
				{
					if (rs_num >= res_log_len)
					{
						for (int i = 0; i < rs_num; i++)
						{
							UsbRxBuf[i + rx_num] = UsbRsBuf[i];
						}

						rx_2x = true;
					}
					else
					{
						return false;
					}
				}
			}

			if (UsbRxBuf[0] != ACK) { return false; }

			sum = 0;

			for (int i = 1; i < res_log_len - 2; i++)
			{
				sum += UsbRxBuf[i];
			}

			if (sum != UsbRxBuf[res_log_len - 1]) { return false; }

			log_num = UsbRxBuf[2];
			log_num |= (int)((UsbRxBuf[3] << 8) & 0xFF00);

			short s = new short();

			int buf_ptr = new int();

			unchecked
			{
				//20170711 update
				//ログ取得の最後（ログ30個未満=リングバッファ最終）の場合にログ個数が1個少ない（抜ける）件を修正。
				//本体ソフトを修正するのが正しいがDrive側で修正しても問題無い。
				//但し、本体側が正しい処理になった場合は注意が必要。バージョン＋形式で管理する必要がある。
				if (log_num < REQ_LOG_NUM)
				{
					log_num += 1;
				}

				for (int i = 0, j = 0, k = 0; i < log_num; i++, j += tad_log_num, k += tad_log_size)
				{
					//位置
					data[j] = UsbRxBuf[k + 4];
					data[j] |= (int)((UsbRxBuf[k + 5] << 8) & 0x0000FF00);
					data[j] |= (int)((UsbRxBuf[k + 6] << 16) & 0x00FF0000);
					data[j] |= (int)((UsbRxBuf[k + 7] << 24) & 0xFF000000);

					//速度
					s = UsbRxBuf[k + 8];
					s |= (short)((UsbRxBuf[k + 9] << 8) & 0xFF00);
					data[j + 1] = (int)s;

					//電流
					s = UsbRxBuf[k + 10];
					s |= (short)((UsbRxBuf[k + 11] << 8) & 0xFF00);
					data[j + 2] = (int)s;

					//ステータス1
					data[j + 3] = UsbRxBuf[k + 12];
					data[j + 3] |= (int)((UsbRxBuf[k + 13] << 8) & 0x0000FF00);

					//パラメタ1
					s = UsbRxBuf[k + 14];
					s |= (short)((UsbRxBuf[k + 15] << 8) & 0xFF00);
					data[j + 4] = (int)s;

					//パラメタ2
					s = UsbRxBuf[k + 16];
					s |= (short)((UsbRxBuf[k + 17] << 8) & 0xFF00);
					data[j + 5] = (int)s;

					//パラメタ3
					s = UsbRxBuf[k + 18];
					s |= (short)((UsbRxBuf[k + 19] << 8) & 0xFF00);
					data[j + 6] = (int)s;

					if (fft_on)
					{
						//FFTデータ
						for (int l = 0, m = 20; l < 20; l++, m += 2)
						{
							data[j + 7 + l] = UsbRxBuf[k + m];
							data[j + 7 + l] |= (int)((UsbRxBuf[k + m + 1] << 8) & 0x0000FF00);
						}
					}

					buf_ptr = j + tad_log_num;
				}
			}

			if (rx_2x)
			{

				if (UsbRxBuf[0 + res_log_len] != ACK) { return false; }

				sum = 0;

				for (int i = 1; i < res_log_len - 2; i++)
				{
					sum += UsbRxBuf[i + res_log_len];
				}

				if (sum != UsbRxBuf[res_log_len - 1 + res_log_len]) { return false; }

				int log_num2 = new int();

				log_num2 = UsbRxBuf[2 + res_log_len];
				log_num2 |= (int)((UsbRxBuf[3 + res_log_len] << 8) & 0xFF00);

				unchecked
				{
					for (int i = 0, j = buf_ptr, k = res_log_len; i < log_num2; i++, j += tad_log_num, k +=  tad_log_size)
					{
						//位置
						data[j] = UsbRxBuf[k + 4];
						data[j] |= (int)((UsbRxBuf[k + 5] << 8) & 0x0000FF00);
						data[j] |= (int)((UsbRxBuf[k + 6] << 16) & 0x00FF0000);
						data[j] |= (int)((UsbRxBuf[k + 7] << 24) & 0xFF000000);

						//速度
						s = UsbRxBuf[k + 8];
						s |= (short)((UsbRxBuf[k + 9] << 8) & 0xFF00);
						data[j + 1] = (int)s;

						//電流
						s = UsbRxBuf[k + 10];
						s |= (short)((UsbRxBuf[k + 11] << 8) & 0xFF00);
						data[j + 2] = (int)s;

						//ステータス1
						data[j + 3] = UsbRxBuf[k + 12];
						data[j + 3] |= (int)((UsbRxBuf[k + 13] << 8) & 0x0000FF00);

						//パラメタ1
						s = UsbRxBuf[k + 14];
						s |= (short)((UsbRxBuf[k + 15] << 8) & 0xFF00);
						data[j + 4] = (int)s;

						//パラメタ2
						s = UsbRxBuf[k + 16];
						s |= (short)((UsbRxBuf[k + 17] << 8) & 0xFF00);
						data[j + 5] = (int)s;

						//パラメタ3
						s = UsbRxBuf[k + 18];
						s |= (short)((UsbRxBuf[k + 19] << 8) & 0xFF00);
						data[j + 6] = (int)s;

						if (fft_on)
						{
							//FFTデータ
							for (int l = 0, m = 20; l < 20; l++, m += 2)
							{
								data[j + 7 + l] = UsbRxBuf[k + m];
								data[j + 7 + l] |= (int)((UsbRxBuf[k + m + 1] << 8) & 0x0000FF00);
							}
						}
					}
				}

				log_num = log_num + log_num2;
			}

			return true;

		}

		static public bool ReadFrequecySweepData(byte cmd, int type, int page, ref float[] data)
		{
			UsbTxBuf[0] = STX;
			UsbTxBuf[1] = cmd;
			UsbTxBuf[2] = (byte)type;
			UsbTxBuf[3] = (byte)page;

			byte sum = new byte();

			for (int i = 1; i < 62; i++)
			{
				if (i >= 4) { UsbTxBuf[i] = 0; }
				sum += UsbTxBuf[i];
			}

			UsbTxBuf[62] = ETX;
			UsbTxBuf[63] = sum;

			if (!CUsb.WriteFile(UsbTxBuf, REQ_LEN)) { return false; }

			if (!CheckUsbRead(RES_FRQ_LEN)) { return false; }

			byte[] byte_arr = new byte[4];

			unchecked
			{
				for (int i = 0, j = 0; i < FRQ_SWEEP_LEN; i++, j += 4)
				{
					byte_arr[0] = UsbRxBuf[j + 4];
					byte_arr[1] = UsbRxBuf[j + 5];
					byte_arr[2] = UsbRxBuf[j + 6];
					byte_arr[3] = UsbRxBuf[j + 7];

					data[i] = BitConverter.ToSingle(byte_arr, 0);

				}
			}

			return true;

		}

		static public bool ReadSvNetAll(int page, ref int[] data)
		{
			UsbTxBuf[0] = STX;
			UsbTxBuf[1] = Convert.ToByte('s');
			UsbTxBuf[2] = (byte)page;	//buffer no
			UsbTxBuf[3] = 0;			//null

			byte sum = new byte();

			for (int i = 1; i < 62; i++)
			{
				if (i >= 4) { UsbTxBuf[i] = 0; }
				sum += UsbTxBuf[i];
			}

			UsbTxBuf[62] = ETX;
			UsbTxBuf[63] = sum;

			if (!CUsb.WriteFile(UsbTxBuf, REQ_LEN)) { return false; }

			if (!CheckUsbRead(RES_SVALL_LEN)) { return false; }

			unchecked
			{
				for (int i = 0, j = 0; i < 256; i++, j += 4)
				{
					data[i] = UsbRxBuf[j + 4];
					data[i] |= (int)((UsbRxBuf[j + 5] << 8) & 0x0000FF00);
					data[i] |= (int)((UsbRxBuf[j + 6] << 16) & 0x00FF0000);
					data[i] |= (int)((UsbRxBuf[j + 7] << 24) & 0xFF000000);
				}
			}

			return true;

		}

		static public bool ReadRam(int addr, byte type, ref byte[] value)
		{
			UsbTxBuf[0] = STX;
			UsbTxBuf[1] = Convert.ToByte('a');
			UsbTxBuf[2] = 0;	//null
			UsbTxBuf[3] = 0;	//null

			UsbTxBuf[4] = (byte)( addr        & 0xFF);
			UsbTxBuf[5] = (byte)((addr >>  8) & 0xFF);
			UsbTxBuf[6] = (byte)((addr >> 16) & 0xFF);
			UsbTxBuf[7] = (byte)((addr >> 24) & 0xFF);

			UsbTxBuf[8] = type;

			byte sum = new byte();

			for (int i = 1; i < 62; i++)
			{
				if (i >= 9) { UsbTxBuf[i] = 0; }
				sum += UsbTxBuf[i];
			}

			UsbTxBuf[62] = ETX;
			UsbTxBuf[63] = sum;

			if (!CUsb.WriteFile(UsbTxBuf, REQ_LEN)) { return false; }

			if (!CheckUsbRead(RES_SVRD_LEN)) { return false; }

			for (int i = 0; i < 8; i++)
			{
				value[i] = UsbRxBuf[4 + i];
				
			}

			return true;

		}

		static public bool WriteRam(int addr, byte type, byte[] value, int len)
		{
			UsbTxBuf[0] = STX;
			UsbTxBuf[1] = Convert.ToByte('b');
			UsbTxBuf[2] = 0;	//null
			UsbTxBuf[3] = 0;	//null

			UsbTxBuf[4] = (byte)( addr        & 0xFF);
			UsbTxBuf[5] = (byte)((addr >>  8) & 0xFF);
			UsbTxBuf[6] = (byte)((addr >> 16) & 0xFF);
			UsbTxBuf[7] = (byte)((addr >> 24) & 0xFF);

			UsbTxBuf[8] = type;

			for (int i = 0; i < len; i++)
			{
				UsbTxBuf[9 + i] = value[i];
			}

			byte sum = new byte();

			for (int i = 1; i < 62; i++)
			{
				if (i >= 9 + len) { UsbTxBuf[i] = 0; }
				sum += UsbTxBuf[i];
			}

			UsbTxBuf[62] = ETX;
			UsbTxBuf[63] = sum;

			if (!CUsb.WriteFile(UsbTxBuf, REQ_LEN)) { return false; }

			if (!CheckUsbRead(RES_SVWR_LEN)) { return false; }

			return true;

		}

		static public bool ReadSvNet(int id, ref int data)
		{
			UsbTxBuf[0] = STX;
			UsbTxBuf[1] = Convert.ToByte('r');
			UsbTxBuf[2] = 0;	//null
			UsbTxBuf[3] = 0;	//null

			UsbTxBuf[4] = (byte)(id & 0xFF);
			UsbTxBuf[5] = (byte)((id >> 8) & 0xFF);
			UsbTxBuf[6] = (byte)((id >> 16) & 0xFF);
			UsbTxBuf[7] = (byte)((id >> 24) & 0xFF);

			byte sum = new byte();

			for (int i = 1; i < 62; i++)
			{
				if (i >= 8) { UsbTxBuf[i] = 0; }
				sum += UsbTxBuf[i];
			}

			UsbTxBuf[62] = ETX;
			UsbTxBuf[63] = sum;

			if (!CUsb.WriteFile(UsbTxBuf, REQ_LEN)) { return false; }

			if (!CheckUsbRead(RES_SVRD_LEN)) { return false; }

			unchecked
			{
				data = UsbRxBuf[4];
				data |= (int)((UsbRxBuf[5] << 8) & 0x0000FF00);
				data |= (int)((UsbRxBuf[6] << 16) & 0x00FF0000);
				data |= (int)((UsbRxBuf[7] << 24) & 0xFF000000);
			}

			return true;

		}

		static public bool WriteSvNet(int id, int data)
		{
			UsbTxBuf[0] = STX;
			UsbTxBuf[1] = Convert.ToByte('w');

			UsbTxBuf[2] = 0;	//null
			UsbTxBuf[3] = 0;	//null

			UsbTxBuf[4] = (byte)(id & 0xFF);
			UsbTxBuf[5] = (byte)((id >> 8) & 0xFF);
			UsbTxBuf[6] = (byte)((id >> 16) & 0xFF);
			UsbTxBuf[7] = (byte)((id >> 24) & 0xFF);

			UsbTxBuf[8] = (byte)(data & 0xFF);
			UsbTxBuf[9] = (byte)((data >> 8) & 0xFF);
			UsbTxBuf[10] = (byte)((data >> 16) & 0xFF);
			UsbTxBuf[11] = (byte)((data >> 24) & 0xFF);

			byte sum = new byte();

			for (int i = 1; i < 62; i++)
			{
				if (i >= 12) { UsbTxBuf[i] = 0; }
				sum += UsbTxBuf[i];
			}

			UsbTxBuf[62] = ETX;
			UsbTxBuf[63] = sum;

			if (!CUsb.WriteFile(UsbTxBuf, REQ_LEN)) { return false; }

            //ﾌﾟﾛｸﾞﾗﾑ保存及び消去（ﾌﾗｯｼｭﾒﾓﾘ消去）の場合は、最大2s待つ
            if ((id == 176 && data == 888) || (id == 176 && data == 999))
            {
				Thread.Sleep(2000);			//20180925 update 1000 -> 2000
            }

			if (!CheckUsbRead(RES_SVWR_LEN)) { return false; }

			return true;

		}

		static public bool ReadSvNetMonitor(byte cmd, int mon_num, ref int[] data)
		{
			UsbTxBuf[0] = STX;
			//UsbTxBuf[1] = Convert.ToByte('m');
			UsbTxBuf[1] = cmd;
			UsbTxBuf[2] = 0;	//null
			UsbTxBuf[3] = 0;	//null

			byte sum = new byte();

			for (int i = 1; i < 62; i++)
			{
				if (i >= 4) { UsbTxBuf[i] = 0; }
				sum += UsbTxBuf[i];
			}

			UsbTxBuf[62] = ETX;
			UsbTxBuf[63] = sum;

			if (!CUsb.WriteFile(UsbTxBuf, REQ_LEN)) { return false; }

			if (!CheckUsbRead(RES_SVRD_LEN)) { return false; }

			for (int i = 0, j = 0; i < mon_num; i++, j += 4)
			{
				unchecked
				{
					data[i] = UsbRxBuf[j + 4];
					data[i] |= (int)((UsbRxBuf[j + 5] << 8) & 0x0000FF00);
					data[i] |= (int)((UsbRxBuf[j + 6] << 16) & 0x00FF0000);
					data[i] |= (int)((UsbRxBuf[j + 7] << 24) & 0xFF000000);
				}
			}

			return true;

		}

		static public bool RequestCommandCode(char cmd, byte[] buf)
		{

			UsbTxBuf[0] = STX;
			UsbTxBuf[1] = Convert.ToByte(cmd);
			UsbTxBuf[2] = 0;	//null
			UsbTxBuf[3] = 0;	//null

			for (int i = 4; i < 62; i++)
			{
				UsbTxBuf[i] = buf[i];
			}

			byte sum = new byte();

			for (int i = 1; i < 62; i++)
			{
				sum += UsbTxBuf[i];
			}

			UsbTxBuf[62] = ETX;
			UsbTxBuf[63] = sum;

			if (!CUsb.WriteFile(UsbTxBuf, REQ_LEN)) { return false; }

			if (cmd == 'U') { return true; }	//DFUコマンドの最後はデバイスからの応答無し（STM32F）
			if (cmd == 'B') { return true; }	//DFUコマンドの最後はデバイスからの応答無し（RZT1）

			if (!CheckUsbRead(RES_SVRD_LEN)) { return false; }

			return true;
		}

		static public bool ReadFlashRZT1(int adr, int n, ref byte[] buf)
		{
			
            UsbTxBuf[0] = STX;
			UsbTxBuf[1] = Convert.ToByte('V');
			UsbTxBuf[2] = 0;	//null
			UsbTxBuf[3] = 0;	//null

			UsbTxBuf[4] = (byte)(adr & 0xFF);
			UsbTxBuf[5] = (byte)((adr >> 8) & 0xFF);
			UsbTxBuf[6] = (byte)((adr >> 16) & 0xFF);
			UsbTxBuf[7] = (byte)((adr >> 24) & 0xFF);

			UsbTxBuf[8] = (byte)n;

			byte sum = new byte();

			for (int i = 1; i < 62; i++)
			{
				sum += UsbTxBuf[i];
			}

			UsbTxBuf[62] = ETX;
			UsbTxBuf[63] = sum;

            if (!CUsb.WriteFile(UsbTxBuf, REQ_LEN)) { return false; }

			if (!CheckUsbRead(RES_SVRD_LEN)) { return false; }

			unchecked
			{
				int num = UsbRxBuf[4];

				for (int i = 0; i < num; i++)
				{
					buf[i] = UsbRxBuf[5 + i];
				}
			}

			return true;

		}


        //20220106 Ver1.31 add ↓ 
        static public bool RequestFlashRZT1Command(char cmd, byte[] payload)
        {
            try
            {
                byte[] usb_rx_buf = new byte[RES_SVRD_LEN];

                UsbTxBuf[0] = STX;
                UsbTxBuf[1] = Convert.ToByte(cmd);
                UsbTxBuf[2] = 0;
                UsbTxBuf[3] = 0;

                Buffer.BlockCopy(payload, 0, UsbTxBuf, 4, payload.Length);
                UsbTxBuf[REQ_LEN - 2] = ETX;

                byte sum = 0;
                for (int i = 1; i < REQ_LEN - 2; i++)
                {
                    sum += UsbTxBuf[i];
                }

                UsbTxBuf[REQ_LEN - 1] = sum;

                if (!CUsb.WriteFile(UsbTxBuf, REQ_LEN))				
				{
					return false;
				}

				if (!CUsb.ReadFileRZT1Upgrade(cmd, usb_rx_buf, ref payload))
				{
					return false;
				}

                return true;
            }
            catch
            {
                #if DEBUG
                Debug.WriteLine("!!! RequestFlashRZT1Command ERROR CATCH !!!");
                #endif
                
                return false;
            }

        }

        //20220106 Ver1.31 add ↑ 

        static private bool CheckUsbRead(int rx_len)
		{
			int rx_num = new int();

			if (!CUsb.ReadFile(UsbRxBuf, rx_len, ref rx_num))
			{
				//SerialPortクラスは何故かUSBデータが正常に通信しても、バッファー更新されない時がある。

				if (!CUsb.WriteFile(UsbTxBuf, REQ_LEN))
				{
					return false;		//2回連続はエラー
				}

				if (!CUsb.ReadFile(UsbRsBuf, rx_len, ref rx_num))
				{
					return false;		//2回連続はエラー
				}
				else
				{
					if (rx_num >= rx_len)
					{
						for (int i = 0; i < rx_len; i++)
						{
							UsbRxBuf[i] = UsbRsBuf[i + rx_num - rx_len];
						}
					}
					else
					{
						return false;
					}
				}
			}

            if (UsbRxBuf[0] != ACK) 
            {
                #if DEBUG
                Debug.WriteLine("!!! ACK not received !!! ");
                #endif
                return false; 
            }

			byte sum = new byte();

			for (int i = 1; i < rx_len - 2; i++)
			{
				sum += UsbRxBuf[i];
			}

			if (sum != UsbRxBuf[rx_len - 1]) 
            {
                #if DEBUG
                Debug.WriteLine("!!! Check SUM Error sum1 = " + sum.ToString() + " sum2 = " +  UsbRxBuf[rx_len - 1].ToString());
                #endif
                return false; 
            }

			return true;
		}

		static public bool WriteDummy()
		{
			UsbTxBuf[0] = STX;
			UsbTxBuf[1] = 0;

			byte sum = new byte();

			sum = 0;

			for (int i = 1; i < 62; i++)
			{
				UsbTxBuf[i] = 0;
				sum += UsbTxBuf[i];
			}

			UsbTxBuf[62] = ETX;
			UsbTxBuf[63] = sum;

			if (!CUsb.WriteFile(UsbTxBuf, REQ_LEN))
			{
				return false;
			}

			return true;

		}

		static private byte SplitByte(byte b, bool is_upper)
		{
			if (is_upper)
			{
				return (byte)((b >> 4) & 0x0F);
			}
			else
			{
				return (byte)((b >> 0) & 0x0F);
			}
		}

		//ASCII → DECデータ変換
		static private byte AsciiToDec(byte data)
		{
			byte dec;

			if ((data < 0x3A) && (data > 0x2F))				// 0-9
			{
				dec = (byte)((data - 0x30) & 0x0F);
			}
			else
			{
				dec = 0xFF;		// Error
			}

			return dec;
		}

		//HEX → ASCIIデータ変換
		static private byte HexToAscii(byte data)
		{
			byte asc;

			if (data < 10)		// 0-9
			{
				asc = (byte)(data + 0x30);
			}
			else				// A-F
			{
				asc = (byte)(data + 0x37);
			}

			return asc;
		}

	}
}

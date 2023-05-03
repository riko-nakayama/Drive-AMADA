using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Windows.Forms;

using System.Runtime.InteropServices;

using System.IO.Ports;
using System.Management;

using System.Diagnostics;
using System.Text.RegularExpressions;

using System.IO;

namespace Motion_Designer
{
	static public class CUsb : System.Object
	{
		private const int USB_BUF_SIZE = 8192;
		
		public const Byte EP1_IN	=	0x81;
		public const Byte EP2_OUT	=	0x02;
		public const Byte EP3_IN	=	0x83;
		public const Byte EP4_OUT	=	0x04;
		public const Byte EP5_IN	=	0x85;
		public const Byte EP6_OUT	=	0x06;
		public const int EP1_FIFO_SIZE = 512;
		public const int EP2_FIFO_SIZE = 512;

		static public Byte[] UsbRxBuf = new Byte[8192];
		
		static public Byte[] UsbRxData = new Byte[EP1_FIFO_SIZE];
		static public Byte[] UsbTxData = new Byte[EP2_FIFO_SIZE];

		static private SerialPort UsbCom;
		
		static private bool _IsUsbConnect = new bool();
		static private bool _IsCDCConnect = new bool();

		static private string ComName = string.Empty;

		static private Thread ThreadSerchCDC = new Thread(StartSerchCDC);

		static private Thread ThreadComOpen = new Thread(StartComOpen);
		static private Thread ThreadComClose = new Thread(StartComClose);

		static public void StartSerchCDC()
		{
			try
			{
				//ArrayList deviceNameList = new ArrayList();		20170321 del Winodws 10 対応
				
				Regex check = new Regex("(COM[1-9][0-9]?[0-9]?)");

				ManagementClass mcPnPEntity = new ManagementClass("Win32_PnPEntity");
				ManagementObjectCollection manageObjCol = mcPnPEntity.GetInstances();

				//全てのPnPデバイスを探索しシリアル通信が行われるデバイスを随時追加する
				foreach (ManagementObject manageObj in manageObjCol)
				{
					//Nameプロパティを取得
					object namePropertyValue = manageObj.GetPropertyValue("Name");
					if (namePropertyValue == null)
					{
						continue;
					}

					//Nameプロパティ文字列の一部が"(COM1)～(COM999)"と一致するときリストに追加"
					string name = namePropertyValue.ToString();
				
					if (check.IsMatch(name) || name.Contains("Tamagawa Seiki"))
					{
						//Winodws 10 対応	20170321 add 20171031 update PID_0101(P-Robo)
						if (manageObj.Path.ToString().Contains("VID_0DC1") && (manageObj.Path.ToString().Contains("PID_0100") || manageObj.Path.ToString().Contains("PID_0101")))
						{
							object nameProperty = manageObj.GetPropertyValue("Name");

							//Nameプロパティ文字列の一部が"(COM1)～(COM999)"と一致するときリストに追加"
							string com = nameProperty.ToString();

							int idx1 = com.IndexOf("(") + 1;

							int idx2 = com.IndexOf(")");

							if (idx2 > idx1)				//20180807 add (COM**)が認識しない場合のエラー対策
							{
								com = com.Substring(idx1, idx2 - idx1);

								ComName = com;
								IsCDCConnect = true;
							}
							else
							{
								IsCDCConnect = false;
							}

							return;
						}
						//Windows 10 対応
					}
				}
			}
			catch (ThreadAbortException)
			{
			}
			finally
			{
				//Mutexロックの開放
				//ThreadStatusMutex.ReleaseMutex();
			}
		}

		static public void StopSerchCDC()
		{
			ThreadSerchCDC.Abort();
		}

		static private bool ComOpenSuccess = new bool();

		static private void StartComOpen()
		{
			try
			{
				if (UsbCom != null)				//20180807 add USB切断時のエラー対策
				{
					if (!UsbCom.IsOpen)			//20170321 update
					{
						UsbCom.Open();
					}

					ComOpenSuccess = true;
				}
				else
				{
					ComOpenSuccess = false;
				}
			}
			catch
			{
				ComOpenSuccess = false;
			}
		}

		static private void StartComClose()
		{
			try 
			{
				if (UsbCom != null)
				{
					if (UsbCom.IsOpen)					//20170321 add Winodws 対応
					{
						//20170210 update USBケーブル切断でアプリケーションエラー対策
						//UsbCom.DiscardInBuffer();		//20170321 del Winodws 10 で不正
						//UsbCom.DiscardOutBuffer();	//20170321 del Winodws 10 で不正
						UsbCom.Close();
					}
				}
			}
			catch { }
		}

		static private bool CDCOpen()
		{
			try
			{
				UsbCom = new SerialPort(ComName, 115200, Parity.None, 8, StopBits.One);
				
				UsbCom.Handshake = Handshake.None;
				
				UsbCom.ReadBufferSize = USB_BUF_SIZE;
                UsbCom.ReadTimeout = 500;
				
				UsbCom.WriteBufferSize = USB_BUF_SIZE;
                UsbCom.WriteTimeout = 500;

				UsbCom.DiscardNull = true;

				UsbCom.Handshake = Handshake.XOnXOff;
				UsbCom.ReceivedBytesThreshold = 1;

				UsbCom.WriteBufferSize = 64;
				UsbCom.ReadBufferSize = 64;
			
				ComOpenSuccess = false;

				//20170213 update USBケーブル切断時にアプリケーションエラー対策
				ThreadComOpen = new Thread(StartComOpen);

				ThreadComOpen.Start();
				Thread.Sleep(500);
				ThreadComOpen.Abort();

				//StartComOpen();
			
				if (ComOpenSuccess)
				{
					UsbCom.DiscardInBuffer();
					UsbCom.DiscardOutBuffer();

					IsUsbConnect = true;
				}
				else
				{
					IsUsbConnect = false;
				}
			}
			catch
			{
				//20170213 update USBケーブル切断時にアプリケーションエラー対策
				ThreadComClose = new Thread(StartComClose);

				ThreadComClose.Start();
				Thread.Sleep(500);
				ThreadComClose.Abort();

				//StartComClose();

				IsUsbConnect = false;
			}

			return IsUsbConnect;
		}

		static int ThreadWait = new int();

		static public bool InitCUsb()
		{
			IsUsbConnect = false;

			try
			{
				if (IsCDCConnect)
				{
					ThreadSerchCDC.Abort();

					if (CDCOpen())
					{
						int data = new int();

                        if (CCommandTx.ReadSvNet(0, ref data))		//20170201 add
                        {
                            return true;
                        }
                        else
                        {
                            UnInitCUsb();

                            StartDevcon();

                            #if DEBUG
                            Debug.WriteLine("$$$ DEVCON_SVNET $$$");
                            #endif
                        }
					}
					else
					{
						UnInitCUsb();

						StartDevcon();

						#if DEBUG
						Debug.WriteLine("$$$ DEVCON_CDC_ERR $$$");
						#endif

						return false;
					}
				}
				else
				{	
					if (ThreadSerchCDC.ThreadState != System.Threading.ThreadState.Running)		//20170201 update
					{
						if (++ThreadWait >= 10)
						{
							ThreadWait = 0;

							ThreadSerchCDC = new Thread(StartSerchCDC);
							ThreadSerchCDC.Start();
						}
					}			
				}

				return false;
			}
			catch
			{
				//エラーは、呼ぶ側の上位クラスで表示
				return false;
			}
		}

		static public void UnInitCUsb()
		{
			IsUsbConnect = false;
			IsCDCConnect = false;

			//20170210 update USBケーブル切断でアプリケーションエラー対策
			if (ThreadSerchCDC != null)
			{
				if (ThreadSerchCDC.ThreadState == System.Threading.ThreadState.Running)
				{
					ThreadSerchCDC.Abort();
				}
			}
	
			//20170213 update USBケーブル切断時にアプリケーションエラー対策
			ThreadComClose = new Thread(StartComClose);

			ThreadComClose.Start();
			Thread.Sleep(500);
			ThreadComClose.Abort();

			//StartComClose();
		}

		static public bool IsUsbConnect
		{
			set { _IsUsbConnect = value; }
			get { return _IsUsbConnect; }
		}

		static public bool IsCDCConnect
		{
			set { _IsCDCConnect = value; }
			get { return _IsCDCConnect; }
		}

		static public bool WriteFile(byte[] tx_buf, int len)
		{
			try
			{
				//20170213 update USBケーブル切断時にアプリケーションエラー対策
				if (UsbCom == null) { return false; }
				if (UsbCom.IsOpen == false) { return false; }

				UsbCom.Write(tx_buf, 0, len);
				
				return true;
			}
			catch
			{
				#if DEBUG
				Debug.WriteLine("!!! WRITE USB ERROR CATCH !!!");
				#endif
			
				return false;
			}
		}

		static public bool ReadFile(byte[] rx_buf, int rx_len, ref int rx_num)
		{
			try
			{
				//20170213 update USBケーブル切断時にアプリケーションエラー対策
				if (UsbCom == null) { return false; }
				if (UsbCom.IsOpen == false) { return false; }

				int off = 0;
				int len = 0;

				CDataTool.SetNowMiliSecond(0);

				do
				{
					len = UsbCom.BytesToRead;

					#if DEBUG
					if (len != 0) { Debug.WriteLine(len.ToString()); }
					#endif
			
					if (len > 0)
					{
						off += UsbCom.Read(rx_buf, off, len);
					}

                    
					if (CDataTool.IsTimerLimitMiliSecond(0, 50))
					{
						//ショートパケット SerialPortクラスのバッファ更新されない。
						rx_num = off;
						
						#if DEBUG
						Debug.WriteLine("+++ USB READ TIME OUT +++");
						#endif

						return false;
					}

				} while (off < rx_len);

				rx_num = off;

				return true;
		
			}
			catch
			{
				//UnInitCUsb();

				#if DEBUG
				Debug.WriteLine("!!! READ USB ERROR CATCH !!!");
				#endif

				return false;
			}
		}

        //20220106 Ver1.31 add ↓

        static public bool ReadFileRZT1Upgrade(char cmd , byte[] rx_buf ,ref byte[] payload)
        {
            try
            {
                //20170213 update USBケーブル切断時にアプリケーションエラー対策
                if (UsbCom == null) { return false; }
                if (UsbCom.IsOpen == false) { return false; }

                /// データ受信
                int rd_num = 0;

                CDataTool.SetNow(8);

                do
                {
                    int len = UsbCom.BytesToRead;

                    if (len > 0)
                    {
                        int rd_size = UsbCom.Read(rx_buf, rd_num, rx_buf.Length);
                        rd_num += rd_size;
                    }

                    //2s Wait
                    if (CDataTool.IsTimerLimit(8,2)) 
                    {
                        #if DEBUG
                        Debug.WriteLine("!!! ReadFileRZT1Upgrade READ TIME OUT CATCH !!!");
                        #endif
                        return false; 
                    }

                } while (rd_num < rx_buf.Length);

                if (rx_buf[0] != CCommandTx.ACK)
                {
                    /// ACK以外はエラー
                    #if DEBUG
                    Debug.WriteLine("!!! ACK ERROR CATCH !!!");
                    #endif
                    return false;
                }

                if (cmd == 'V')
                {
                    if (rd_num > payload.Length - 5)
                    {
                        rd_num = payload.Length - 5;
                    }

                    Buffer.BlockCopy(rx_buf, 4, payload, 5, rd_num);
                }

                return true;

            }
            catch
            {
                #if DEBUG
                Debug.WriteLine("!!! Read File RZT1 Upgrade ERROR CATCH !!!");
                #endif
                return false;
            }
        }

        //20220106 Ver1.31 add ↑

		static private string devconResult = string.Empty;
		static private bool   devconFinish = new bool();
		
		private const int DEVCON_PERIOD = 5;
		private const int DEVCON_WAIT   = 1;

		static private void StartDevcon()
		{
			if (Properties.Settings.Default.DEV_CON_ENABLE == false) { return; }		//20170928 add

			devconExec(false);		//デバイスの無効

			devconExec(true);		//デバイスの有効
		}

		static public bool devconExec(bool enable)
		{
			if (Properties.Settings.Default.DEV_CON_ENABLE == false) { return false; }	//20170928 add

			Process p = new Process();

			try
			{
				//C:\\Users\\User\\AppData\\Local\\Drive
				string local = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Drive");

				string src_devcon = Path.Combine(Application.StartupPath, "devcon.exe");

				string dst_devcon = Path.Combine(local, "devcon.exe");

				try
				{
					if (!Directory.Exists(local)) { Directory.CreateDirectory(local); }

					if (!File.Exists(dst_devcon)) { File.Copy(src_devcon, dst_devcon, true); }
				}
				catch
				{
					dst_devcon = src_devcon;
				}

				p.StartInfo.Verb = "RunAs";		//管理者に昇格して実行

				//パスを取得して、FileNameプロパティに指定
				p.StartInfo.FileName = dst_devcon;

				if (enable)
				{
					p.StartInfo.Arguments = "enable \"@USB\\VID_0DC1&PID_0100*";
				}
				else
				{
					p.StartInfo.Arguments = "disable \"@USB\\VID_0DC1&PID_0100*";
				}

				p.OutputDataReceived += p_OutputDataReceived;

				//出力を読み取れるようにする
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.RedirectStandardOutput = true;
				p.StartInfo.RedirectStandardInput = false;

				//ウィンドウを表示しないようにする
				p.StartInfo.CreateNoWindow = true;

				//起動
				p.Start();

				//非同期で出力の読み取りを開始
				p.BeginOutputReadLine();

				devconFinish = false;

				CDataTool.SetNow(CDataTool.USB_TIME);

				while (!devconFinish)
				{
					if (CDataTool.IsTimerLimit(CDataTool.USB_TIME, DEVCON_WAIT)) { break; }
				}

				while (!p.HasExited) { }

				p.Close();

				return devconFinish;
			}
			catch
			{
				p.Close();

				return devconFinish;
			}
		}

		static private void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			//出力された文字列を表示する
			devconResult += e.Data;
			devconFinish = true;
		}

	};
}

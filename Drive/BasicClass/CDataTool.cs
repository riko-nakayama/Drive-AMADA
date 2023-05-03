using System;
using System.Collections.Generic;
using System.Text;

namespace Motion_Designer
{
	static class CDataTool
	{
		public const int GAIN_TIMER = 3;

		/// <summary>
		/// HEX文字列の桁を合わせます。（上位の0を埋めます）
		/// 桁数は32ビット8桁です。
		/// </summary>
		/// <param name="str_hex"></param>
		/// <returns></returns>
		static public string HexStringFormat32(string str_hex)
		{
			int n = 8 - str_hex.Length;
			string o = string.Empty;

			for (int i = 0; i < n; i++)
			{
				o += "0";
			}

			return "0x" + o + str_hex;
		}

		/// <summary>
		/// HEX文字列を32ビット符号付き整数に変換します。
		/// 正常に変換された場合はtrueを返却します。
		/// </summary>
		/// <param name="str_hex"></param>
		/// <param name="int_num"></param>
		/// <returns></returns>
		static public bool HexStringToInt32(string str_hex, ref int int_num)
		{
			char[] chr = new char[1];
			string str = "";
			byte cnt = 0;
			byte byt = 0;
			uint udec = 0;

			str_hex = str_hex.Trim();

			try
			{
				if (str_hex.Length >= 2)
				{
					if (str_hex.Substring(0, 2) == "H'" ||
						str_hex.Substring(0, 2) == "0x" ||
						str_hex.Substring(0, 2) == "0X")
					{
						str_hex = str_hex.Remove(0, 2);
					}
				}
				else if (str_hex.Length == 1)
				{
					if (str_hex.Substring(0, 1) == "H")
					{
						str_hex = str_hex.Remove(0, 1);
					}
				}

				chr[0] = '0';
				str = str_hex.TrimStart(chr);

				if (str != "")
				{
					str_hex = str;
				}

				switch (str_hex.Length)
				{
					case 8:
						if (HexCharacterToDecimal(str_hex.Substring(0, 1), ref byt) == false)
						{
							return false;
						}
						udec = Convert.ToUInt32(byt * Math.Pow(16, 7));
						cnt++;
						goto case 7;
					case 7:
						if (HexCharacterToDecimal(str_hex.Substring(0 + cnt, 1), ref byt) == false)
						{
							return false;
						}
						udec += Convert.ToUInt32(byt * Math.Pow(16, 6));
						cnt++;
						goto case 6;
					case 6:
						if (HexCharacterToDecimal(str_hex.Substring(0 + cnt, 1), ref byt) == false)
						{
							return false;
						}
						udec += Convert.ToUInt32(byt * Math.Pow(16, 5));
						cnt++;
						goto case 5;
					case 5:
						if (HexCharacterToDecimal(str_hex.Substring(0 + cnt, 1), ref byt) == false)
						{
							return false;
						}
						udec += Convert.ToUInt32(byt * Math.Pow(16, 4));
						cnt++;
						goto case 4;
					case 4:
						if (HexCharacterToDecimal(str_hex.Substring(0 + cnt, 1), ref byt) == false)
						{
							return false;
						}
						udec += Convert.ToUInt32(byt * Math.Pow(16, 3));
						cnt++;
						goto case 3;
					case 3:
						if (HexCharacterToDecimal(str_hex.Substring(0 + cnt, 1), ref byt) == false)
						{
							return false;
						}
						udec += Convert.ToUInt32(byt * Math.Pow(16, 2));
						cnt++;
						goto case 2;
					case 2:
						if (HexCharacterToDecimal(str_hex.Substring(0 + cnt, 1), ref byt) == false)
						{
							return false;
						}
						udec += Convert.ToUInt32(byt * Math.Pow(16, 1));
						cnt++;
						goto case 1;
					case 1:
						if (HexCharacterToDecimal(str_hex.Substring(0 + cnt, 1), ref byt) == false)
						{
							return false;
						}
						udec += Convert.ToUInt32(byt * Math.Pow(16, 0));
						cnt++;
						break;
					default:
						return false;
				}
				int_num = (int)udec;
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// HEX文字列を64ビット符号付き整数に変換します。
		/// </summary>
		/// <param name="str_hex"></param>
		/// <param name="long_num"></param>
		/// <returns></returns>
		static public bool HexStringToInt64(string str_hex, ref long long_num)
		{
			char[] chr = new char[1];
			string str = "";
			byte byt = 0;
			ulong udec = 0;

			str_hex = str_hex.Trim();

			try
			{
				if (str_hex.Length >= 2)
				{
					if (str_hex.Substring(0, 2) == "H'" || str_hex.Substring(0, 2) == "0x" || str_hex.Substring(0, 2) == "0X")
					{
						str_hex = str_hex.Remove(0, 2);
					}
				}
				else if (str_hex.Length == 1)
				{
					if (str_hex.Substring(0, 1) == "H")
					{
						str_hex = str_hex.Remove(0, 1);
					}
				}

				chr[0] = '0';
				str = str_hex.TrimStart(chr);

				if (str != "")
				{
					str_hex = str;
				}

				for (int i = 0; i < str_hex.Length; i++)
				{
					if (HexCharacterToDecimal(str_hex.Substring(i, 1), ref byt) == false)
					{
						return false;
					}

					udec += Convert.ToUInt64(byt * Math.Pow(16, str_hex.Length - i - 1));						
				}

				long_num = (long)udec;

				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// HEX文字（1文字）を10進数に変換します。
		/// </summary>
		/// <param name="str_hex"></param>
		/// <param name="byte_num"></param>
		/// <returns></returns>
		static private bool HexCharacterToDecimal( string str_hex, ref byte byte_num )
		{
			switch( str_hex )
			{
				case "F":
					byte_num = 15;
					return true;
				case "E":
					byte_num = 14;
					return true;
				case "D":
					byte_num = 13;
					return true;
				case "C":
					byte_num = 12;
					return true;
				case "B":
					byte_num = 11;
					return true;
				case "A":
					byte_num = 10;
					return true;
				case "f":
					byte_num = 15;
					return true;
				case "e":
					byte_num = 14;
					return true;
				case "d":
					byte_num = 13;
					return true;
				case "c":
					byte_num = 12;
					return true;
				case "b":
					byte_num = 11;
					return true;
				case "a":
					byte_num = 10;
					return true;
				case "9":
					byte_num = 9;
					return true;
				case "8":
					byte_num = 8;
					return true;
				case "7":
					byte_num = 7;
					return true;
				case "6":
					byte_num = 6;
					return true;
				case "5":
					byte_num = 5;
					return true;
				case "4":
					byte_num = 4;
					return true;
				case "3":
					byte_num = 3;
					return true;
				case "2":
					byte_num = 2;
					return true;
				case "1":
					byte_num = 1;
					return true;
				case "0":
					byte_num = 0;
					return true;
				default:
					return false;
			}
		}

		/// <summary>
		/// HEX文字列をdoubleに変換します。
		/// 正常に変換された場合はtrueを返却します。
		/// </summary>
		/// <param name="str_hex"></param>
		/// <param name="double_num"></param>
		/// <returns></returns>
		static public bool HexStringToDouble(string str_hex, ref double double_num)
		{
			str_hex = str_hex.Trim();

			try
			{
				if (str_hex.Length >= 2)
				{
					if (str_hex.Substring(0, 2) == "H'" || str_hex.Substring(0, 2) == "0x" || str_hex.Substring(0, 2) == "0X")
					{
						str_hex = str_hex.Remove(0, 2);
					}
				}
				else if (str_hex.Length == 1)
				{
					if (str_hex.Substring(0, 1) == "H")
					{
						str_hex = str_hex.Remove(0, 1);
					}
				}

				string zero = string.Empty;
				int n = 16 - str_hex.Length;

				for (int i = 0; i < n; i++)
				{
					zero += "0";
				}

				str_hex = zero + str_hex;

				byte[] b = new byte[8];
				byte x = 0, y = 0;

				for (int i = 0, j = 0; i < str_hex.Length; i+=2, j++)
				{
					if (HexCharacterToDecimal(str_hex.Substring(i, 1), ref x) == false)
					{
						return false;
					}
					if (HexCharacterToDecimal(str_hex.Substring(i + 1, 1), ref y) == false)
					{
						return false;
					}

					b[j] = (byte)(x * 16 + y);
				}

				double_num = BitConverter.ToDouble(b, 0);

				return true;

			}
			catch
			{
				return false;
			}

		}

		/// <summary>
		/// double型文字列を32ビット整数型に変換します。
		/// 上位4バイトと下位4バイトの指定は引数upperで指定します。
		/// </summary>
		/// <param name="str_double"></param>
		/// <param name="flg"></param>
		/// <param name="int_num"></param>
		/// <returns></returns>
		static public bool DoubleStringToInt32(bool flg, string str_double, ref int int_num)
		{
			try
			{
				byte[] b = BitConverter.GetBytes(Convert.ToDouble(str_double));

				if (flg)
				{
					int_num |= b[7] << 24;
					int_num |= b[6] << 16;
					int_num |= b[5] << 8;
					int_num |= b[4] << 0;
				}
				else
				{
					int_num |= b[3] << 24;
					int_num |= b[2] << 16;
					int_num |= b[1] << 8;
					int_num |= b[0] << 0;
				}

				return true;
			}
			catch
			{
				return false;
			}

		}

		/// <summary>
		/// double型を32ビット整数型に変換します。
		/// 上位4バイトと下位4バイトの指定は引数upperで指定します。
		/// </summary>
		/// <param name="double_num"></param>
		/// <param name="flg"></param>
		/// <returns></returns>
		static public int DoubleToInt32(double double_num, bool flg)
		{
			int int_num = 0;
		
			byte[] b = BitConverter.GetBytes(double_num);

			if (flg)
			{
				int_num |= b[7] << 24;
				int_num |= b[6] << 16;
				int_num |= b[5] << 8;
				int_num |= b[4] << 0;
			}
			else
			{
				int_num |= b[3] << 24;
				int_num |= b[2] << 16;
				int_num |= b[1] << 8;
				int_num |= b[0] << 0;
			}
			return int_num;
		}

		/// <summary>
		/// double型を64ビット整数型に変換します。
		/// </summary>
		/// <param name="double_num"></param>
		/// <returns></returns>
		static public long DoubleToInt64(double double_num)
		{
			long long_num = 0;
			byte[] b = BitConverter.GetBytes(double_num);

			long_num |= (long)b[7] << 56;
			long_num |= (long)b[6] << 48;
			long_num |= (long)b[5] << 40;
			long_num |= (long)b[4] << 32;
			long_num |= (long)b[3] << 24;
			long_num |= (long)b[2] << 16;
			long_num |= (long)b[1] << 8;
			long_num |= (long)b[0] << 0;

			return long_num;
		}

		/// <summary>
		/// 32ビット整数を32ビット2進文字列に変換します。
		/// </summary>
		/// <param name="int_num"></param>
		/// <returns></returns>
		static public string Int32ToBinString32(int int_num)
		{
			string str_bin = string.Empty;

			for (int i = 0; i < 32; i++)
			{
				if (((i % 8) == 0) & (i != 0))
				{
					str_bin = " " + str_bin;
				}
				str_bin = (int_num & 1).ToString() + str_bin;
				int_num >>= 1;
			}

			return str_bin;
		}

		/// <summary>
		/// 32ビット整数を16ビット2進文字列に変換します。
		/// </summary>
		/// <param name="int_num"></param>
		/// <returns></returns>
		static public string Int32ToBinString16(int int_num)
		{
			string str_bin = string.Empty;

			for (int i = 0; i < 16; i++)
			{
				if (((i % 8) == 0) & (i != 0))
				{
					str_bin = " " + str_bin;
				}
				str_bin = (int_num & 1).ToString() + str_bin;
				int_num >>= 1;
			}

			return str_bin;
		}

		/// <summary>
		/// 32ビット整数を8ビット2進文字列に変換します。
		/// </summary>
		/// <param name="int_num"></param>
		/// <returns></returns>
		static public string Int32ToBinString8(int int_num)
		{
			string str_bin = string.Empty;

			for (int i = 0; i < 8; i++)
			{
				if (((i % 8) == 0) & (i != 0))
				{
					str_bin = " " + str_bin;
				}
				str_bin = (int_num & 1).ToString() + str_bin;
				int_num >>= 1;
			}

			return str_bin;
		}

		/// <summary>
		/// double型を64ビット2進文字列に変換します。
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		static public string DoubleToBinString64(double double_num)
		{
			long long_num = DoubleToInt64(double_num);
			string str_bin = string.Empty;

			for (int i = 0; i < 64; i++)
			{
				if (((i % 8) == 0) & (i != 0))
				{
					str_bin = " " + str_bin;
				}
				str_bin = (long_num & 1).ToString() + str_bin;
				long_num >>= 1;
			}

			return str_bin;
		}

		/// <summary>
		/// 64ビット2進文字列をdouble型に変換します。
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		static public double BinString64ToDouble(string str_bit64)
		{
			str_bit64 = str_bit64.Replace(" ", "");		//2進表示空白文字削除
			byte[] b = new byte[8];
			string str = string.Empty;

			for (int i = 0, x = 0; i < 64; i+=8, x++)
			{
				for (int j = 0; j < 8; j++)
				{
					str = str_bit64.Substring(i + j, 1);

					if (str == "1")
					{
						b[7 - x] += Convert.ToByte(2 ^ (7 - j));
					}
				}
			}

			return BitConverter.ToDouble(b, 0);
		}

		static public bool IntStringToByte(string str_int, int index, ref byte byte_num)
		{
			try
			{
				switch (index)
				{
					case 0:
						byte_num = (byte)((Convert.ToInt32(str_int) >> 24) & 0xFF);
						break;
					case 1:
						byte_num = (byte)((Convert.ToInt32(str_int) >> 16) & 0xFF);
						break;
					case 2:
						byte_num = (byte)((Convert.ToInt32(str_int) >> 8) & 0xFF);
						break;
					case 3:
						byte_num = (byte)((Convert.ToInt32(str_int)) & 0xFF);
						break;
					default:
						return false;
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		static public byte Int32ToByte(int int_num, int index)
		{
			switch (index)
			{
				case 0:
					return (byte)((int_num >> 24) & 0xFF);
				case 1:
					return (byte)((int_num >> 16) & 0xFF);
				case 2:
					return (byte)((int_num >> 8) & 0xFF);
				case 3:
					return (byte)((int_num) & 0xFF);
				default:
					return 0;
			}
		}

		static public int ByteToInt32(byte[] byte_arr)
		{
			int int_num = 0;

			switch (byte_arr.Length)
			{
				case 4:
					int_num |= ((int)byte_arr[3] << 0) & 0x000000FF;
					goto case 3;
				case 3:
					int_num |= ((int)byte_arr[2] << 8) & 0x0000FF00;
					goto case 2;
				case 2:
					int_num |= ((int)byte_arr[1] << 16) & 0x00FF0000;
					goto case 1;
				case 1:
					int_num |= (int)byte_arr[0] << 24;
					break;
				default:
					break;
			}

			return int_num;
			
		}

		/// <summary>
		/// 単精度浮動小数点を32ビット整数に変換します。
		/// 少数点以下は四捨五入されます。
		/// </summary>
		/// <param name="float_num"></param>
		/// <returns></returns>
		static public int FloatToInt32(float float_num)
		{
			int int_num;

			if (float_num >= 0.0)
			{
				if (float_num >= 2147484647.5)
				{
					int_num = 2147483647;
				}
				else
				{
					int_num = (int)(Math.Floor((double)(float_num + 0.5)));
				}
			}
			else
			{
				if (float_num <= -2147484647.5)
				{
					int_num = -2147483647;
				}
				else
				{
					int_num = (int)(Math.Ceiling((double)(float_num - 0.5)));
				}
			}

			return int_num;
		}
		
		#region データ型チェック

		/// <summary>
		/// 文字列が16進表記かチェックします。
		/// trueなら16進　falseならそれ以外
		/// </summary>
		/// <param name="tkn"></param>
		/// <returns></returns>
		static public bool IsHexNumeric(string tkn)
		{
			if (tkn.Length < 2)
			{
				return false;
			}

			tkn = tkn.ToUpper();

			if (tkn.Substring(0, 2) == "0X")
			{
				if (IsHexCharacter(tkn.Remove(0, 2)) == true)
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// 文字列が16進表記かつ32ビット整数として使用可能かチェックします。
		/// trueなら16進　falseならそれ以外
		/// </summary>
		/// <param name="tkn"></param>
		/// <returns></returns>
		static public bool IsHexNumeric32(string tkn)
		{
			if (tkn.Length < 2)
			{
				return false;
			}

			tkn = tkn.ToUpper();

			if (tkn.Substring(0, 2) == "0X")
			{
				if (IsHexCharacter(tkn.Remove(0, 2)) == true)
				{
					if (tkn.Length > 10)
					{
						return false;
					}
					else
					{
						return true;
					}
				}
			}

			return false;
		}

		/// <summary>
		/// 文字列が16進表記かつ32ビット整数として使用可能かチェックします。"0x"無しで判定します。
		/// trueなら16進　falseならそれ以外
		/// </summary>
		/// <param name="tkn"></param>
		/// <returns></returns>
		static public bool IsHexNumeric32_Head(string tkn)
		{
			string hex = string.Empty;

			if (tkn.Length <= 2)
			{
				hex = "0X" + tkn;
			}
			else
			{
				tkn = tkn.ToUpper();

				if (tkn.Substring(0, 2) == "0X")
				{
					hex = tkn;
				}
				else
				{
					hex = "0X" + tkn;
				}
			}

			return IsHexNumeric32(hex);
		}

		/// <summary>
		/// 1文字がHEX数値として使用できるかチェックします。
		/// trueなら使用可能文字　falseなら使用不可能文字字
		/// </summary>
		/// <param name="tkn"></param>
		/// <returns></returns>
		static public bool IsHexCharacter(string tkn)
		{
			if (tkn.Length < 1)
			{
				return false;
			}

			tkn = tkn.ToUpper();

			for (int i = 0; i < tkn.Length; i++)
			{
				switch (tkn.Substring(i, 1))
				{
					case "0":
						break;
					case "1":
						break;
					case "2":
						break;
					case "3":
						break;
					case "4":
						break;
					case "5":
						break;
					case "6":
						break;
					case "7":
						break;
					case "8":
						break;
					case "9":
						break;
					case "A":
						break;
					case "B":
						break;
					case "C":
						break;
					case "D":
						break;
					case "E":
						break;
					case "F":
						break;
					default:
						return false;
				}
			}

			return true;
		}

		/// <summary>
		/// 文字列が符号付き数値として使用できるかチェックします。
		/// trueなら数値　falseなら文字
		/// </summary>
		/// <param name="tkn"></param>
		/// <returns></returns>
		static public bool IsSignedNumeric(string tkn)
		{
			if (tkn.Length < 1)
			{
				return false;
			}

			if (tkn.Substring(0, 1) == "-")
			{
				//"-"記号削除
				tkn = tkn.Remove(0, 1);
			}

			if (tkn.Length < 1)
			{
				return false;
			}

			for (int i = 0; i < tkn.Length; i++)
			{
				switch (tkn.Substring(i, 1))
				{
					case "0":
						break;
					case "1":
						break;
					case "2":
						break;
					case "3":
						break;
					case "4":
						break;
					case "5":
						break;
					case "6":
						break;
					case "7":
						break;
					case "8":
						break;
					case "9":
						break;
					default:
						return false;
				}
			}

			return true;
		}

		/// <summary>
		/// 文字列が符号付き32ビット整数として使用できるかチェックします。
		/// trueなら数値　falseなら文字
		/// </summary>
		/// <param name="tkn"></param>
		/// <returns></returns>
		static public bool IsSignedNumeric32(string tkn)
		{
			if (tkn.Length < 1)
			{
				return false;
			}

			if (tkn.Substring(0, 1) == "-")
			{
				//"-"記号削除
				tkn = tkn.Remove(0, 1);
			}

			if (tkn.Length < 1)
			{
				return false;
			}

			for (int i = 0; i < tkn.Length; i++)
			{
				switch (tkn.Substring(i, 1))
				{
					case "0":
						break;
					case "1":
						break;
					case "2":
						break;
					case "3":
						break;
					case "4":
						break;
					case "5":
						break;
					case "6":
						break;
					case "7":
						break;
					case "8":
						break;
					case "9":
						break;
					default:
						return false;
				}
			}

			try
			{
				int x = Convert.ToInt32(tkn);
			}
			catch
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// 文字列が符号無し数値として使用できるかチェックします。
		/// trueなら数値　falseなら文字
		/// </summary>
		/// <param name="tkn"></param>
		/// <returns></returns>
		static public bool IsUnsignedNumeric(string tkn)
		{
			if (tkn.Length < 1)
			{
				return false;
			}

			for (int i = 0; i < tkn.Length; i++)
			{
				switch (tkn.Substring(i, 1))
				{
					case "0":
						break;
					case "1":
						break;
					case "2":
						break;
					case "3":
						break;
					case "4":
						break;
					case "5":
						break;
					case "6":
						break;
					case "7":
						break;
					case "8":
						break;
					case "9":
						break;
					default:
						return false;
				}
			}

			return true;
		}

		/// <summary>
		/// 文字列が実数として使用できるかチェックします。
		/// trueなら実数　falseなら文字
		/// </summary>
		/// <param name="tkn"></param>
		/// <returns></returns>
		static public  bool IsRealNumeric(string tkn)
		{
			if (tkn.Length < 1)
			{
				return false;
			}

			if (tkn.Substring(0, 1) == "-" || tkn.Substring(0, 1) == "+")
			{
				//"-"記号削除
				tkn = tkn.Remove(0, 1);
			}

			if (tkn.Length < 1)
			{
				return false;
			}

			bool dot = false;
			bool exp = false;

			for (int i = 0; i < tkn.Length; i++)
			{
				switch (tkn.Substring(i, 1))
				{
					case "0":
						break;
					case "1":
						break;
					case "2":
						break;
					case "3":
						break;
					case "4":
						break;
					case "5":
						break;
					case "6":
						break;
					case "7":
						break;
					case "8":
						break;
					case "9":
						break;
					case ".":

						if (dot == true)
						{
							//少数点が2つNG
							return false;
						}
						else
						{
							dot = true;
						}
						break;

					case "E":
					case "e":

						if (i == 0) { return false; }
						if (i == 1 && tkn.Substring(0, 1) == ".") { return false; }

						if (exp == true)
						{
							//少数点が2つNG
							return false;
						}
						else
						{
							exp = true;
						}
						break;

					case "+":
					case "-":

						if( i < 1 ) { return false; }
						if (tkn.Substring(i - 1, 1).ToUpper() != "E") { return false; }
						break;

					default:
						return false;
				}
			}

			return true;
		}

		/// <summary>
		/// 1文字がBIN数値として使用できるかチェックします。
		/// trueなら使用可能文字　falseなら使用不可能文字。
		/// </summary>
		/// <param name="tkn"></param>
		/// <returns></returns>
		static public bool IsBinCharacter(string tkn)
		{
			if (tkn.Length < 1)
			{
				return false;
			}

			tkn = tkn.ToUpper();

			for (int i = 0; i < tkn.Length; i++)
			{
				switch (tkn.Substring(i, 1))
				{
					case "0":
						break;
					case "1":
						break;
					case " ":
						break;
					default:
						return false;
				}
			}

			return true;
		}

		/// <summary>
		/// 終端文字列かチェックします。
		/// trueなら終端文字、falseならそれ以外。
		/// </summary>
		/// <param name="tkn"></param>
		/// <returns></returns>
		static public bool IsDelimiter(string tkn)
		{
			switch (tkn)
			{
				case "(":
				case ")":
				case "[":
				case "]":
				case "{":
				case "}":
				case ",":
				case ".":
				case ";":
				case ":":
				case "!":
				case "^":
				case "~":
				case "|":
				case "&":
				case "+":
				case "-":
				case "*":
				case "/":
				case "<":
				case ">":
				case "\t":
				case "\n":
				case "\r":
				case " ":

					return true;
				default:
					return false;
			}
		}

		#endregion

		//経過時間監視処理（無限ループ回避）
		static private int[] OldTime = new int[16];
		static private int[] NewTime = new int[16];

		public const int MAIN_TIME = 0;
		public const int USB_TIME  = 1;
		public const int JOG_TIME  = 2;
		public const int TUNE_TIME = 3;
		public const int UPG1_TIME = 4;
		public const int UPG2_TIME = 5;
		public const int TEACH_TIME = 6;
		public const int VIB_TIME = 7;

		static public void SetNow(int t_idx)
		{

			OldTime[t_idx] = DateTime.Now.Second;
		}

		static public bool IsTimerLimit(int t_idx, int wait_sec)
		{
			if (wait_sec >= 60) { wait_sec = 59; }

			NewTime[t_idx] = DateTime.Now.Second;

			if (NewTime[t_idx] < OldTime[t_idx])
			{
				NewTime[t_idx] += 60;
			}

			if (NewTime[t_idx] - OldTime[t_idx] > wait_sec)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		static public void SetNowMiliSecond(int t_idx)
		{

			OldTime[t_idx] = DateTime.Now.Millisecond;
		}

		static public bool IsTimerLimitMiliSecond(int t_idx, int wait_msec)
		{

			NewTime[t_idx] = DateTime.Now.Millisecond;

			if (NewTime[t_idx] < OldTime[t_idx])
			{
				NewTime[t_idx] += 1000;
			}

			if (NewTime[t_idx] - OldTime[t_idx] > wait_msec)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

        // ↓↓↓ 20210324 Kimura add ↓↓↓
        static public int GetInertiaDiameter(int load)
        {
            return (int)(load * Math.Pow(10 , CMonitor.GetParameter(CParamID.InertiaManif)));
        }

        static public int SetInertiaDiameter(int load)
        {
            return (int)(load / Math.Pow(10, CMonitor.GetParameter(CParamID.InertiaManif)));
        }

        static public double Inertiagcm2Tokgm2(int load)
        {
            return load * Math.Pow(10, -7);
        }

        static public double Inertiakgm2Togcm2(int load)
        {
            return load / Math.Pow(10, -7);
        }
        // ↑↑↑ 20210324 Kimura add ↑↑↑
	}
}

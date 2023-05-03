using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace RegSet
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				//ローカルコンピュータの環境変数"PROCESSOR_ARCHITECTURE"の値を取得
				string procArch = System.Environment.GetEnvironmentVariable(
					"PROCESSOR_ARCHITECTURE", System.EnvironmentVariableTarget.Machine);

				//string path = Environment.CurrentDirectory;
				string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

				if (procArch == null || procArch == "x86")
				{
					//32ビットOS
					path = Path.Combine(path, "os32.txt");

					StreamWriter file = new StreamWriter(path, false, System.Text.Encoding.Unicode);

					file.WriteLine("32bit OS");

					file.Close();
				}
				else
				{
					//64ビットOS
					path = Path.Combine(path, "os64.txt");

					StreamWriter file = new StreamWriter(path, false, System.Text.Encoding.Unicode);

					file.WriteLine("64bit OS");

					file.Close();

				}
			}
			catch
			{

			}
		}
	}
}

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
				//���[�J���R���s���[�^�̊��ϐ�"PROCESSOR_ARCHITECTURE"�̒l���擾
				string procArch = System.Environment.GetEnvironmentVariable(
					"PROCESSOR_ARCHITECTURE", System.EnvironmentVariableTarget.Machine);

				//string path = Environment.CurrentDirectory;
				string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

				if (procArch == null || procArch == "x86")
				{
					//32�r�b�gOS
					path = Path.Combine(path, "os32.txt");

					StreamWriter file = new StreamWriter(path, false, System.Text.Encoding.Unicode);

					file.WriteLine("32bit OS");

					file.Close();
				}
				else
				{
					//64�r�b�gOS
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

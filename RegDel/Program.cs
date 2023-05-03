using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace RegDel
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				string desk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				
				string path32 = Path.Combine(desk, "os32.txt");
				string path64 = Path.Combine(desk, "os64.txt");

				if (File.Exists(path32)) { File.Delete(path32); }
				if (File.Exists(path64)) { File.Delete(path64); }
			}
			catch
			{

			}
		}
	}
}

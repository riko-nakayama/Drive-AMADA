using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Motion_Designer
{
	public partial class ManualNavigatorForm : Form
	{
		public ManualNavigatorForm()
		{
			InitializeComponent();
		}

		private void linkTAD8811UsersManualJP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			switch (Culture.Name)
			{
				case Culture.JP:
					if (File.Exists(Path.Combine(Application.StartupPath + "\\Manual", "TAD8811_UsersManual_JP.pdf")))
					{
						System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath + "\\Manual", "TAD8811_UsersManual_JP.pdf"));
					}
					break;

				case Culture.CN:
					if (File.Exists(Path.Combine(Application.StartupPath + "\\Manual", "TAD8811_UsersManual_EN.pdf")))
					{
						System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath + "\\Manual", "TAD8811_UsersManual_EN.pdf"));
					}
					//if (File.Exists(Path.Combine(Application.StartupPath + "\\Manual", "TAD8811_UsersManual_CN.pdf")))
					//{
					//    System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath + "\\Manual", "TAD8811_UsersManual_CN.pdf"));
					//}
					break;

				case Culture.US:
					if (File.Exists(Path.Combine(Application.StartupPath + "\\Manual", "TAD8811_UsersManual_EN.pdf")))
					{
						System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath + "\\Manual", "TAD8811_UsersManual_EN.pdf"));
					}
					break;
			}
		}

		private void linkTAD8810UsersManualJP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			switch (Culture.Name)
			{
				case Culture.JP:
					if (File.Exists(Path.Combine(Application.StartupPath + "\\Manual", "TAD8810_UsersManual_JP.pdf")))
					{
						System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath + "\\Manual", "TAD8810_UsersManual_JP.pdf"));
					}
					break;

				case Culture.CN:
						break;

				case Culture.US:
					break;
			}
		}

		private void linkDriveSoftwareManualJP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			switch(Culture.Name)
			{
				case Culture.JP:
					if (File.Exists(Path.Combine(Application.StartupPath + "\\Manual", "Drive_SoftwareManual_JP.pdf")))
					{
						System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath + "\\Manual", "Drive_SoftwareManual_JP.pdf"));
					}
					break;
		
				case Culture.CN:
					if (File.Exists(Path.Combine(Application.StartupPath + "\\Manual", "Drive_SoftwareManual_CN.pdf")))
					{
						System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath + "\\Manual", "Drive_SoftwareManual_CN.pdf"));
					}
					break;
				
				case Culture.US:
					if (File.Exists(Path.Combine(Application.StartupPath + "\\Manual", "Drive_SoftwareManual_EN.pdf")))
					{
						System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath + "\\Manual", "Drive_SoftwareManual_EN.pdf"));
					}
					break;
			}
		}

		private void linkSimpleProgramUsersManualJP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			switch (Culture.Name)
			{
				case Culture.JP:
					if (File.Exists(Path.Combine(Application.StartupPath + "\\Manual", "SimpleProgram_UsersManual_JP.pdf")))
					{
						System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath + "\\Manual", "SimpleProgram_UsersManual_JP.pdf"));
					}
					break;

				case Culture.CN:
					break;

				case Culture.US:
					break;
			}
		}
	}
}
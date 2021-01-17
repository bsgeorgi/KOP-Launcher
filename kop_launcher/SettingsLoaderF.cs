using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace kop_launcher
{
	public partial class SettingsLoaderF : Form
	{
		private ConfigFileReaderWriter     configs;
		private Dictionary<string, string> CandyFXsettings;
		private Dictionary<string, string> GlobalSettings;
		private Dictionary<string, string> GameSettings;
		private SettingsF                  settingsForm;

		public SettingsLoaderF ( )
		{
			InitializeComponent ( );

			backgroundWorker1.DoWork             += BackgroundWorker1_DoWork;
			backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
			backgroundWorker1.RunWorkerAsync ( );
		}

		private bool CheckOpened ( string name )
		{
			var fc = Application.OpenForms;
			foreach ( Form frm in fc )
				if ( frm.Name == name )
					return true;
			return false;
		}

		private void BringToFront ( string name )
		{
			var fc = Application.OpenForms;
			foreach ( Form frm in fc )
				if ( frm.Name == name )
					frm.BringToFront ( );
		}

		private void BackgroundWorker1_RunWorkerCompleted ( object sender, RunWorkerCompletedEventArgs e )
		{
			if ( !CheckOpened ( "SettingsF" ) )
			{
				settingsForm = new SettingsF ( CandyFXsettings, GlobalSettings, GameSettings );
				settingsForm.Show ( );
				settingsForm.IsOpen = true;

				backgroundWorker1.Dispose ( );
				configs         = null;
				CandyFXsettings = null;
				GlobalSettings  = null;
				GameSettings    = null;
				Close ( );
			}
			else
			{
				backgroundWorker1.Dispose ( );
				configs         = null;
				CandyFXsettings = null;
				GlobalSettings  = null;
				GameSettings    = null;
				Close ( );
				BringToFront ( "SettingsF" );
			}
		}

		private void BackgroundWorker1_DoWork ( object sender, DoWorkEventArgs e )
		{
			configs         = new ConfigFileReaderWriter ( );
			CandyFXsettings = configs.ReadConfigFile ( "CandyFX_settings.txt" );
			GlobalSettings  = configs.ReadConfigFile ( "Global_settings.txt" );

			var pathToGameS = Path.Combine ( Globals.RootDirectory, "user", "system.ini" );
			GameSettings = configs.ReadCoreIniSettings ( pathToGameS );
		}

		private void guna2Button1_Click ( object sender, EventArgs e )
		{
			backgroundWorker1.Dispose ( );
			configs         = null;
			CandyFXsettings = null;
			GlobalSettings  = null;
			GameSettings    = null;
			Close ( );
		}
	}
}
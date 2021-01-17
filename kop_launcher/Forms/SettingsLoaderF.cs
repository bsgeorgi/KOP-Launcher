using kop_launcher.ConfigReaders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace kop_launcher
{
	public partial class SettingsLoaderF : Form
	{
		private ConfigFileReaderWriter     _configs;
		private Dictionary<string, string> _candyFXsettings;
		private Dictionary<string, string> _globalSettings;
		private Dictionary<string, string> _gameSettings;
		private SettingsF                  _settingsForm;

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
				_settingsForm = new SettingsF ( _candyFXsettings, _globalSettings, _gameSettings );
				_settingsForm.Show ( );
				_settingsForm.IsOpen = true;

                DisposeForm();
				Close ( );
			}
			else
			{
                DisposeForm();
				BringToFront ( "SettingsF" );
			}
		}

        private void DisposeForm()
        {
            backgroundWorker1.Dispose();
            _configs = null;
            _candyFXsettings = null;
            _globalSettings = null;
            _gameSettings = null;
            Close();
		}

		private void BackgroundWorker1_DoWork ( object sender, DoWorkEventArgs e )
		{
            _configs         = new ConfigFileReaderWriter ( );
            _candyFXsettings = _configs.ReadConfigFile ( "CandyFX_settings.txt" );
            _globalSettings  = _configs.ReadConfigFile ( "Global_settings.txt" );

			var pathToGameS = Path.Combine ( Globals.RootDirectory, "user", "system.ini" );
            _gameSettings = _configs.ReadCoreIniSettings ( pathToGameS );
		}

		private void guna2Button1_Click ( object sender, EventArgs e )
		{
			backgroundWorker1.Dispose ( );
            _configs         = null;
            _candyFXsettings = null;
            _globalSettings  = null;
            _gameSettings    = null;
			Close ( );
		}
	}
}
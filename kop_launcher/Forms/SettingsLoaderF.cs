using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using kop_launcher.ConfigReaders;

namespace kop_launcher.Forms
{
	public partial class SettingsLoaderF : Form
	{
		private ConfigFileReaderWriter     _configs;
		private Dictionary<string, string> _gameSettings;
		private SettingsF                  _settingsForm;

		public SettingsLoaderF ( )
		{
			InitializeComponent ( );

			backgroundWorker1.DoWork             += BackgroundWorker1_DoWork;
			backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
			backgroundWorker1.RunWorkerAsync ( );
		}

		private static bool CheckOpened ( string name )
		{
			var fc = Application.OpenForms;
            return fc.Cast<Form> ( ).Any ( frm => frm.Name == name );
        }

		private static void BringToFront ( string name )
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
				_settingsForm = new SettingsF ( _gameSettings );
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
            _gameSettings = null;
		}

		private void BackgroundWorker1_DoWork ( object sender, DoWorkEventArgs e )
		{
            _configs         = new ConfigFileReaderWriter ( );

			var pathToGameS = Path.Combine ( Globals.RootDirectory, "user", "system.ini" );
            _gameSettings = _configs.ReadCoreIniSettings ( pathToGameS );
        }

		private void guna2Button1_Click ( object sender, EventArgs e )
		{
			backgroundWorker1.Dispose ( );
            _configs         = null;
            _gameSettings    = null;
			Close ( );
		}
    }
}
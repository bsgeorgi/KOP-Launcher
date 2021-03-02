using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using kop_launcher.ConfigReaders;

namespace kop_launcher.Forms
{
	public partial class SettingsF : Form
	{
		public  bool                       IsOpen;
		private Dictionary<string, string> _gameSettings;

		private bool  _gameSettingsChanged;
		private bool  _clientModificationsChanged;
		private bool  _cameraViewRangeChanged;
		private bool  _settingsMessageSaveShown;
		private short _cameraNum;

		public SettingsF ( Dictionary<string, string> gameSettings )
		{
			InitializeComponent ( );
			_gameSettings    = gameSettings;
		}

		private void SettingsF_Load ( object sender, EventArgs e )
		{
			LoadCurrentSettings ( );
			_gameSettingsChanged        = false;
			_clientModificationsChanged = false;
			_cameraViewRangeChanged     = false;
			_settingsMessageSaveShown   = false;
		}

		private void LoadCurrentSettings ( )
		{
			if ( _gameSettings.Count == 0 )
			{
				Utils.ShowMessageA ( "En error occurred during the initialisation of core app components:\n" +
									 "Error code: scfle, 1" );
				Close ( );
			}
			else
			{
				var coreGameSettings = new string[12];
				for ( var i = 0; i < coreGameSettings.Length; i++ )
                    coreGameSettings[i] = "";

				var hasSettings = true;

				hasSettings &= _gameSettings.TryGetValue ( "musicSound", out coreGameSettings[0] );
				hasSettings &= _gameSettings.TryGetValue ( "musicEffect", out coreGameSettings[1] );
				hasSettings &= _gameSettings.TryGetValue ( "fullScreen", out coreGameSettings[2] );
				hasSettings &= _gameSettings.TryGetValue ( "pixel1024", out coreGameSettings[3] );
				hasSettings &= _gameSettings.TryGetValue ( "depth32", out coreGameSettings[4] );
				hasSettings &= _gameSettings.TryGetValue ( "apparel", out coreGameSettings[5] );
				hasSettings &= _gameSettings.TryGetValue ( "effect", out coreGameSettings[6] );
				hasSettings &= _gameSettings.TryGetValue ( "state", out coreGameSettings[7] );
				hasSettings &= _gameSettings.TryGetValue ( "quality", out coreGameSettings[8] );
				hasSettings &= _gameSettings.TryGetValue ( "frames", out coreGameSettings[9] );
				hasSettings &= _gameSettings.TryGetValue ( "stalls", out coreGameSettings[10] );
                hasSettings &= _gameSettings.TryGetValue( "numericPanel", out coreGameSettings[11]);

                foreach (var value in coreGameSettings)
                {
                    MessageBox.Show ( value );
                }

				if ( hasSettings )
				{
					try
					{
                        if (coreGameSettings[2] != "0")
                            guna2CustomCheckBox2.Checked = true;
                        if (coreGameSettings[3] != "0")
                            guna2CustomCheckBox1.Checked = true;
                        if (coreGameSettings[4] != "0")
                            guna2CustomCheckBox4.Checked = true;
                        if (coreGameSettings[5] != "0")
                            guna2CustomCheckBox5.Checked = true;
                        if (coreGameSettings[6] != "0")
                            guna2CustomCheckBox6.Checked = true;
                        if (coreGameSettings[7] != "0")
                            guna2CustomCheckBox10.Checked = true;
                        if (coreGameSettings[8] == "0")
                            guna2CustomCheckBox7.Checked = true;
                        if (coreGameSettings[9] != "0")
                            guna2CustomCheckBox3.Checked = true;
                        if (coreGameSettings[10] != "0")
                            guna2CustomCheckBox13.Checked = true;
                        if (coreGameSettings[11] != "0")
                            guna2CustomCheckBox14.Checked = true;

						var cam = new CameraHandler ( );
						switch ( cam.GetCurrentCameraConfig ( ) )
						{
							case 1:
								cameraLowCheckbox.Checked = true;
								_cameraNum                = 1;
								break;
							case 2:
								cameraMedCheckbox.Checked = true;
								_cameraNum                = 2;
								break;
							case 3:
								cameraHighCheckbox.Checked = true;
								_cameraNum                 = 3;
								break;
							case 4:
								cameraUHighCheckbox.Checked = true;
								_cameraNum                  = 4;
								break;
							default:
								cameraMedCheckbox.Checked = true;
								_cameraNum                = 2;
								break;
						}

						if ( cam.IsAnimationTweaked ( ) )
							guna2CustomCheckBox11.Checked = true;

						if ( Globals.RenderNotification )
							guna2CustomCheckBox12.Checked = true;
					}
					catch
					{
						Utils.ShowMessageA ( "En error occurred during the initialisation of core app components:\n" +
											 "Error code: scflecX" );
						Close ( );
					}
				}
				else
				{
					Utils.ShowMessageA ( "En error occurred during the initialisation of core app components:\n" +
										 "Error code: scflecc" );
					Close ( );
				}
			}

			ApplyButton.UseWaitCursor = false;
			ResetButton.UseWaitCursor = false;

			ApplyButton.Cursor = Cursors.Hand;
			ResetButton.Cursor = Cursors.Hand;
		}

        private void guna2CustomCheckBox1_CheckedChanged ( object sender, EventArgs e )
		{
			if ( !( sender is Guna2CustomCheckBox ck ) )
				return;

			ck.ShadowDecoration.Enabled = ck.Checked;

			var globalVal = "0";
			var quality   = "1";

			if ( ck.Checked && ck.Name != "guna2CustomCheckBox7" )
				globalVal = "1";

			if ( ck.Checked && ck.Name == "guna2CustomCheckBox7" )
				quality = "0";

			switch ( ck.Name )
			{
				case "guna2CustomCheckBox2":
					_gameSettings["fullScreen"] = globalVal;
					_gameSettingsChanged        = true;
					break;
				case "guna2CustomCheckBox1":
					_gameSettings["pixel1024"] = globalVal;
					_gameSettingsChanged       = true;
					break;
				case "guna2CustomCheckBox3":
					_gameSettings["frames"] = globalVal;
					_gameSettingsChanged    = true;
					break;
				case "guna2CustomCheckBox4":
					_gameSettings["depth32"] = globalVal;
					_gameSettingsChanged     = true;
					break;
				case "guna2CustomCheckBox5":
					_gameSettings["apparel"] = globalVal;
					_gameSettingsChanged     = true;
					break;
				case "guna2CustomCheckBox6":
					_gameSettings["effect"] = globalVal;
					_gameSettingsChanged    = true;
					break;
				case "guna2CustomCheckBox7":
					_gameSettings["quality"] = quality;
					_gameSettingsChanged     = true;
					break;
				case "guna2CustomCheckBox10":
					_gameSettings["state"] = globalVal;
					_gameSettingsChanged   = true;
					break;
				case "guna2CustomCheckBox13":
					_gameSettings["stalls"] = globalVal;
					_gameSettingsChanged    = true;
					break;
                case "guna2CustomCheckBox14":
                    _gameSettings["numericPanel"] = globalVal;
                    _gameSettingsChanged = true;
                    break;

				case "guna2CustomCheckBox11":
					_clientModificationsChanged = true;
					break;
			}
		}

		private void guna2CustomRadioButton1_CheckedChanged ( object sender, EventArgs e )
		{
            if ( !(sender is Guna2CustomRadioButton rb) ) return;

			rb.ShadowDecoration.Enabled = rb.Checked;

			if ( rb.Checked && rb.Name == "cameraLowCheckbox" ) _cameraNum   = 1;
			if ( rb.Checked && rb.Name == "cameraMedCheckbox" ) _cameraNum   = 2;
			if ( rb.Checked && rb.Name == "cameraHighCheckbox" ) _cameraNum  = 3;
			if ( rb.Checked && rb.Name == "cameraUHighCheckbox" ) _cameraNum = 4;

			_cameraViewRangeChanged = true;
		}

        private void ResetToDefault ( )
		{
			cameraMedCheckbox.Checked = true;
			var @checked   = new[] { 1, 2, 3, 5, 6, 7, 10, 13 };
			var @unchecked = new[] { 4, 11, 12 };

			foreach ( var i in @checked )
			{
				if ( Controls.Find ( $"guna2CustomCheckBox{i}", true ).FirstOrDefault ( ) is Guna2CustomCheckBox cbx
					 && !cbx.Checked )
					cbx.Checked = true;
			}

			foreach ( var i in @unchecked )
			{
				if ( Controls.Find ( $"guna2CustomCheckBox{i}", true ).FirstOrDefault ( ) is Guna2CustomCheckBox cbx
					 && cbx.Checked )
					cbx.Checked = false;
			}

			Utils.ShowMessageA ( "Your settings have been reset to the default configurations." );
		}

		private void ResetButton_Click ( object sender, EventArgs e )
        {
            if ( !Utils.ShowMessageOK ( "Are you sure you would like to reset the settings back to the default configurations?" ) ) return;

            ResetToDefault ( );
            SaveSettings ( );
        }

		private void ShowSuccessSave ( )
		{
			label31.Visible = true;
			var t = new Timer
			{
				Interval = 3000 // it will Tick in 3 seconds
			};
			t.Tick += ( s, e ) =>
			{
				label31.Hide ( );
				t.Stop ( );
			};
			t.Start ( );
		}

		private void ApplyButton_Click ( object sender, EventArgs e )
		{
			SaveSettings ( );
		}

		private void SaveSettings ( )
		{
			var cfg   = new ConfigFileReaderWriter ( );
			var ret   = true;
			var count = 0;

			if ( _cameraViewRangeChanged )
			{
				++count;
				if ( !cfg.OverrideCamera ( _cameraNum ) ) ret = false;
			}

			if ( _clientModificationsChanged )
			{
				++count;
				if ( guna2CustomCheckBox11.Checked )
				{
					if ( !cfg.OverrideAnimations( false ) ) ret = false;
				}
				else
				{
					if ( !cfg.OverrideAnimations( true ) ) ret = false;
				}
			}

			if ( _gameSettingsChanged )
			{
				++count;
				if ( !cfg.SaveGameSettings ( _gameSettings ) ) ret = false;
			}
		

			switch (count)
            {
                case 0 when _settingsMessageSaveShown:
                    break;
                case 0 when Utils.ShowMessageOK ( "Could not detect any changes, would you like to close this window?" ):
                    DisposeAll ( );
                    Close ( );
                    break;
                case 0:
                    _settingsMessageSaveShown = true;
                    break;
                default:
                {
                    if ( ret )
                    {
                        ShowSuccessSave ( );
                        if ( _gameSettingsChanged || _cameraViewRangeChanged )
                            if ( Globals.IsGameRunning ( ) )
                                if ( Utils.ShowMessageOK (
                                    "Due to certain configuration changes, KOP game needs to be restarted.\nWould you" +
                                    " like to restart all game instances using the last recorded region?" ) )
                                    Globals.RestartGameInstances ( );
                    }
                    else
                    {
                        Utils.ShowMessageA ( "An error occurred while saving one of your configurations." );
                    }

                    break;
                }
            }
		}

		private void DisposeAll ( )
		{
			_gameSettings    = null;
		}

		private void SettingsF_FormClosing ( object sender, FormClosingEventArgs e )
		{
			IsOpen = false;
		}

        private void label34_Click_1(object sender, EventArgs e)
        {
            Utils.OpenGameLoginsForm();
        }
    }
}
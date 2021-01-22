using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using kop_launcher.ConfigReaders;

namespace kop_launcher
{
	public partial class SettingsF : Form
	{
		public  bool                       IsOpen;
		private Dictionary<string, string> _candyFxSettings;
		private Dictionary<string, string> _globalSettings;
		private Dictionary<string, string> _gameSettings;
		private int                        _bindedKeyToScreen = 123;

		private bool  _gameSettingsChanged;
		private bool  _candyFxSettingsChanged;
		private bool  _globalSettingsChanged;
		private bool  _clientModificationsChanged;
		private bool  _cameraViewRangeChanged;
		private bool  _settingsMessageSaveShown;
		private short _cameraNum;

		public SettingsF ( Dictionary<string, string> candyFxSettings,
						   Dictionary<string, string> globalSettings,
						   Dictionary<string, string> gameSettings )
		{
			InitializeComponent ( );
			_candyFxSettings = candyFxSettings;
			_globalSettings  = globalSettings;
			_gameSettings    = gameSettings;
		}

		private void SettingsF_Load ( object sender, EventArgs e )
		{
			LoadCurrentSettings ( );
			_gameSettingsChanged        = false;
			_candyFxSettingsChanged     = false;
			_globalSettingsChanged      = false;
			_clientModificationsChanged = false;
			_cameraViewRangeChanged     = false;
			_settingsMessageSaveShown   = false;
		}

		private void LoadCurrentSettings ( )
		{
			if ( _candyFxSettings.Count == 0 )
			{
				Utils.ShowMessageA ( "En error occurred during the initialisation of core app components:\n" +
									 "Error code: scfle, 1" );
				Close ( );
			}
			else
			{
				var candyFxSettingsArr = new string[26];
				for ( var i = 0; i < 26; i++ )
					candyFxSettingsArr[i] = "";
				var hasSettings = true;

				hasSettings &= _candyFxSettings.TryGetValue ( "USE_SMAA_ANTIALIASING", out candyFxSettingsArr[0] );
				hasSettings &= _candyFxSettings.TryGetValue ( "USE_BLOOM", out candyFxSettingsArr[1] );
				hasSettings &= _candyFxSettings.TryGetValue ( "USE_LUMASHARPEN", out candyFxSettingsArr[2] );
				hasSettings &= _candyFxSettings.TryGetValue ( "USE_GAUSSIAN", out candyFxSettingsArr[3] );
				hasSettings &= _candyFxSettings.TryGetValue ( "USE_LIFTGAMMAGAIN", out candyFxSettingsArr[4] );
				hasSettings &= _candyFxSettings.TryGetValue ( "USE_TONEMAP", out candyFxSettingsArr[5] );
				hasSettings &= _candyFxSettings.TryGetValue ( "USE_VIBRANCE", out candyFxSettingsArr[6] );
				hasSettings &= _candyFxSettings.TryGetValue ( "USE_CURVES", out candyFxSettingsArr[7] );
				hasSettings &= _candyFxSettings.TryGetValue ( "USE_DITHER", out candyFxSettingsArr[8] );

				hasSettings &= _candyFxSettings.TryGetValue ( "Gamma", out candyFxSettingsArr[9] );
				hasSettings &= _candyFxSettings.TryGetValue ( "Exposure", out candyFxSettingsArr[10] );
				hasSettings &= _candyFxSettings.TryGetValue ( "BloomThreshold", out candyFxSettingsArr[11] );
				hasSettings &= _candyFxSettings.TryGetValue ( "Curves_contrast", out candyFxSettingsArr[12] );

				hasSettings &= _globalSettings.TryGetValue ( "ReShade_Start_Enabled", out candyFxSettingsArr[13] );
				hasSettings &= _globalSettings.TryGetValue ( "ReShade_ShowFPS", out candyFxSettingsArr[14] );

				hasSettings &= _gameSettings.TryGetValue ( "musicSound", out candyFxSettingsArr[15] );
				hasSettings &= _gameSettings.TryGetValue ( "musicEffect", out candyFxSettingsArr[16] );
				hasSettings &= _gameSettings.TryGetValue ( "fullScreen", out candyFxSettingsArr[17] );
				hasSettings &= _gameSettings.TryGetValue ( "pixel1024", out candyFxSettingsArr[18] );
				hasSettings &= _gameSettings.TryGetValue ( "depth32", out candyFxSettingsArr[19] );
				hasSettings &= _gameSettings.TryGetValue ( "apparel", out candyFxSettingsArr[20] );
				hasSettings &= _gameSettings.TryGetValue ( "effect", out candyFxSettingsArr[21] );
				hasSettings &= _gameSettings.TryGetValue ( "state", out candyFxSettingsArr[22] );
				hasSettings &= _gameSettings.TryGetValue ( "quality", out candyFxSettingsArr[23] );
				hasSettings &= _gameSettings.TryGetValue ( "frames", out candyFxSettingsArr[24] );
				hasSettings &= _gameSettings.TryGetValue ( "stalls", out candyFxSettingsArr[25] );

				if ( hasSettings )
				{
					try
					{
						for ( var i = 0; i < 9; i++ )
							if ( candyFxSettingsArr[i] == "1" )
							{
								var cbx = Controls.Find ( $"CoreSettings{i}", true )
												  .FirstOrDefault ( ) as Guna2CustomCheckBox;
								cbx.Checked = true;
							}

						/* Initialise sliders 
                         * Gamma 0.000 - 2.000
                         * Exposure -1.000 to 1.000
                         * Bloom 0.00 to 50.00
                         * Curves Contrast -1.00 to 1.00
                         */

						// Calculate Bloom
						var bloomValue = ConvertToValue ( candyFxSettingsArr[11], 50, 0, 0, 100 );
						BthresScrollbar.Value = bloomValue;
						bloomTLabel.Text      = ConvertToString ( bloomValue, 100, 0, 0, 50 );

						// Calculate Exposure and Contrast Same formula
						var exposureValue = ConvertNegativeX ( candyFxSettingsArr[10] );
						ExpScrollbar.Value = exposureValue;
						expLabel.Text      = ConvertToStringX ( exposureValue );

						var contrastValue = ConvertNegativeX ( candyFxSettingsArr[12] );
						CurvesScrollbar.Value = contrastValue;
						CurvesCLabel.Text     = ConvertToStringX ( contrastValue );

						// Calculate Gamma
						var gammaValue = ConvertToValue ( candyFxSettingsArr[9], 2, 0, 0, 100 );
						GammaScrollbar.Value = gammaValue;
						gammaLabel.Text      = ConvertToString ( gammaValue );

						if ( candyFxSettingsArr[13] == "1" )
							guna2CustomCheckBox9.Checked = true;
						if ( candyFxSettingsArr[14] == "1" )
							guna2CustomCheckBox8.Checked = true;
						if ( candyFxSettingsArr[17] != "0" )
							guna2CustomCheckBox2.Checked = true;
						if ( candyFxSettingsArr[18] != "0" )
							guna2CustomCheckBox1.Checked = true;
						if ( candyFxSettingsArr[19] != "0" )
							guna2CustomCheckBox4.Checked = true;
						if ( candyFxSettingsArr[20] != "0" )
							guna2CustomCheckBox5.Checked = true;
						if ( candyFxSettingsArr[21] != "0" )
							guna2CustomCheckBox6.Checked = true;
						if ( candyFxSettingsArr[22] != "0" )
							guna2CustomCheckBox10.Checked = true;
						if ( candyFxSettingsArr[23] == "0" )
							guna2CustomCheckBox7.Checked = true;
						if ( candyFxSettingsArr[24] != "0" )
							guna2CustomCheckBox3.Checked = true;
						if ( candyFxSettingsArr[25] != "0" )
							guna2CustomCheckBox13.Checked = true;

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

		private static int ConvertToValue ( string value,
											int OldMax = -1,
											int OldMin = 1,
											int newMin = 1,
											int newMax = 2 )
		{
			var    val = Convert.ToDouble ( value );
			double ret;

			if ( OldMin != OldMax && newMin != newMax )
				ret = ( val - OldMin ) / ( OldMax - OldMin ) * ( newMax - newMin ) + newMin;
			else
				ret = 1.0 * ( newMax + newMin ) / 2;

			return (int) Math.Round ( ret );
		}

		private static string ConvertToString ( int value,
												int OldMax = 100,
												int OldMin = 0,
												int newMin = 0,
												int newMax = 2 )
		{
			double ret;
			double temp = value;

			if ( OldMin != OldMax && newMin != newMax )
				ret = ( temp - OldMin ) / ( OldMax - OldMin ) * ( newMax - newMin ) + newMin;
			else
				ret = 1.0 * ( newMax + newMin ) / 2;

			ret = Math.Round ( ret, 2 );

			return $"{ret}";
		}

		private static int ConvertNegativeX ( string value )
		{
			var    val = Convert.ToDouble ( value );
			double ret = 50;

			if ( val == 0 )
				return (int) ret;
			var temporary = Math.Round ( ( val + 1 ) / 2 * 100 );

			return (int) temporary;
		}

		private string ConvertToStringX ( int value )
		{
			double d = value;

			return $"{Math.Round ( d / 100 * 2 - 1, 2 )}";
		}

		private void ToAdvancedBtn_MouseEnter ( object sender, EventArgs e )
		{
			if ( sender is Label s )
				s.ForeColor = Color.FromArgb ( 114, 175, 236 );
		}

		private void ToAdvancedBtn_MouseLeave ( object sender, EventArgs e )
		{
			if ( sender is Label s )
				s.ForeColor = Color.FromArgb ( 93, 155, 216 );
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
				case "guna2CustomCheckBox9":
					_globalSettings["ReShade_Start_Enabled"] = globalVal;
					_globalSettingsChanged                   = true;
					break;
				case "guna2CustomCheckBox8":
					_globalSettings["ReShade_ShowFPS"] = globalVal;
					_globalSettingsChanged             = true;
					break;
				case "guna2CustomCheckBox12":
					_globalSettingsChanged = true;
					break;

				case "CoreSettings0":
					_candyFxSettings["USE_SMAA_ANTIALIASING"] = globalVal;
					_candyFxSettingsChanged                   = true;
					break;
				case "CoreSettings1":
					_candyFxSettings["USE_BLOOM"] = globalVal;
					_candyFxSettingsChanged       = true;
					break;
				case "CoreSettings2":
					_candyFxSettings["USE_LUMASHARPEN"] = globalVal;
					_candyFxSettingsChanged             = true;
					break;
				case "CoreSettings3":
					_candyFxSettings["USE_GAUSSIAN"] = globalVal;
					_candyFxSettingsChanged          = true;
					break;
				case "CoreSettings4":
					_candyFxSettings["USE_LIFTGAMMAGAIN"] = globalVal;
					_candyFxSettingsChanged               = true;
					break;
				case "CoreSettings5":
					_candyFxSettings["USE_TONEMAP"] = globalVal;
					_candyFxSettingsChanged         = true;
					break;
				case "CoreSettings6":
					_candyFxSettings["USE_VIBRANCE"] = globalVal;
					_candyFxSettingsChanged          = true;
					break;
				case "CoreSettings7":
					_candyFxSettings["USE_CURVES"] = globalVal;
					_candyFxSettingsChanged        = true;
					break;
				case "CoreSettings8":
					_candyFxSettings["USE_DITHER"] = globalVal;
					_candyFxSettingsChanged        = true;
					break;

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

				case "guna2CustomCheckBox11":
					_clientModificationsChanged = true;
					break;
			}
		}

		private void guna2CustomRadioButton1_CheckedChanged ( object sender, EventArgs e )
		{
			var rb = sender as Guna2CustomRadioButton;
			if ( rb.Checked )
				rb.ShadowDecoration.Enabled = true;
			else
				rb.ShadowDecoration.Enabled = false;

			if ( rb.Checked && rb.Name == "cameraLowCheckbox" ) _cameraNum   = 1;
			if ( rb.Checked && rb.Name == "cameraMedCheckbox" ) _cameraNum   = 2;
			if ( rb.Checked && rb.Name == "cameraHighCheckbox" ) _cameraNum  = 3;
			if ( rb.Checked && rb.Name == "cameraUHighCheckbox" ) _cameraNum = 4;

			_cameraViewRangeChanged = true;
		}

		private void guna2TextBox1_KeyDown ( object sender, KeyEventArgs e )
		{
			e.SuppressKeyPress = true;
			guna2TextBox1.Text = e.KeyCode.ToString ( );
			_bindedKeyToScreen = e.KeyValue;
		}

		private void GammaScrollbar_Scroll ( object sender, ScrollEventArgs e )
		{
			var convertedGamma = ConvertToString ( GammaScrollbar.Value );
			if ( convertedGamma.Contains ( "," ) )
				convertedGamma = convertedGamma.Replace ( ",", "." );

			gammaLabel.Text           = convertedGamma;
			_candyFxSettings["Gamma"] = convertedGamma;
			_candyFxSettingsChanged   = true;
		}

		private void ExpScrollbar_Scroll ( object sender, ScrollEventArgs e )
		{
			var convertedExposure = ConvertToStringX ( ExpScrollbar.Value );
			if ( convertedExposure.Contains ( "," ) )
				convertedExposure = convertedExposure.Replace ( ",", "." );

			expLabel.Text                = convertedExposure;
			_candyFxSettings["Exposure"] = convertedExposure;
			_candyFxSettingsChanged      = true;
		}

		private void BthresScrollbar_Scroll ( object sender, ScrollEventArgs e )
		{
			var convertedBloom = ConvertToString ( BthresScrollbar.Value, 100, 0, 0, 50 );
			if ( convertedBloom.Contains ( "," ) )
				convertedBloom = convertedBloom.Replace ( ",", "." );

			bloomTLabel.Text                   = convertedBloom;
			_candyFxSettings["BloomThreshold"] = convertedBloom;
			_candyFxSettingsChanged            = true;
		}

		private void CurvesScrollbar_Scroll ( object sender, ScrollEventArgs e )
		{
			var convertedCurves = ConvertToStringX ( CurvesScrollbar.Value );
			if ( convertedCurves.Contains ( "," ) )
				convertedCurves = convertedCurves.Replace ( ",", "." );

			CurvesCLabel.Text                   = convertedCurves;
			_candyFxSettings["Curves_contrast"] = convertedCurves;
			_candyFxSettingsChanged             = true;
		}

		private void ResetToDefault ( )
		{
			cameraMedCheckbox.Checked = true;
			var @checked   = new[] {1, 2, 3, 5, 6, 7, 9};
			var @unchecked = new[] {4, 8};

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

			for ( var i = 0; i < 9; i++ )
			{
				if ( Controls.Find ( $"CoreSettings{i}", true ).FirstOrDefault ( ) is Guna2CustomCheckBox cbx
					 && !cbx.Checked )
					cbx.Checked = true;
			}

			GammaScrollbar.Value = 70;
			gammaLabel.Text      = "1.4";

			ExpScrollbar.Value = 35;
			expLabel.Text      = "-0.3";

			BthresScrollbar.Value = 42;
			bloomTLabel.Text      = "21";

			CurvesScrollbar.Value = 60;
			CurvesCLabel.Text     = "0.2";

			guna2CustomCheckBox12.Checked = true;
			guna2CustomCheckBox11.Checked = false;

			Utils.ShowMessageA ( "Your settings have been reset to the default configurations." );
		}

		private void ResetButton_Click ( object sender, EventArgs e )
		{
			if ( Utils.ShowMessageOK (
				"Are you sure you would like to reset the settings back to the default configurations?" ) )
			{
				ResetToDefault ( );
				SaveSettings ( );
			}
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
					if ( !cfg.OverrideCamera ( false ) ) ret = false;
				}
				else
				{
					if ( !cfg.OverrideCamera ( true ) ) ret = false;
				}
			}

			if ( _gameSettingsChanged )
			{
				++count;
				if ( !cfg.SaveGameSettings ( _gameSettings ) ) ret = false;
			}

			if ( _globalSettingsChanged )
			{
				++count;
				// Update Launcher Settings
				if ( !guna2CustomCheckBox12.Checked )
					Globals.RenderNotification = false;

				var globalPath = Path.Combine ( Globals.RootDirectory, "system", "CandyFX", "Global_settings.txt" );
				if ( !cfg.SaveConfigFile ( globalPath, _globalSettings ) )
					ret = false;
			}

			if ( _candyFxSettingsChanged )
			{
				++count;
				var candyPath = Path.Combine ( Globals.RootDirectory, "system", "CandyFX", "CandyFX_settings.txt" );
				if ( !cfg.SaveConfigFile ( candyPath, _candyFxSettings ) ) ret = false;
			}

			if ( count == 0 && _settingsMessageSaveShown ) { }

			else if ( count == 0 )
			{
				if ( Utils.ShowMessageOK ( "Could not detect any changes, would you like to close this window?" ) )
				{
					DisposeAll ( );
					Close ( );
				}
				else
				{
					_settingsMessageSaveShown = true;
				}
			}
			else
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
			}
		}

		private void DisposeAll ( )
		{
			_candyFxSettings = null;
			_globalSettings  = null;
			_gameSettings    = null;
		}

		private void SettingsF_FormClosing ( object sender, FormClosingEventArgs e )
		{
			IsOpen = false;
		}

        private void label34_Click(object sender, EventArgs e)
        {
            Utils.OpenGameLoginsForm();
        }

        private void label34_Click_1(object sender, EventArgs e)
        {
            Utils.OpenGameLoginsForm();
        }
    }
}
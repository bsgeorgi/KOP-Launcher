using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace kop_launcher
{
    public partial class SettingsF : Form
    {
        public bool IsOpen;
        private Dictionary<string, string> CandyFXSettings;
        private Dictionary<string, string> GlobalSettings;
        private Dictionary<string, string> GameSettings;
        private Utils utils = new Utils();
        private int BindedKeyToScreen = 123;

        private bool GameSettingsChanged;
        private bool CandyFXSettingsChanged;
        private bool GlobalSettingsChanged;
        private bool ClientModificationsChanged;
        private bool CameraViewRangeChanged;
        private bool SettingsMessageSaveShown;
        private short CameraNum = 0;

        public SettingsF(Dictionary<string, string> candyFxSettings, 
                         Dictionary<string, string> globalSettings,
                         Dictionary<string, string> gameSettings)
        {
            InitializeComponent();
            CandyFXSettings = candyFxSettings;
            GlobalSettings  = globalSettings;
            GameSettings    = gameSettings;
        }
        private void SettingsF_Load(object sender, System.EventArgs e)
        {
            LoadCurrentSettings();
            GameSettingsChanged = false;
            CandyFXSettingsChanged = false;
            GlobalSettingsChanged = false;
            ClientModificationsChanged = false;
            CameraViewRangeChanged = false;
            SettingsMessageSaveShown = false;
        }

        private void LoadCurrentSettings()
        {
            if (CandyFXSettings.Count == 0)
            {
                utils.ShowMessageA("En error occured during the initialisation of core app components:\n" +
                    "Error code: scfle, 1");
                Close();
            }
            else
            {
                string[] CandyFXSettingsArr = new string[26];
                for (int i = 0; i < 26; i++)
                {
                    CandyFXSettingsArr[i] = "";
                }

                bool AntiAliasingB      = CandyFXSettings.TryGetValue("USE_SMAA_ANTIALIASING", out CandyFXSettingsArr[0]);
                bool BloomB             = CandyFXSettings.TryGetValue("USE_BLOOM", out CandyFXSettingsArr[1]);
                bool SmartSharpenB      = CandyFXSettings.TryGetValue("USE_LUMASHARPEN", out CandyFXSettingsArr[2]);
                bool GuassianBlurB      = CandyFXSettings.TryGetValue("USE_GAUSSIAN", out CandyFXSettingsArr[3]);
                bool LifeGammaGrainB    = CandyFXSettings.TryGetValue("USE_LIFTGAMMAGAIN", out CandyFXSettingsArr[4]);
                bool TonemapB           = CandyFXSettings.TryGetValue("USE_TONEMAP", out CandyFXSettingsArr[5]);
                bool VibranceB          = CandyFXSettings.TryGetValue("USE_VIBRANCE", out CandyFXSettingsArr[6]);
                bool SCurvesB           = CandyFXSettings.TryGetValue("USE_CURVES", out CandyFXSettingsArr[7]);
                bool DitherB            = CandyFXSettings.TryGetValue("USE_DITHER", out CandyFXSettingsArr[8]);

                bool GammaB             = CandyFXSettings.TryGetValue("Gamma", out CandyFXSettingsArr[9]);
                bool ExposureB          = CandyFXSettings.TryGetValue("Exposure", out CandyFXSettingsArr[10]);
                bool BloomThresholdB    = CandyFXSettings.TryGetValue("BloomThreshold", out CandyFXSettingsArr[11]);
                bool CurvesContrastB    = CandyFXSettings.TryGetValue("Curves_contrast", out CandyFXSettingsArr[12]);

                bool PostProcEnabledB   = GlobalSettings.TryGetValue("ReShade_Start_Enabled", out CandyFXSettingsArr[13]);
                bool ShowFPSB           = GlobalSettings.TryGetValue("ReShade_ShowFPS", out CandyFXSettingsArr[14]);

                bool musicSound         = GameSettings.TryGetValue("musicSound", out CandyFXSettingsArr[15]);
                bool musicEffect        = GameSettings.TryGetValue("musicEffect", out CandyFXSettingsArr[16]);
                bool fullScreen         = GameSettings.TryGetValue("fullScreen", out CandyFXSettingsArr[17]);
                bool pixel1024          = GameSettings.TryGetValue("pixel1024", out CandyFXSettingsArr[18]);
                bool depth32            = GameSettings.TryGetValue("depth32", out CandyFXSettingsArr[19]);
                bool apparel            = GameSettings.TryGetValue("apparel", out CandyFXSettingsArr[20]);
                bool effect             = GameSettings.TryGetValue("effect", out CandyFXSettingsArr[21]);
                bool state              = GameSettings.TryGetValue("state", out CandyFXSettingsArr[22]);
                bool quality            = GameSettings.TryGetValue("quality", out CandyFXSettingsArr[23]);
                bool frames             = GameSettings.TryGetValue("frames", out CandyFXSettingsArr[24]);
                bool stalls             = GameSettings.TryGetValue("stalls", out CandyFXSettingsArr[25]);

                if (AntiAliasingB && BloomB && SmartSharpenB && GuassianBlurB && LifeGammaGrainB && TonemapB && VibranceB
                    && SCurvesB && DitherB && GammaB && ExposureB && BloomThresholdB && CurvesContrastB 
                    && PostProcEnabledB && ShowFPSB
                    && musicSound && musicEffect && fullScreen && pixel1024 && depth32 && apparel && effect && state 
                    && quality && frames && stalls)
                {
                    try
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            if (CandyFXSettingsArr[i] == "1")
                            {
                                Guna2CustomCheckBox cbx = Controls.Find(string.Format("CoreSettings{0}", i), true).FirstOrDefault() as Guna2CustomCheckBox;
                                cbx.Checked = true;
                            }
                        }

                        /* Initialise sliders 
                         * Gamma 0.000 - 2.000
                         * Exposure -1.000 to 1.000
                         * Bloom 0.00 to 50.00
                         * Curves Contrast -1.00 to 1.00
                         */

                        // Calculate Bloom
                        int bloomValue = ConvertToValue(CandyFXSettingsArr[11], 50, 0, 0, 100);
                        BthresScrollbar.Value = bloomValue;
                        bloomTLabel.Text = ConvertToString(bloomValue, 100, 0, 0, 50);

                        // Calculate Exposure and Contrast Same formula
                        int exposureValue = ConvertNegativeX(CandyFXSettingsArr[10]);
                        ExpScrollbar.Value = exposureValue;
                        expLabel.Text = ConvertToStringX(exposureValue);

                        int contrastValue = ConvertNegativeX(CandyFXSettingsArr[12]);
                        CurvesScrollbar.Value = contrastValue;
                        CurvesCLabel.Text = ConvertToStringX(contrastValue);

                        // Calculate Gamma
                        int gammaValue = ConvertToValue(CandyFXSettingsArr[9], 2, 0, 0, 100);
                        GammaScrollbar.Value = gammaValue;
                        gammaLabel.Text = ConvertToString(gammaValue, 100, 0, 0, 2);

                        if (CandyFXSettingsArr[13] == "1")
                            guna2CustomCheckBox9.Checked = true;
                        if (CandyFXSettingsArr[14] == "1")
                            guna2CustomCheckBox8.Checked = true;
                        if (CandyFXSettingsArr[17] != "0")
                            guna2CustomCheckBox2.Checked = true;
                        if (CandyFXSettingsArr[18] != "0")
                            guna2CustomCheckBox1.Checked = true;
                        if (CandyFXSettingsArr[19] != "0")
                            guna2CustomCheckBox4.Checked = true;
                        if (CandyFXSettingsArr[20] != "0")
                            guna2CustomCheckBox5.Checked = true;
                        if (CandyFXSettingsArr[21] != "0")
                            guna2CustomCheckBox6.Checked = true;
                        if (CandyFXSettingsArr[22] != "0")
                            guna2CustomCheckBox10.Checked = true;
                        if (CandyFXSettingsArr[23] == "0")
                            guna2CustomCheckBox7.Checked = true;
                        if (CandyFXSettingsArr[24] != "0")
                            guna2CustomCheckBox3.Checked = true;
                        if (CandyFXSettingsArr[25] != "0")
                            guna2CustomCheckBox13.Checked = true;

                        Camera cam = new Camera();
                        switch (cam.GetCurrentCameraConfig())
                        {
                            case 1:
                                cameraLowCheckbox.Checked = true;
                                CameraNum = 1;
                                break;
                            case 2:
                                cameraMedCheckbox.Checked = true;
                                CameraNum = 2;
                                break;
                            case 3:
                                cameraHighCheckbox.Checked = true;
                                CameraNum = 3;
                                break;
                            case 4:
                                cameraUHighCheckbox.Checked = true;
                                CameraNum = 4;
                                break;
                            default:
                                cameraMedCheckbox.Checked = true;
                                CameraNum = 2;
                                break;
                        }

                        if (cam.IsAnimationTweaked())
                            guna2CustomCheckBox11.Checked = true;

                        if (Globals.RenderNotification)
                            guna2CustomCheckBox12.Checked = true;
                    }
                    catch
                    {
                        utils.ShowMessageA("En error occured during the initialisation of core app components:\n" +
                            "Error code: scflecX");
                        Close();
                    }
                }
                else
                {
                    utils.ShowMessageA("En error occured during the initialisation of core app components:\n" +
                        "Error code: scflecc");
                    Close();
                }
            }
            ApplyButton.UseWaitCursor = false;
            ResetButton.UseWaitCursor = false;

            ApplyButton.Cursor = Cursors.Hand;
            ResetButton.Cursor = Cursors.Hand;
        }

        private int ConvertToValue(string value, int OldMax=-1, int OldMin=1, int newMin=1, int newMax=2)
        {
            double val = Convert.ToDouble(value);
            double ret = 0;

            if (OldMin != OldMax && newMin != newMax)
                ret = (val - OldMin) / (OldMax - OldMin) * (newMax - newMin) + newMin;
            else
                ret = (newMax + newMin) / 2;

            return (int)Math.Round(ret);
        }

        private string ConvertToString(int value, int OldMax=100, int OldMin=0, int newMin=0, int newMax=2)
        {
            double ret = 0;
            double temp = value;

            if (OldMin != OldMax && newMin != newMax)
                ret = (temp - OldMin) / (OldMax - OldMin) * (newMax - newMin) + newMin;
            else
                ret = (newMax + newMin) / 2;

            ret = Math.Round(ret, 2);

            return ret.ToString();
        }

        private int ConvertNegativeX(string value)
        {
            double val = Convert.ToDouble(value);
            double ret = 50;
            double temporary = 0;

            if (val == 0)
            {
                return (int)ret;
            }
            else if (val > 0)
            {
                temporary = Math.Round(((val + 1) / 2) * 100);
            }
            else
            {
                temporary = Math.Round(((val + 1) / 2)*100);
            }

            return (int) temporary;
        }

        private string ConvertToStringX(int value)
        {
            double Value = value;

            return Math.Round((Value / 100) * 2 - 1, 2).ToString();
        }

        private void ToAdvancedBtn_MouseEnter(object sender, System.EventArgs e)
        {
            Label s = sender as Label;
            s.ForeColor = Color.FromArgb(114, 175, 236);
        }

        private void ToAdvancedBtn_MouseLeave(object sender, System.EventArgs e)
        {
            Label s = sender as Label;
            s.ForeColor = Color.FromArgb(93, 155, 216);
        }

        private void guna2CustomCheckBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            Guna2CustomCheckBox ck = sender as Guna2CustomCheckBox;
            if (ck.Checked)
                ck.ShadowDecoration.Enabled = true;
            else
                ck.ShadowDecoration.Enabled = false;

            string globalVal = "0";
            string quality = "1";

            if (ck.Checked && ck.Name != "guna2CustomCheckBox7")
                globalVal = "1";

            if (ck.Checked && ck.Name == "guna2CustomCheckBox7")
                quality = "0";

            switch (ck.Name)
            {
                case "guna2CustomCheckBox9":
                    GlobalSettings["ReShade_Start_Enabled"] = globalVal;
                    GlobalSettingsChanged = true;
                    break;
                case "guna2CustomCheckBox8":
                    GlobalSettings["ReShade_ShowFPS"] = globalVal;
                    GlobalSettingsChanged = true;
                    break;
                case "guna2CustomCheckBox12":
                    GlobalSettingsChanged = true;
                    break;

                case "CoreSettings0":
                    CandyFXSettings["USE_SMAA_ANTIALIASING"] = globalVal;
                    CandyFXSettingsChanged = true;
                    break;
                case "CoreSettings1":
                    CandyFXSettings["USE_BLOOM"] = globalVal;
                    CandyFXSettingsChanged = true;
                    break;
                case "CoreSettings2":
                    CandyFXSettings["USE_LUMASHARPEN"] = globalVal;
                    CandyFXSettingsChanged = true;
                    break;
                case "CoreSettings3":
                    CandyFXSettings["USE_GAUSSIAN"] = globalVal;
                    CandyFXSettingsChanged = true;
                    break;
                case "CoreSettings4":
                    CandyFXSettings["USE_LIFTGAMMAGAIN"] = globalVal;
                    CandyFXSettingsChanged = true;
                    break;
                case "CoreSettings5":
                    CandyFXSettings["USE_TONEMAP"] = globalVal;
                    CandyFXSettingsChanged = true;
                    break;
                case "CoreSettings6":
                    CandyFXSettings["USE_VIBRANCE"] = globalVal;
                    CandyFXSettingsChanged = true;
                    break;
                case "CoreSettings7":
                    CandyFXSettings["USE_CURVES"] = globalVal;
                    CandyFXSettingsChanged = true;
                    break;
                case "CoreSettings8":
                    CandyFXSettings["USE_DITHER"] = globalVal;
                    CandyFXSettingsChanged = true;
                    break;

                case "guna2CustomCheckBox2":
                    GameSettings["fullScreen"] = globalVal;
                    GameSettingsChanged = true;
                    break;
                case "guna2CustomCheckBox1":
                    GameSettings["pixel1024"] = globalVal;
                    GameSettingsChanged = true;
                    break;
                case "guna2CustomCheckBox3":
                    GameSettings["frames"] = globalVal;
                    GameSettingsChanged = true;
                    break;
                case "guna2CustomCheckBox4":
                    GameSettings["depth32"] = globalVal;
                    GameSettingsChanged = true;
                    break;
                case "guna2CustomCheckBox5":
                    GameSettings["apparel"] = globalVal;
                    GameSettingsChanged = true;
                    break;
                case "guna2CustomCheckBox6":
                    GameSettings["effect"] = globalVal;
                    GameSettingsChanged = true;
                    break;
                case "guna2CustomCheckBox7":
                    GameSettings["quality"] = quality;
                    GameSettingsChanged = true;
                    break;
                case "guna2CustomCheckBox10":
                    GameSettings["state"] = globalVal;
                    GameSettingsChanged = true;
                    break;
                case "guna2CustomCheckBox13":
                    GameSettings["stalls"] = globalVal;
                    GameSettingsChanged = true;
                    break;

                case "guna2CustomCheckBox11":
                    ClientModificationsChanged = true;
                    break;

                default:
                    break;
            }
        }

        private void guna2CustomRadioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            Guna2CustomRadioButton rb = sender as Guna2CustomRadioButton;
            if (rb.Checked)
                rb.ShadowDecoration.Enabled = true;
            else
                rb.ShadowDecoration.Enabled = false;

            if (rb.Checked && rb.Name == "cameraLowCheckbox")
            {
                CameraNum = 1;
            }
            if (rb.Checked && rb.Name == "cameraMedCheckbox")
            {
                CameraNum = 2;
            }
            if (rb.Checked && rb.Name == "cameraHighCheckbox")
            {
                CameraNum = 3;
            }
            if (rb.Checked && rb.Name == "cameraUHighCheckbox")
            {
                CameraNum = 4;
            }

            CameraViewRangeChanged = true;
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            guna2TextBox1.Text = e.KeyCode.ToString();
            BindedKeyToScreen = e.KeyValue;
        }

        private void GammaScrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            var convertedGamma = ConvertToString(GammaScrollbar.Value, 100, 0, 0, 2);
            if (convertedGamma.Contains(","))
                convertedGamma = convertedGamma.Replace(",", ".");

            gammaLabel.Text = convertedGamma;
            CandyFXSettings["Gamma"] = convertedGamma;
            CandyFXSettingsChanged = true;
        }

        private void ExpScrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            var convertedExposure = ConvertToStringX(ExpScrollbar.Value);
            if (convertedExposure.Contains(","))
                convertedExposure = convertedExposure.Replace(",", ".");

            expLabel.Text = convertedExposure;
            CandyFXSettings["Exposure"] = convertedExposure;
            CandyFXSettingsChanged = true;
        }

        private void BthresScrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            var convertedBloom = ConvertToString(BthresScrollbar.Value, 100, 0, 0, 50);
            if (convertedBloom.Contains(","))
                convertedBloom = convertedBloom.Replace(",", ".");

            bloomTLabel.Text = convertedBloom;
            CandyFXSettings["BloomThreshold"] = convertedBloom;
            CandyFXSettingsChanged = true;
        }

        private void CurvesScrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            var convertedCurves = ConvertToStringX(CurvesScrollbar.Value);
            if (convertedCurves.Contains(","))
                convertedCurves = convertedCurves.Replace(",", ".");

            CurvesCLabel.Text = convertedCurves;
            CandyFXSettings["Curves_contrast"] = convertedCurves;
            CandyFXSettingsChanged = true;
        }

        private void ResetToDefault()
        {
            cameraMedCheckbox.Checked = true;
            int[] Checked = new int[] { 1, 2, 3, 5, 6, 7, 9 };
            int[] Unchecked = new int[] { 4, 8 };

            foreach (int i in Checked)
            {
                Guna2CustomCheckBox cbx = Controls.Find(string.Format("guna2CustomCheckBox{0}", i), true).FirstOrDefault() as Guna2CustomCheckBox;
                if (!cbx.Checked)
                    cbx.Checked = true;
            }
            foreach (int i in Unchecked)
            {
                Guna2CustomCheckBox cbx = Controls.Find(string.Format("guna2CustomCheckBox{0}", i), true).FirstOrDefault() as Guna2CustomCheckBox;
                if (cbx.Checked)
                    cbx.Checked = false;
            }
            for (int i = 0; i < 9; i++)
            {
                Guna2CustomCheckBox cbx = Controls.Find(string.Format("CoreSettings{0}", i), true).FirstOrDefault() as Guna2CustomCheckBox;
                if (!cbx.Checked)
                    cbx.Checked = true;
            }

            GammaScrollbar.Value    = 70;
            gammaLabel.Text         = "1.4";

            ExpScrollbar.Value      = 35;
            expLabel.Text           = "-0.3";

            BthresScrollbar.Value   = 42;
            bloomTLabel.Text        = "21";

            CurvesScrollbar.Value   = 60;
            CurvesCLabel.Text       = "0.2";

            guna2CustomCheckBox12.Checked = true;
            guna2CustomCheckBox11.Checked = false;

            utils.ShowMessageA("Your settings have been reset to the defailt configurations.");
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            if (utils.ShowMessageOK("Are you sure you would like to reset the settings back to the default configurations?"))
            {
                ResetToDefault();
                SaveSettings();
            }
        }

        void ShowSuccessSave()
        {
            label31.Visible = true;
            var t = new Timer
            {
                Interval = 3000 // it will Tick in 3 seconds
            };
            t.Tick += (s, e) =>
            {
                label31.Hide();
                t.Stop();
            };
            t.Start();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            ConfigFileReaderWriter cfg = new ConfigFileReaderWriter();
            bool ret = true;
            int count = 0;

            if (CameraViewRangeChanged)
            {
                ++count;
                if (!cfg.OverrideCamera(CameraNum))
                {
                    ret = false;
                }
            }

            if (ClientModificationsChanged)
            {
                ++count;
                if (guna2CustomCheckBox11.Checked)
                {
                    if (!cfg.OverrideCamera(false))
                    {
                        ret = false;
                    }
                }
                else
                {
                    if (!cfg.OverrideCamera(true))
                    {
                        ret = false;
                    }
                }
            }

            if (GameSettingsChanged)
            {
                ++count;
                if (!cfg.SaveGameSettings(GameSettings))
                {
                    ret = false;
                }
            }

            if (GlobalSettingsChanged)
            {
                ++count;
                // Update Launcher Settings
                if (!guna2CustomCheckBox12.Checked)
                    Globals.RenderNotification = false;

                string globalPath = Path.Combine(Globals.rootDirectory, "system", "CandyFX", "Global_settings.txt");
                if (!cfg.SaveConfigFile(globalPath, GlobalSettings))
                {
                    ret = false;
                }
            }

            if (CandyFXSettingsChanged)
            {
                ++count;
                string CandyPath = Path.Combine(Globals.rootDirectory, "system", "CandyFX", "CandyFX_settings.txt");
                if (!cfg.SaveConfigFile(CandyPath, CandyFXSettings))
                {
                    ret = false;
                }
            }

            if (count == 0 && SettingsMessageSaveShown)
            {
                ;
            }

            else if (count == 0)
            {
                if (utils.ShowMessageOK("Could not detect any changes, would you like to close this window?"))
                {
                    DisposeAll();
                    Close();
                }
                else
                    SettingsMessageSaveShown = true;
            }
            else
            {
                if (ret)
                {
                    ShowSuccessSave();
                    if (GameSettingsChanged || CameraViewRangeChanged)
                    {
                        if (Globals.IsGameRunning())
                        {
                            if (utils.ShowMessageOK("Due to certain configuration changes, KOP game needs to be restarted.\nWould you" +
                                " like to restart all game instances using the last recorded region?"))
                            {
                                Globals.RestartGameInstances();
                            }
                        }
                    }
                }
                else
                {
                    utils.ShowMessageA("An error occured while saving one of your configurations.");
                }
            }
        }

        void DisposeAll()
        {
            CandyFXSettings = null;
            GlobalSettings = null;
            GameSettings = null;
            utils = null;
        }

        private void SettingsF_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsOpen = false;
        }
    }
}

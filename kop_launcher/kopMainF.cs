using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kop_launcher
{
    public partial class kopmainF : Form
    {
        /* Custom Colour Table for Tray Menu */
        class CustomColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.Transparent; }
            }
            public override Color MenuBorder
            {
                get { return Color.Transparent; }
            }

            public override Color MenuItemBorder
            {
                get { return Color.Transparent; }
            }

            public override Color SeparatorDark
            {
                get { return Color.FromArgb(72, 80, 88); }
            }
        }

        /* Overriding Separator Due to it not being aligned correctly by default thanks to Microsoft*/
        void stripSeparator_Paint(object sender, PaintEventArgs e)
        {
            ToolStripSeparator stripSeparator = sender as ToolStripSeparator;
            _ = stripSeparator.Owner as ContextMenuStrip;
            e.Graphics.FillRectangle(new SolidBrush(Color.Transparent), new Rectangle(0, 0, stripSeparator.Width, stripSeparator.Height));
            using (Pen pen = new Pen(Color.FromArgb(72, 80, 88), 1))
            {
                e.Graphics.DrawLine(pen, new Point(23, stripSeparator.Height / 2), new Point(0, stripSeparator.Height / 2));
            }
        }

        /* kopMainF Class attributes begin */
        private bool isLauncherHidden = false;
        private bool PlayButtonEnabled = false;
        private Utils utils = new Utils();
        private string GameVersion = null;
        /* kopMainF Class attributes END */

        public kopmainF()
        {
            InitializeComponent();
            TrayMenuContext();

            /* Server Statistics and Update Timer */
            Task.WaitAll(Task.Factory.StartNew(UpdateServerStatistics),
                Task.Factory.StartNew(UpdateWebsiteStatus));

            updateStatisticsTimer.Enabled = true;
            updateStatisticsTimer.Start();

            InitialiseRegionsBox();
            SetCurrentTime();

            /* DPI Fix For older Windows Versions */
            if (GetIsWindowsOld())
            {
                label23.Location = new Point(860, label23.Location.Y);
                label22.Location = new Point(label22.Location.X, 446);
                label24.Location = new Point(label24.Location.X, 446);
            }

            SecurityBackgroundWorker.DoWork += SecurityBackgroundWorker_DoWork;
            SecurityBackgroundWorker.RunWorkerCompleted += SecurityBackgroundWorker_RunWorkerCompleted;

            CheckHasheshBW.DoWork += CheckHasheshBW_DoWork;
            CheckHasheshBW.RunWorkerCompleted += CheckHasheshBW_RunWorkerCompleted;

            //SecurityTimer.Enabled = true;
            //SecurityTimer.Start();

            // Timer to check for hash changes in game.exe and dlls
            //UpdateHashesTimer.Enabled = true;
            //UpdateHashesTimer.Start();
        }

        private bool GetIsWindowsOld()
        {
            string loc = @"SOFTWARE\Wow6432Node\Microsoft\Windows NT\CurrentVersion";
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine;
            Microsoft.Win32.RegistryKey skey = key.OpenSubKey(loc);
            if (skey.GetValue("ProductName").ToString().Contains("Windows 7"))
                return true;

            return false;
        }

        void SetCurrentTime()
        {
            var serverTime = TimeZoneInfo.ConvertTime(DateTime.Now,
                 TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time"));

            label21.Text = string.Format("Server Time: {0}", serverTime.ToString("HH:mm:ss"));
        }

        /* Regions Selection Box Handlers Begin */
        private void InitialiseRegionsBox()
        {
            regionsBox.Items.Add("Morgan");
            regionsBox.Items.Add("Local");
            regionsBox.Items.Add("Jan");
            regionsBox.SelectedItem = "Select Region";
        }
        /* Regions Selection Box Handlers END */

        /* Main Form Events Begin */
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* Prevent Launcher From Being Closed */
            e.Cancel = true;
        }
        private void updateStatisticsTimer_Tick(object sender, EventArgs e)
        {
            Task.WaitAll(Task.Factory.StartNew(UpdateServerStatistics), Task.Factory.StartNew(UpdateWebsiteStatus));

            if (Globals.hasBeenReported)
                Globals.hasBeenReported = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            var serverTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time"));

            label21.Text = string.Format("Server Time: {0}", serverTime.ToString("HH:mm:ss"));
        }
        /* Main Form Events END */

        /* Notification Tray Functions Begin */
        private void TrayMenuContext()
        {
            notifyIcon.ContextMenuStrip = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());

            notifyIcon.ContextMenuStrip.AutoSize = false;
            notifyIcon.ContextMenuStrip.BackColor = Color.FromArgb(40, 44, 50);
            notifyIcon.ContextMenuStrip.ForeColor = Color.FromArgb(175, 182, 191);
            notifyIcon.ContextMenuStrip.ShowCheckMargin = false;
            notifyIcon.ContextMenuStrip.ShowImageMargin = false;
            notifyIcon.ContextMenuStrip.Width = 114;

            if (GetIsWindowsOld())
                notifyIcon.ContextMenuStrip.Height = 154;
            else
                notifyIcon.ContextMenuStrip.Height = 170;

            ToolStripMenuItem toolstripLaunchGame = new ToolStripMenuItem
            {
                Text = "Launch Game",
                Margin = new Padding(0, 6, 0, 0)
            };

            ToolStripMenuItem exitApp = new ToolStripMenuItem
            {
                Text = "Exit",
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            ToolStripSeparator stripSeparator = new ToolStripSeparator();
            stripSeparator.Paint += stripSeparator_Paint;

            ToolStripSeparator stripSeparator1 = new ToolStripSeparator();
            stripSeparator1.Paint += stripSeparator_Paint;

            notifyIcon.ContextMenuStrip.Items.Add(toolstripLaunchGame);
            notifyIcon.ContextMenuStrip.Items.Add(stripSeparator);
            notifyIcon.ContextMenuStrip.Items.Add("KOP Website", null, null);
            notifyIcon.ContextMenuStrip.Items.Add("Downloads", null, null);
            notifyIcon.ContextMenuStrip.Items.Add("Settings", null, OpenGameSettings);
            notifyIcon.ContextMenuStrip.Items.Add("Force Update", null, ForceGameUpdate);
            notifyIcon.ContextMenuStrip.Items.Add(stripSeparator1);
            notifyIcon.ContextMenuStrip.Items.Add(exitApp);

            toolstripLaunchGame.Click += ToolstripLaunchGame_Click;
            exitApp.Click += ExitApp_Click;

            notifyIcon.ContextMenuStrip.Items.OfType<ToolStripMenuItem>().ToList().ForEach(x =>
            {
                x.MouseEnter += (obj, arg) => ((ToolStripDropDownItem)obj).ForeColor = Color.FromArgb(233, 236, 239);
            });

            notifyIcon.ContextMenuStrip.Items.OfType<ToolStripMenuItem>().ToList().ForEach(x =>
            {
                x.MouseLeave += (obj, arg) => ((ToolStripDropDownItem)obj).ForeColor = Color.FromArgb(175, 182, 191);
            });
        }

        private void ForceGameUpdate(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<UpdaterF>().Count() == 0)
            {
                if (!string.IsNullOrEmpty(GameVersion))
                {
                    string region = Globals.GetIPByServer(regionsBox.Text);
                    UpdaterF updater = new UpdaterF(GameVersion, region, true);
                    updater.Show();
                }
                else
                {
                    utils.ShowMessageA("Please ensure you have a valid internet connection!");
                }
            }
        }

        private void OpenGameSettings(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SettingsLoaderF>().Count() == 0)
            {
                SettingsLoaderF settingsLoader = new SettingsLoaderF();
                settingsLoader.Show();
            }
        }

        private void ExitApp_Click(object sender, EventArgs e)
        {
            if (isLauncherHidden)
            {
                isLauncherHidden = false;
                Show();
                WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }

            if (Globals.AnyInstancesRunning())
            {
                if (utils.ShowMessageOK("If you close King of Pirates Game launcher, all existing game instances will be shut. Are you sure you want to continue?"))
                {

                    foreach (int processID in Globals.GameInstances)
                    {
                        if (!Globals.KillProcess(processID))
                        {
                            ;
                        }
                    }

                    Dispose();
                    Close();
                }
            }
            else
            {
                Dispose();
                Close();
            }
        }

        private void ToolstripLaunchGame_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<UpdaterF>().Count() == 0)
            {
                if (!string.IsNullOrEmpty(GameVersion))
                {
                    string lastIP = Globals.lastOpenedRegion;
                    if (string.IsNullOrEmpty(lastIP))
                        lastIP = Globals.GetIPByServer(regionsBox.Text);

                    UpdaterF updater = new UpdaterF(GameVersion, lastIP);
                    updater.Show();
                }
                else
                {
                    utils.ShowMessageA("Please ensure you have a valid internet connection!");
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (!isLauncherHidden)
            {
                isLauncherHidden = true;
                WindowState = FormWindowState.Minimized;
                Hide();
                notifyIcon.Visible = true;

                if (Globals.RenderNotification && !Globals.RenderNotificationShown)
                {
                    notifyIcon.ShowBalloonTip(1000);

                    // Prevent from idsplaying the same tooltip over and over again
                    Globals.RenderNotificationShown = true;
                }
            }
            else
            {
                isLauncherHidden = false;
                Show();
                WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (isLauncherHidden)
            {
                isLauncherHidden = false;
                Show();
                WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;

                // Update Statistics
                Task.WaitAll(Task.Factory.StartNew(UpdateServerStatistics),
                    Task.Factory.StartNew(UpdateWebsiteStatus));
            }
        }
        /* Notification Tray Functions END */

        /* Sidebar Events Begin */
        private void ButtonS_MouseEnter(object sender, EventArgs e)
        {
            PictureBox b = sender as PictureBox;
            string uiPath = Path.Combine(Globals.rootDirectory, "texture", "launcher", "sidebar_buttons");
            string buttonPath = "";

            switch (b.Name)
            {
                case string facebook when facebook.Contains("facebook"):
                    buttonPath = Path.Combine(uiPath, "facebook_btn_hover.png");
                    break;
                case string instagram when instagram.Contains("insta"):
                    buttonPath = Path.Combine(uiPath, "insta_btn_hover.png");
                    break;
                case string mail when mail.Contains("mail"):
                    buttonPath = Path.Combine(uiPath, "mail_btn_hover.png");
                    break;
                case string forum when forum.Contains("forum"):
                    buttonPath = Path.Combine(uiPath, "forum_btn_hover.png");
                    break;
                default:
                    buttonPath = Path.Combine(uiPath, "settings_btn_hover.png");
                    break;
            }
            b.Image = Image.FromFile(buttonPath);
        }
        private void ButtonS_MouseLeave(object sender, EventArgs e)
        {
            PictureBox b = sender as PictureBox;
            string uiPath = Path.Combine(Globals.rootDirectory, "texture", "launcher", "sidebar_buttons");
            string buttonPath = "";

            switch (b.Name)
            {
                case string facebook when facebook.Contains("facebook"):
                    buttonPath = Path.Combine(uiPath, "facebook_btn.png");
                    break;
                case string instagram when instagram.Contains("insta"):
                    buttonPath = Path.Combine(uiPath, "insta_btn.png");
                    break;
                case string mail when mail.Contains("mail"):
                    buttonPath = Path.Combine(uiPath, "mail_btn.png");
                    break;
                case string forum when forum.Contains("forum"):
                    buttonPath = Path.Combine(uiPath, "forum_btn.png");
                    break;
                default:
                    buttonPath = Path.Combine(uiPath, "settings_btn.png");
                    break;
            }
            b.Image = Image.FromFile(buttonPath);
        }
        private void faDiscordBtn_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Resources.DiscordURL);
        }

        private void facebookButton_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Resources.FacebookURL);
        }

        private void instagramButton_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Resources.InstagramURL);
        }

        private void mailButton_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Resources.MailToURL);
        }

        private void forumButton_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Resources.ForumURL);
        }
        /* Sidebar Events END */

        /* Region Selection Events Begin */
        private void regionsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (regionsBox.SelectedIndex > -1 && regionsBox.SelectedIndex != 0)
            {
                PlayButtonEnabled = true;
                StartGameButton.Cursor = Cursors.Hand;
                string path = Path.Combine(Globals.rootDirectory, "texture", "launcher", "play_btn.png");
                StartGameButton.Image = Image.FromFile(path);
            }
            else
            {
                PlayButtonEnabled = false;
                StartGameButton.Cursor = Cursors.Default;
                string path = Path.Combine(Environment.CurrentDirectory, "texture", "launcher", "play_btn_disabled.png");
                //StartGameButton.Image = Image.FromFile(path);
            }
        }
        /* Region Selection Events END */

        /* Play Game Button Events Begin */
        private void StartGameButton_MouseHover(object sender, EventArgs e)
        {
            if (PlayButtonEnabled)
            {
                string path = Path.Combine(Globals.rootDirectory, "texture", "launcher", "play_btn_hover.png");
                StartGameButton.Image = Image.FromFile(path);
            }
        }

        private void StartGameButton_MouseLeave(object sender, EventArgs e)
        {
            if (PlayButtonEnabled)
            {
                string path = Path.Combine(Globals.rootDirectory, "texture", "launcher", "play_btn.png");
                StartGameButton.Image = Image.FromFile(path);
            }
        }
        /* Play Game Button Events END */

        /* Package Hover Events Begin */
        private void package1_MouseEnter(object sender, EventArgs e)
        {
            PictureBox b = sender as PictureBox;
            string uiPath = Path.Combine(Globals.rootDirectory, "texture", "launcher", "packages");
            string buttonPath = "";

            switch (b.Name)
            {
                case string facebook when facebook.Contains("1"):
                    buttonPath = Path.Combine(uiPath, "1_hover.png");
                    break;
                case string instagram when instagram.Contains("2"):
                    buttonPath = Path.Combine(uiPath, "2_hover.png");
                    break;
                case string mail when mail.Contains("3"):
                    buttonPath = Path.Combine(uiPath, "3_hover.png");
                    break;
                case string forum when forum.Contains("4"):
                    buttonPath = Path.Combine(uiPath, "4_hover.png");
                    break;
                default:
                    break;
            }
            b.Image = Image.FromFile(buttonPath);
        }
        private void package4_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Resources.ItemShopPackagesURL);
        }
        private void package1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox b = sender as PictureBox;
            string uiPath = Path.Combine(Globals.rootDirectory, "texture", "launcher", "packages");
            string buttonPath = "";

            switch (b.Name)
            {
                case string facebook when facebook.Contains("1"):
                    buttonPath = Path.Combine(uiPath, "1.png");
                    break;
                case string instagram when instagram.Contains("2"):
                    buttonPath = Path.Combine(uiPath, "2.png");
                    break;
                case string mail when mail.Contains("3"):
                    buttonPath = Path.Combine(uiPath, "3.png");
                    break;
                case string forum when forum.Contains("4"):
                    buttonPath = Path.Combine(uiPath, "4.png");
                    break;
                default:
                    break;
            }
            b.Image = Image.FromFile(buttonPath);
        }        
        /* Package Hover Events END */

        /* TOP Nav Links Events Begin */
        private void label4_MouseEnter(object sender, EventArgs e)
        {
            Label b = sender as Label;
            b.ForeColor = Color.FromArgb(188, 193, 227);
        }
        private void label4_MouseLeave(object sender, EventArgs e)
        {
            Label b = sender as Label;
            b.ForeColor = Color.FromArgb(133, 138, 172);
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Resources.MainWebsiteURL);
        }
        /* TOP Nav Links Events END */
        void SetControlThreadSafe(Control control, Action<object[]> action, object[] args)
        {
            if (control.InvokeRequired)
            {

                try 
                { 
                    control.Invoke(new Action<Control, Action<object[]>, object[]>(SetControlThreadSafe), control, action, args); 
                } 
                catch { }
            }
            else 
                action(args);
        }
        async Task UpdateServerStatistics()
        {
            try
            {
                await Task.Run(() =>
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    ServicePointManager.DefaultConnectionLimit = 20;

                    using (WebClient wc = new WebClient())
                    {
                        wc.Proxy = null;

                        var json = wc.DownloadString(Properties.Resources.StatisticsURL);
                        dynamic data = JObject.Parse(json);

                        SetControlThreadSafe(label7, (arg) => { label7.Text = data.accounts; }, null);
                        SetControlThreadSafe(label9, (arg) => { label9.Text = data.characters; }, null);
                        SetControlThreadSafe(label6, (arg) => { label6.Text = data.online; }, null);
                        SetControlThreadSafe(label15, (arg) => { label15.Text = data.version; }, null);

                        GameVersion = data.version;

                        string hashstring = data.hashsum;
                        string[] contents = hashstring.Split(new string[] { Properties.Resources.StatHashSumDelimiter }, StringSplitOptions.None);
                        foreach (var hash in contents)
                        {
                            if (!string.IsNullOrEmpty(hash))
                                Globals.GenuineResourceHashes.Add(hash);
                        }

                        if (data.online > 0)
                            SetControlThreadSafe(label11, (arg) => { label11.Text = "Online"; }, null);
                        else

                            SetControlThreadSafe(label11, (arg) => {
                                label11.ForeColor = Color.DarkRed;
                                label11.Text = "Offline";
                            }, null);
                    }
                });
            }
            catch { }
        }
        private async Task<bool> UrlIsReachable(string url)
        {
            try
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                    var response = await client.GetAsync(url);
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch
            {
                return false;
            }
        }
        private async Task UpdateWebsiteStatus()
        {
            try
            {
                var websiteReachable = await UrlIsReachable(Properties.Resources.MainWebsiteURL);

                if (websiteReachable)
                    SetControlThreadSafe(label13, (arg) => { label13.Text = "Online"; }, null);
                else

                    SetControlThreadSafe(label13, (arg) => {
                        label13.ForeColor = Color.DarkRed;
                        label13.Text = "Offline";
                    }, null);
            }
            catch
            {
                utils.ShowMessageA("Website status could not be retrieved due to a server malfunction, please contact an administrator!");
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SettingsLoaderF>().Count() == 0)
            {
                SettingsLoaderF settingsLoader = new SettingsLoaderF();
                settingsLoader.Show();
            }
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            if (PlayButtonEnabled)
            {
                string region = Globals.GetIPByServer(regionsBox.Text);
                if (!string.IsNullOrEmpty(region))
                {
                    if (Application.OpenForms.OfType<UpdaterF>().Count() == 0)
                    {
                        if (!string.IsNullOrEmpty(GameVersion))
                        {
                            UpdaterF updater = new UpdaterF(GameVersion, region);
                            updater.Show();
                        }
                        else
                        {
                            utils.ShowMessageA("Please ensure you have a valid internet connection!");
                        }
                    }
                }
                else
                {
                    utils.ShowMessageA("Please choose a region you would like to play on!");
                }
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Resources.MainWebsiteURL);
        }

        private void kopmainF_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void SecurityTimer_Tick(object sender, EventArgs e)
        {
            if (!SecurityBackgroundWorker.IsBusy)
                SecurityBackgroundWorker.RunWorkerAsync();
        }

        private void SecurityBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }

        private void SecurityBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string userIP = Security.GetCurrentMachineIP();
            DiscordWebHookHandler webhook = new DiscordWebHookHandler(Properties.Resources.LauncherSecurityChannel);
            bool userDataExists = Security.UserDataExists();

            var proc = Security.IsRunningIllegalSoftware();
            if (proc != null)
            {
                // User is Running Illegal Software
                if (userDataExists)
                {
                    webhook.SendMessage(string.Format(
                        "{0} is running illegal software", userIP),
                        "User has violated King of Pirates Rules",
                        string.Format("{0} has been caught using {1}. User data existed at the moment of violation and has been " +
                        "attached to this message", userIP, proc),
                        true,
                        Security.GetUserDataFilePath(), 
                        0xef3535);
                }
                else
                {
                    webhook.SendMessage(string.Format(
                        "{0} is running illegal software", userIP),
                        "User has violated King of Pirates Rules",
                        string.Format("{0} has been caught using {1}. User data did not exist at the moment of violation", 
                        userIP, proc),
                        false,
                        null,
                        0xef3535);
                }
                Security.KillAllGameInstances();
            }

            // Check for changed system hashes
            if (Security.IsSystemHashChanged())
            {
                var modifiedFiles = Security.GetModifiedSystemFiles();
                if (!Globals.hasBeenReported)
                {
                    if (userDataExists)
                    {
                        webhook.SendMessage(string.Format(
                            "{0} has modified system folder", userIP),
                            "User has violated King of Pirates Rules",
                            string.Format("{0} has modified the following files: {1}. User data existed at the moment of violation and has been " +
                            "attached to this message",
                            userIP, modifiedFiles),
                            true,
                            Security.GetUserDataFilePath(),
                            0xef3535);
                    }
                    else
                    {
                        webhook.SendMessage(string.Format(
                            "{0} has modified system folder", userIP),
                            "User has violated King of Pirates Rules",
                            string.Format("{0} has modified the following files: {1}. User data did not exist at the moment of violation",
                            userIP, modifiedFiles),
                            false,
                            null,
                            0xef3535);
                    }
                    Globals.hasBeenReported = true;
                }
                Security.KillAllGameInstances();
            }

            userIP = null;
            webhook = null;
            userDataExists = false;
        }

        private void UpdateHashesTimer_Tick(object sender, EventArgs e)
        {
            if (!CheckHasheshBW.IsBusy)
                CheckHasheshBW.RunWorkerAsync();
        }

        private void CheckHasheshBW_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
        }

        private void CheckHasheshBW_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                string gamePath = Path.Combine(Globals.rootDirectory, "game.exe");
                string enginePath = Path.Combine(Globals.rootDirectory, "MindPower3D_D8R.dll");
                string encDecEnginePath = Path.Combine(Globals.rootDirectory, "Engine.dll");

                if (Globals.CurrentResourceHashes.Count > 0)
                {
                    Globals.CurrentResourceHashes.Clear();
                }

                Globals.CurrentResourceHashes.Add(Globals.CalculateMD5(gamePath));
                Globals.CurrentResourceHashes.Add(Globals.CalculateMD5(enginePath));
                Globals.CurrentResourceHashes.Add(Globals.CalculateMD5(encDecEnginePath));

                gamePath = null;
                enginePath = null;
                encDecEnginePath = null;
            }
            catch { }
        }
    }
}

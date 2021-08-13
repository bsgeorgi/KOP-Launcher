using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using Guna.UI2.WinForms;
using kop_launcher.Forms;
using kop_launcher.Models;
using kop_launcher.Properties;
using Newtonsoft.Json.Linq;

namespace kop_launcher
{
    public partial class KopmainF : Form
    {
        /* kopMainF Class attributes begin */
        private bool _isLauncherHidden;
        private bool _playButtonEnabled;
        private string _gameVersion;
        private DateTime _serverTime;
        private bool _hasBeenPopulated;

        private PortalsOnDraw _portals;
        /* kopMainF Class attributes END */

        public KopmainF()
        {
            Globals.UiDispatcher = Dispatcher.CurrentDispatcher;
            InitializeComponent ( );
            TrayMenuContext ( );

            /* Server Statistics and Update Timer */
            Task.WaitAll ( Task.Factory.StartNew ( UpdateServerStatistics ),
                Task.Factory.StartNew ( UpdateWebsiteStatus ), Task.Factory.StartNew ( GetPortalInfo ) );

            updateStatisticsTimer.Enabled = true;
            updateStatisticsTimer.Start ( );

            InitialiseRegionsBox ( );
            SetCurrentTime ( );

            /* DPI Fix For older Windows Versions */
            if ( Utils.GetIsWindowsOld ( ) )
            {
                label23.Location = new Point ( 860, label23.Location.Y );
                label22.Location = new Point ( label22.Location.X, 446 );
                label24.Location = new Point ( label24.Location.X, 446 );
            }


            PopulateAccountBox (  );

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

        /* Overriding Separator Due to it not being aligned correctly by default thanks to Microsoft*/
        private void stripSeparator_Paint ( object sender, PaintEventArgs e )
        {
            if ( !(sender is ToolStripSeparator stripSeparator) )
                return;

            _ = stripSeparator.Owner as ContextMenuStrip;
            e.Graphics.FillRectangle ( new SolidBrush ( Color.Transparent ),
                new Rectangle ( 0, 0, stripSeparator.Width, stripSeparator.Height ) );
            using (var pen = new Pen ( Color.FromArgb ( 72, 80, 88 ), 1 ))
            {
                e.Graphics.DrawLine ( pen, new Point ( 23, stripSeparator.Height / 2 ),
                    new Point ( 0, stripSeparator.Height / 2 ) );
            }
        }


        public void PopulateAccountBox()
        {
            var count = gameAccounts.Items.Count - 1;
            if ( _hasBeenPopulated && Globals.GameAccounts != null && count == Globals.GameAccounts.Count ) return;

            if ( gameAccounts.Visible )
            {
                if ( Globals.GameAccounts == null || Globals.GameAccounts.Count == 0 )
                {
                    gameAccounts.Visible = false;
                    accLabc.Visible = false;

                    gameAccounts.Items.Clear();
                    gameAccounts.Items.Add("Select Account");
                    gameAccounts.SelectedItem = gameAccounts.Items[0];

                    regLabc.Location = new Point(539, 214);
                    regionsBox.Location = new Point(503, 234);
                    accLabc.Location = new Point(723, 217);
                }

                if ( Globals.GameAccounts != null && count != Globals.GameAccounts.Count )
                {
                    gameAccounts.Items.Clear();
                    gameAccounts.Items.Add("Select Account");
                    gameAccounts.SelectedItem = gameAccounts.Items[0];

                    foreach (var account in Globals.GameAccounts.Where(account => !gameAccounts.Items.Contains(account.Username)))
                        gameAccounts.Items.Add(account.Username);
                }
            }

            Globals.SecurityCode = new StringCipher ( ).CheckRetrieveKey ( );
            if ( Globals.SecurityCode == null ) return;

            var controller = new GameAccountsController ( Globals.SecurityCode );

            Globals.GameAccounts = controller.GetFileData ( );

            if ( Globals.GameAccounts == null || Globals.GameAccounts.Count <= 0 ) return;

            regLabc.Location = new Point ( 443, 214 );
            regionsBox.Location = new Point ( 414, 239 );

            gameAccounts.Location = new Point ( 600, 239 );

            accLabc.Location = new Point ( 624, 217 );
            gameAccounts.Visible = true;
            accLabc.Visible = true;
            gameAccounts.SelectedItem = gameAccounts.Items[0];

            foreach (var account in Globals.GameAccounts.Where ( account => !gameAccounts.Items.Contains ( account.Username ) ))
                gameAccounts.Items.Add ( account.Username );

            if ( !_hasBeenPopulated ) _hasBeenPopulated = true;
        }

        private void SetCurrentTime()
        {
            _serverTime = Utils.GetServerTime ( );

            label21.Text = $"Server Time: {_serverTime:HH:mm:ss}";
        }

        /* Regions Selection Box Handlers Begin */
        private void InitialiseRegionsBox()
        {
            if ( !Utils.PopulateRegion ( regionsBox ) )
            {
                Utils.ShowMessageA ( "An error occured while populating game regions!" );
            }
        }
        /* Regions Selection Box Handlers END */

        /* Main Form Events Begin */
        // ReSharper disable once UnusedParameter.Local
        private void Form1_FormClosing ( object _, FormClosingEventArgs e )
        {
            /* Prevent Launcher From Being Closed */
            e.Cancel = true;
        }

        private void updateStatisticsTimer_Tick ( object sender, EventArgs e )
        {
            Task.WaitAll ( Task.Factory.StartNew ( UpdateServerStatistics ),
                Task.Factory.StartNew ( UpdateWebsiteStatus ), Task.Factory.StartNew ( GetPortalInfo ) );

            if ( Globals.HasBeenReported )
                Globals.HasBeenReported = false;
        }

        private void timer1_Tick ( object sender, EventArgs e )
        {
            var serverTime = TimeZoneInfo.ConvertTime ( DateTime.Now,
                TimeZoneInfo.FindSystemTimeZoneById ( "Central Europe Standard Time" ) );

            label21.Text = $"Server Time: {serverTime:HH:mm:ss}";

            PopulateAccountBox ( );
        }
        /* Main Form Events END */

        /* Notification Tray Functions Begin */
        private void TrayMenuContext()
        {
            notifyIcon.ContextMenuStrip = new Guna2ContextMenuStrip
            {
                Renderer = new ToolStripProfessionalRenderer ( new CustomColorTable ( ) ),
                AutoSize = false,
                BackColor = Color.FromArgb ( 40, 44, 50 ),
                ForeColor = Color.FromArgb ( 175, 182, 191 ),
                ShowCheckMargin = false,
                ShowImageMargin = false,
                Width = 114,
                Height = Utils.GetIsWindowsOld ( ) ? 154 : 170
            };


            var toolstripLaunchGame = new ToolStripMenuItem {Text = "Launch Game", Margin = new Padding ( 0, 6, 0, 0 )};

            var exitApp = new ToolStripMenuItem
            {
                Text = "Exit", Padding = new Padding ( 0 ), Margin = new Padding ( 0 )
            };

            var stripSeparator = new ToolStripSeparator ( );
            stripSeparator.Paint += stripSeparator_Paint;

            var stripSeparator1 = new ToolStripSeparator ( );
            stripSeparator1.Paint += stripSeparator_Paint;

            notifyIcon.ContextMenuStrip.Items.Add ( toolstripLaunchGame );
            notifyIcon.ContextMenuStrip.Items.Add ( stripSeparator );
            notifyIcon.ContextMenuStrip.Items.Add ( "KOP Website", null, null );
            notifyIcon.ContextMenuStrip.Items.Add ( "Downloads", null, null );
            notifyIcon.ContextMenuStrip.Items.Add ( "Settings", null, OpenGameSettings );
            notifyIcon.ContextMenuStrip.Items.Add ( "Version Check", null, ForceGameUpdate );
            notifyIcon.ContextMenuStrip.Items.Add ( stripSeparator1 );
            notifyIcon.ContextMenuStrip.Items.Add ( exitApp );

            toolstripLaunchGame.Click += ToolstripLaunchGame_Click;
            exitApp.Click += ExitApp_Click;

            notifyIcon.ContextMenuStrip.Items.OfType<ToolStripMenuItem> ( ).ToList ( ).ForEach ( x =>
            {
                x.MouseEnter += ( obj, arg ) =>
                    ((ToolStripDropDownItem) obj).ForeColor = Color.FromArgb ( 233, 236, 239 );
            } );

            notifyIcon.ContextMenuStrip.Items.OfType<ToolStripMenuItem> ( ).ToList ( ).ForEach ( x =>
            {
                x.MouseLeave += ( obj, arg ) =>
                    ((ToolStripDropDownItem) obj).ForeColor = Color.FromArgb ( 175, 182, 191 );
            } );
        }

        private void ForceGameUpdate ( object sender, EventArgs e )
        {
            StartCheckGameUpdate ( true, null );
        }

        private void OpenGameSettings ( object sender, EventArgs e )
        {
            Utils.OpenGameSettingsForm ( );
        }

        private void ExitApp_Click ( object sender, EventArgs e )
        {
            if ( _isLauncherHidden )
            {
                _isLauncherHidden = false;
                Show ( );
                WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }

            if ( Globals.AnyInstancesRunning ( ) )
            {
                if ( Utils.ShowMessageOK (
                    "If you close King of Pirates Game launcher, all existing game instances will be shut. Are you sure you want to continue?" )
                )
                {
                    foreach (var processID in Globals.GameInstances)
                        if ( !Globals.KillProcess ( processID ) )
                        {
                        }

                    Dispose ( );
                    Close ( );
                }
            }
            else
            {
                Dispose ( );
                Close ( );
            }
        }

        private void ToolstripLaunchGame_Click ( object sender, EventArgs e )
        {
            StartCheckGameUpdate ( false, null );
        }

        private void closeButton_Click ( object sender, EventArgs e )
        {
            if ( !_isLauncherHidden )
            {
                _isLauncherHidden = true;
                WindowState = FormWindowState.Minimized;
                Hide ( );
                notifyIcon.Visible = true;

                if ( Globals.RenderNotification && !Globals.RenderNotificationShown )
                {
                    notifyIcon.ShowBalloonTip ( 1000 );

                    // Prevent from displaying the same tooltip over and over again
                    Globals.RenderNotificationShown = true;
                }
            }
            else
            {
                _isLauncherHidden = false;
                Show ( );
                WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }
        }

        private void notifyIcon_DoubleClick ( object sender, EventArgs e )
        {
            if ( _isLauncherHidden )
            {
                _isLauncherHidden = false;
                Show ( );
                WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;

                // Update Statistics
                Task.WaitAll ( Task.Factory.StartNew ( UpdateServerStatistics ),
                    Task.Factory.StartNew ( UpdateWebsiteStatus ), Task.Factory.StartNew ( GetPortalInfo ) );
            }
        }
        /* Notification Tray Functions END */

        /* Sidebar Events Begin */
        private void ButtonS_MouseEnter ( object sender, EventArgs e )
        {
            if ( !(sender is PictureBox b) )
                return;

            b.Image = Image.FromFile ( GetImageOnEvent.GetImageOnEnterSidebar ( b.Name ) );
        }

        private void ButtonS_MouseLeave ( object sender, EventArgs e )
        {
            if ( !(sender is PictureBox b) )
                return;

            b.Image = Image.FromFile ( GetImageOnEvent.GetImageOnLeaveSidebar ( b.Name ) );
        }

        private void faDiscordBtn_Click ( object sender, EventArgs e )
        {
            Process.Start ( Resources.DiscordURL );
        }

        private void facebookButton_Click ( object sender, EventArgs e )
        {
            Process.Start ( Resources.FacebookURL );
        }

        private void instagramButton_Click ( object sender, EventArgs e )
        {
            Process.Start ( Resources.InstagramURL );
        }

        private void mailButton_Click ( object sender, EventArgs e )
        {
            Process.Start ( Resources.MailToURL );
        }

        private void forumButton_Click ( object sender, EventArgs e )
        {
            Process.Start ( Resources.ForumURL );
        }
        /* Sidebar Events END */

        /* Region Selection Events Begin */
        private void regionsBox_SelectedIndexChanged ( object sender, EventArgs e )
        {
            if ( regionsBox.SelectedIndex > -1 && regionsBox.SelectedIndex != 0 )
            {
                _playButtonEnabled = true;
                StartGameButton.Cursor = Cursors.Hand;
                var path = Path.Combine ( Globals.RootDirectory, "texture", "launcher", "play_btn.png" );
                StartGameButton.Image = Image.FromFile ( path );
            }
            else
            {
                _playButtonEnabled = false;
                StartGameButton.Cursor = Cursors.Default;
                var path = Path.Combine ( Environment.CurrentDirectory, "texture", "launcher",
                    "play_btn_disabled.png" );
                //StartGameButton.Image = Image.FromFile(path);
            }
        }
        /* Region Selection Events END */

        /* Play Game Button Events Begin */
        private void StartGameButton_MouseHover ( object sender, EventArgs e )
        {
            if ( _playButtonEnabled )
            {
                var path = Path.Combine ( Globals.RootDirectory, "texture", "launcher", "play_btn_hover.png" );
                StartGameButton.Image = Image.FromFile ( path );
            }
        }

        private void StartGameButton_MouseLeave ( object sender, EventArgs e )
        {
            if ( _playButtonEnabled )
            {
                var path = Path.Combine ( Globals.RootDirectory, "texture", "launcher", "play_btn.png" );
                StartGameButton.Image = Image.FromFile ( path );
            }
        }
        /* Play Game Button Events END */

        /* Package Hover Events Begin */
        private void package1_MouseEnter ( object sender, EventArgs e )
        {
            if ( !(sender is PictureBox b) )
                return;

            b.Image = Image.FromFile ( GetImageOnEvent.GetImageOnEnterPackage ( b.Name ) );
        }

        private void package1_MouseLeave ( object sender, EventArgs e )
        {
            if ( !(sender is PictureBox b) )
                return;

            b.Image = Image.FromFile ( GetImageOnEvent.GetImageOnLeavePackage ( b.Name ) );
        }

        private void package4_Click ( object sender, EventArgs e )
        {
            Process.Start ( Resources.ItemShopPackagesURL );
        }
        /* Package Hover Events END */

        /* TOP Nav Links Events Begin */
        private void label4_MouseEnter ( object sender, EventArgs e )
        {
            if ( !(sender is Label b) )
                return;

            b.ForeColor = Color.FromArgb ( 188, 193, 227 );
        }

        private void label4_MouseLeave ( object sender, EventArgs e )
        {
            if ( !(sender is Label b) )
                return;
            b.ForeColor = Color.FromArgb ( 133, 138, 172 );
        }

        private void label1_Click ( object sender, EventArgs e )
        {
            Process.Start ( Resources.MainWebsiteURL );
        }

        /* TOP Nav Links Events END */
        private void SetControlThreadSafe ( Control control, Action<object[]> action, object[] args )
        {
            if ( control.InvokeRequired )
                try
                {
                    control.Invoke ( new Action<Control, Action<object[]>, object[]> ( SetControlThreadSafe ), control,
                        action, args );
                }
                catch
                {
                    // ignored
                }
            else
                action ( args );
        }

        private async Task UpdateServerStatistics()
        {
            try
            {
                await Task.Run ( () =>
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    ServicePointManager.DefaultConnectionLimit = 20;

                    using (var wc = new WebClient ( ))
                    {
                        wc.Proxy = null;

                        var json = wc.DownloadString ( Resources.StatisticsURL );
                        MessageBox.Show(json);
                        dynamic data = JObject.Parse ( json );

                        SetControlThreadSafe ( label7, arg => { label7.Text = data.accounts; }, null );
                        SetControlThreadSafe ( label9, arg => { label9.Text = data.characters; }, null );
                        SetControlThreadSafe ( label6, arg => { label6.Text = data.online; }, null );
                        SetControlThreadSafe ( label15, arg => { label15.Text = data.version; }, null );

                        _gameVersion = data.version;

                        string hashes = data.hashsum;
                        var contents = hashes.Split ( new[] {Resources.StatHashSumDelimiter}, StringSplitOptions.None );
                        foreach (var hash in contents)
                            if ( !string.IsNullOrEmpty ( hash ) )
                                Globals.GenuineResourceHashes.Add ( hash );

                        if ( data.online > 0 )
                            SetControlThreadSafe ( label11, arg => { label11.Text = "Online"; }, null );
                        else

                            SetControlThreadSafe ( label11, arg =>
                            {
                                label11.ForeColor = Color.DarkRed;
                                label11.Text = "Offline";
                            }, null );
                    }
                } );
            }
            catch
            {
                // ignored
            }
        }

        private void GetPortalInfo()
        {
            try
            {
                _portals = new PortalsOnDraw ( );

                foreach (var tableHeading in _portals.TableHeadings)
                {
                    Controls.Add ( tableHeading );
                    tableHeading.BringToFront ( );
                }

                foreach (var portalControl in _portals.PortalPanels)
                {
                    Controls.Add ( portalControl );
                    portalControl.BringToFront ( );
                }
            }
            catch
            {
                // ignored
            }
        }

        private async Task UpdateWebsiteStatus()
        {
            try
            {
                var websiteReachable = await Globals.UrlIsReachable ( Resources.MainWebsiteURL );

                if ( websiteReachable )
                    SetControlThreadSafe ( label13, arg => { label13.Text = "Online"; }, null );
                else

                    SetControlThreadSafe ( label13, arg =>
                    {
                        label13.ForeColor = Color.DarkRed;
                        label13.Text = "Offline";
                    }, null );
            }
            catch
            {
                Utils.ShowMessageA (
                    "Website status could not be retrieved due to a server malfunction, please contact an administrator!" );
            }
        }

        private void settingsButton_Click ( object sender, EventArgs e )
        {
            if ( !Application.OpenForms.OfType<SettingsF> ( ).Any ( ) )
            {
                var settingsLoader = new SettingsLoaderF ( );
                settingsLoader.Show ( );
            }
            else
                Application.OpenForms["SettingsF"]?.BringToFront ( );
        }

        private void StartGameButton_Click ( object sender, EventArgs e )
        {
            if ( !_playButtonEnabled ) return;

            var region = Globals.GetIpByServer ( regionsBox.Text );
            MessageBox.Show ( $"Connecting to : {region} " );
            if ( !string.IsNullOrEmpty ( region ) )
            {
                if ( gameAccounts.SelectedIndex > 0 )
                {
                    var accountUsername = gameAccounts.SelectedItem.ToString ( );

                    var accounts =
                        Globals.GameAccounts.Where ( act => act.Username == gameAccounts.SelectedItem.ToString ( ) );

                    foreach (var acc in accounts)
                        StartCheckGameUpdate ( false, acc );
                }
                else
                    StartCheckGameUpdate ( false, null );
            }
            else
                Utils.ShowMessageA ( "Please choose a region you would like to play on!" );
        }

        private void StartCheckGameUpdate ( bool forceUpdate, GameAccount account )
        {
            if ( Application.OpenForms.OfType<UpdaterF> ( ).Any ( ) ) return;

            var region = Globals.GetIpByServer ( regionsBox.Text );
            if ( !string.IsNullOrEmpty ( _gameVersion ) )
            {
                using (var updater = new UpdaterF ( _gameVersion, region, account, forceUpdate ))
                {
                    updater.Show ( );
                }
            }
            else
            {
                Utils.ShowMessageA ( "Retrieving update information, please try again in a few seconds." );
            }
        }

        private void label23_Click ( object sender, EventArgs e )
        {
            Process.Start ( Resources.MainWebsiteURL );
        }

        private void kopmainF_FormClosing ( object sender, FormClosingEventArgs e )
        {
            e.Cancel = true;
        }

        private void SecurityTimer_Tick ( object sender, EventArgs e )
        {
            if ( !SecurityBackgroundWorker.IsBusy )
                SecurityBackgroundWorker.RunWorkerAsync ( );
        }

        private void SecurityBackgroundWorker_RunWorkerCompleted ( object sender, RunWorkerCompletedEventArgs e )
        {
        }

        private void SecurityBackgroundWorker_DoWork ( object sender, DoWorkEventArgs e )
        {
            var userIp = GameProtection.GetCurrentMachineIP ( );
            var webhook = new DiscordWebHookHandler ( Resources.LauncherSecurityChannel );
            var userDataExists = GameProtection.UserDataExists ( );

            var proc = GameProtection.IsRunningIllegalSoftware ( );
            if ( proc != null )
            {
                // User is Running Illegal Software
                if ( userDataExists )
                    webhook.SendMessage ( $"{userIp} is running illegal software",
                        "User has violated King of Pirates Rules",
                        $"{userIp} has been caught using {proc}. User data existed at the moment of violation and has been " +
                        "attached to this message", true, GameProtection.GetUserDataFilePath ( ), 0xef3535 );
                else
                    webhook.SendMessage ( $"{userIp} is running illegal software",
                        "User has violated King of Pirates Rules",
                        $"{userIp} has been caught using {proc}. User data did not exist at the moment of violation",
                        false, null, 0xef3535 );
                GameProtection.KillAllGameInstances ( );
            }

            // Check for changed system hashes
            if ( GameProtection.IsSystemHashChanged ( ) )
            {
                var modifiedFiles = GameProtection.GetModifiedSystemFiles ( );
                if ( !Globals.HasBeenReported )
                {
                    if ( userDataExists )
                        webhook.SendMessage ( $"{userIp} has modified system folder",
                            "User has violated King of Pirates Rules",
                            $"{userIp} has modified the following files: {modifiedFiles}. User data existed at the moment of violation and has been " +
                            "attached to this message", true, GameProtection.GetUserDataFilePath ( ), 0xef3535 );
                    else
                        webhook.SendMessage ( $"{userIp} has modified system folder",
                            "User has violated King of Pirates Rules",
                            $"{userIp} has modified the following files: {modifiedFiles}. User data did not exist at the moment of violation",
                            false, null, 0xef3535 );
                    Globals.HasBeenReported = true;
                }

                GameProtection.KillAllGameInstances ( );
            }

            // ReSharper disable RedundantAssignment
            userIp = null;
            webhook = null;
            userDataExists = false;
        }

        private void UpdateHashesTimer_Tick ( object sender, EventArgs e )
        {
            if ( !CheckHasheshBW.IsBusy )
                CheckHasheshBW.RunWorkerAsync ( );
        }

        private void CheckHasheshBW_RunWorkerCompleted ( object sender, RunWorkerCompletedEventArgs e )
        {
        }

        private void CheckHasheshBW_DoWork ( object sender, DoWorkEventArgs e )
        {
            try
            {
                var gamePath = Path.Combine ( Globals.RootDirectory, "game.exe" );
                var enginePath = Path.Combine ( Globals.RootDirectory, "MindPower3D_D8R.dll" );
                var encDecEnginePath = Path.Combine ( Globals.RootDirectory, "Engine.dll" );

                if ( Globals.CurrentResourceHashes.Count > 0 ) Globals.CurrentResourceHashes.Clear ( );

                Globals.CurrentResourceHashes.Add ( Globals.CalculateMD5 ( gamePath ) );
                Globals.CurrentResourceHashes.Add ( Globals.CalculateMD5 ( enginePath ) );
                Globals.CurrentResourceHashes.Add ( Globals.CalculateMD5 ( encDecEnginePath ) );

                gamePath = null;
                enginePath = null;
                encDecEnginePath = null;
            }
            catch
            {
                // ignored
            }
        }
    }
}
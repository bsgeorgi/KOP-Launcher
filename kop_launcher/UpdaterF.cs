using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kop_launcher
{
    public partial class UpdaterF : Form
    {
        private string RemoteVersion;
        private AutoUpdate GameUpdater;
        private Utils utils = new Utils();
        private string RegionIP;
        private List<string> DownloadedFiles;
        private int TotalUpdates = 0;
        private bool ForceUpdate = false;
        private bool WasUpdated = false;
        public UpdaterF(string RemoteVersion, string Region, bool ForceUpdate=false)
        {
            InitializeComponent();
            this.RemoteVersion = RemoteVersion;
            this.ForceUpdate = ForceUpdate;
            RegionIP = Region;

            progressBar1.Focus();
            progressBar1.Select();

            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;

            Task.Run(async () =>
            {
                await CheckGameNeedsUpdate();
            });
        }

        async Task CheckGameNeedsUpdate()
        {
            GameUpdater = new AutoUpdate(RemoteVersion);
            if (GameUpdater.IsGameUpToDate())
            {
                Close();
                if (!StartGameInstance())
                {
                    utils.ShowMessageA("An error occured while opening a game instance");
                }
            }
            else
            {
                if (ForceUpdate)
                {
                    SetControlThreadSafe(label2, (arg) => { label2.Text = "Receiving Update Information..."; }, null);
                    DownloadedFiles = new List<string>();

                    var PatchInfo = GameUpdater.GetRequiredUpdates(RemoteVersion, Properties.Resources.UpdateXMLFile, true);
                    if (PatchInfo.PatchList.Count > 0 && PatchInfo.LastVersion > 0)
                    {
                        SetControlThreadSafe(progressBar1, (arg) => { progressBar1.Value = 0; }, null);
                        SetControlThreadSafe(progressBar1, (arg) => { progressBar1.Style = ProgressBarStyle.Blocks; }, null);
                        SetControlThreadSafe(label2, (arg) => { label2.Text = "Downloading Game Updates..."; }, null);
                        TotalUpdates = PatchInfo.PatchList.Count;

                        await DownloadMultipleFilesAsync(PatchInfo.PatchList);
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
                else
                {
                    SetControlThreadSafe(label2, (arg) => { label2.Text = "Receiving Update Information..."; }, null);
                    DownloadedFiles = new List<string>();

                    var PatchInfo = GameUpdater.GetRequiredUpdates(RemoteVersion, Properties.Resources.UpdateXMLFile, false);
                    if (PatchInfo.PatchList.Count > 0 && PatchInfo.LastVersion > 0)
                    {
                        SetControlThreadSafe(progressBar1, (arg) => { progressBar1.Value = 0; }, null);
                        SetControlThreadSafe(progressBar1, (arg) => { progressBar1.Style = ProgressBarStyle.Blocks; }, null);
                        SetControlThreadSafe(label2, (arg) => { label2.Text = "Downloading Game Updates..."; }, null);
                        TotalUpdates = PatchInfo.PatchList.Count;

                        await DownloadMultipleFilesAsync(PatchInfo.PatchList);
                        backgroundWorker1.RunWorkerAsync();
                    }
                    else
                    {
                        MessageBox.Show("An error occured while retrieving update information, please contact a Game Master!");
                        Close();
                    }
                }
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetControlThreadSafe(progressBar1, (arg) => { progressBar1.Value = 100; }, null);
            SetControlThreadSafe(label2, (arg) => { label2.Text = "Game Updated Successfully..."; }, null);
            WasUpdated = true;
            GameUpdater.OverrideLocalGameVersion(RemoteVersion);
            if (!ForceUpdate)
            {
                Close();
                if (!StartGameInstance())
                {
                    utils.ShowMessageA("An error occured while opening a game instance");
                }
            }
            Close();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int current = 1;
            SetControlThreadSafe(label2, (arg) => { label2.Text = "Installing Game Updates..."; }, null);
            SetControlThreadSafe(progressBar1, (arg) => { progressBar1.Value = 0; }, null);

            if (DownloadedFiles.Count > 0)
            {
                foreach (var file in DownloadedFiles)
                {
                    string Path = System.IO.Path.Combine(Globals.SaveDownloadsPath, file);

                    FastZip fastZip = new FastZip();
                    string fileFilter = null;
                    fastZip.ExtractZip(Path, Globals.rootDirectory, fileFilter);

                    DeleteFileAndWait(Path);
                    backgroundWorker1.ReportProgress(current * 100 / TotalUpdates);
                    ++current;
                }
            }
        }

        void DeleteFileAndWait(string filepath, int timeout = 30000)
        {
            using (var fw = new FileSystemWatcher(Path.GetDirectoryName(filepath), Path.GetFileName(filepath)))
            using (var mre = new ManualResetEventSlim())
            {
                fw.EnableRaisingEvents = true;
                fw.Deleted += (object sender, FileSystemEventArgs e) =>
                {
                    mre.Set();
                };
                File.Delete(filepath);
                mre.Wait(timeout);
            }
        }

        private async Task DownloadFileAsync(string url)
        {
            try
            {
                var DownloadInfo = GameUpdater.GetDownloadData(url);
                if (DownloadInfo != null)
                {
                    string SavePath = Path.Combine(Globals.SaveDownloadsPath, DownloadInfo.TemporaryFile);
                    DownloadedFiles.Add(DownloadInfo.TemporaryFile);

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    ServicePointManager.DefaultConnectionLimit = 20;

                    using (WebClient webClient = new WebClient())
                    {
                        webClient.Proxy = null;

                        webClient.DownloadProgressChanged += (s, e) =>
                        {
                            progressBar1.Value = e.ProgressPercentage;
                        };

                        await webClient.DownloadFileTaskAsync(new Uri(url), SavePath);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private async Task DownloadMultipleFilesAsync(List<Patch> Patches)
        {
            await Task.WhenAll(Patches.Select(patch => DownloadFileAsync(patch.FileURL)));
        }

        private bool StartGameInstance()
        {
            if (WasUpdated)
            {
                if (utils.ShowMessageOK("Game has been updated to the last available version, would you like to start the game now?"))
                {
                    int procID = Globals.StartGameInstance(RegionIP);

                    if (procID != -1)
                    {
                        Globals.lastOpenedRegion = RegionIP;
                        Globals.GameInstances.Add(procID);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                int procID = Globals.StartGameInstance(RegionIP);

                if (procID != -1)
                {
                    Globals.lastOpenedRegion = RegionIP;
                    Globals.GameInstances.Add(procID);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private void DisposeAll()
        {
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DisposeAll();
        }

        private void SetControlThreadSafe(Control control, Action<object[]> action, object[] args)
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
    }
}

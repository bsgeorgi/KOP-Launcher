using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;
using kop_launcher.Models;
using kop_launcher.Properties;

namespace kop_launcher
{
	public partial class UpdaterF : Form
	{
		private readonly string       _remoteVersion;
		private          AutoUpdate   _gameUpdater;
		private readonly string       _regionIp;
		private          List<string> _downloadedFiles;
		private          int          _totalUpdates;
		private readonly bool         _forceUpdate;
		private          bool         _wasUpdated;

		public UpdaterF ( string remoteVersion, string region, bool forceUpdate = false )
		{
			InitializeComponent ( );
			_remoteVersion = remoteVersion;
			_forceUpdate   = forceUpdate;
			_regionIp      = region;

			progressBar1.Focus ( );
			progressBar1.Select ( );

			backgroundWorker1.DoWork             += BackgroundWorker1_DoWork;
			backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;

			var _ = CheckGameNeedsUpdate ( );
		}

		private async Task CheckGameNeedsUpdate ( )
		{
			_gameUpdater = new AutoUpdate ( _remoteVersion );
			if ( _gameUpdater.IsGameUpToDate ( ) )
			{
                if (_forceUpdate)
				{
                    Utils.ShowMessageA("King of Pirates game client is up to date!");
					SetControlThreadSafe(this, Hide);
                }
                else
                {
					label2.Text = "Game is up to date...";

                    await Task.Run(() =>
                    {
                        if (!StartGameInstance())
                            Utils.ShowMessageA("An error occurred while opening a game instance");
                    });

                    SetControlThreadSafe(this, Close);
				}
            }
			else
			{
				label2.Text = "Receiving Update Information...";
				//SetControlThreadSafe ( label2, ( ) => { label2.Text = "Receiving Update Information..."; } );
				_downloadedFiles = new List<string> ( );

				var (patches, lastVersion) = _gameUpdater.GetRequiredUpdates (
					_remoteVersion,
					Resources.UpdateXMLFile,
					_forceUpdate );

				if ( patches.Count > 0 && lastVersion > 0 )
				{
					progressBar1.Value = 0;
					progressBar1.Style = ProgressBarStyle.Blocks;
					label2.Text        = "Downloading Updates...";
					_totalUpdates = patches.Count;

					await DownloadMultipleFilesAsync ( patches ).ConfigureAwait ( false );
					backgroundWorker1.RunWorkerAsync ( );
				}
				else
				{
					Utils.ShowMessageA ( "An error occurred while retrieving update information!" );
					SetControlThreadSafe ( this, Close );
				}
			}
		}

		private void BackgroundWorker1_RunWorkerCompleted ( object sender, RunWorkerCompletedEventArgs e )
		{
			SetControlThreadSafe ( progressBar1, ( ) => { progressBar1.Value = 100; } );
			SetControlThreadSafe ( label2, ( ) => { label2.Text              = "Game Updated Successfully..."; } );
			_wasUpdated = true;
			AutoUpdate.OverrideLocalGameVersion ( _remoteVersion );
            if (!_forceUpdate)
                if (!StartGameInstance())
                    Utils.ShowMessageA("An error occurred while opening a game instance");
            else
				Utils.ShowMessageA("King of Pirates game client is up to date!");

            SetControlThreadSafe(this, Close);
		}

		private void BackgroundWorker1_DoWork ( object sender, DoWorkEventArgs e )
		{
			var current = 1;
			SetControlThreadSafe ( label2,
								   ( ) => { label2.Text = "Installing Updates..."; } );
			SetControlThreadSafe ( progressBar1,
								   ( ) => { progressBar1.Value = 0; } );

			if ( _downloadedFiles.Count > 0 )
			{
                SetControlThreadSafe(label2,
                    () => { label2.Text = "Installing Updates..."; });
				foreach ( var file in _downloadedFiles )
				{
					var path = Path.Combine ( Globals.SaveDownloadsPath, file );

					var fastZip = new FastZip ( );
					fastZip.ExtractZip ( path, Globals.RootDirectory, null );

					File.Delete ( path );
					backgroundWorker1.ReportProgress ( current * 100 / _totalUpdates );
					++current;
				}
			}
		}

		private async Task DownloadFileAsync ( string url )
		{
			try
			{
				var downloadInfo = _gameUpdater.GetDownloadData ( url );
				if ( downloadInfo != null )
				{
					var savePath = Path.Combine ( Globals.SaveDownloadsPath, downloadInfo.TemporaryFile );
					_downloadedFiles.Add ( downloadInfo.TemporaryFile );

					ServicePointManager.SecurityProtocol       = SecurityProtocolType.Tls12;
					ServicePointManager.DefaultConnectionLimit = 20;

					using ( var webClient = new WebClient ( ) )
					{
						webClient.Proxy = null;

						webClient.DownloadProgressChanged += ( s, e ) =>
						{
							SetControlThreadSafe ( progressBar1, ( ) => progressBar1.Value = e.ProgressPercentage );
						};

						await webClient.DownloadFileTaskAsync ( new Uri ( url ), savePath ).ConfigureAwait ( false );
					}
				}
			}
			catch
			{
				MessageBox.Show ( "An error occurred while downloading updates!" );
			}
		}

		private Task DownloadMultipleFilesAsync ( IEnumerable<Patch> patches )
		{
			return Task.WhenAll ( patches.Select ( patch => DownloadFileAsync ( patch.FileUrl ) ) );
		}

		private bool StartGameInstance ( )
		{
			try
			{
				if ( _wasUpdated )
				{
					if ( Utils.ShowMessageOK (
						"Game has been updated to the last available version, would you like to start the game now?" ) )
					{
						var procID = Globals.StartGameInstance ( _regionIp );

						if ( procID != -1 )
						{
							Globals.LastOpenedRegion = _regionIp;
							Globals.GameInstances.Add ( procID );
							return true;
						}

						return false;
					}
				}
				else
				{
					var procID = Globals.StartGameInstance ( _regionIp );

					if ( procID != -1 )
					{
						Globals.LastOpenedRegion = _regionIp;
						Globals.GameInstances.Add ( procID );
						return true;
					}

					return false;
				}
			}
			catch
			{
				// ignored
			}

			return false;
		}

		private void CancelButton_Click ( object sender, EventArgs e )
		{
			SetControlThreadSafe ( this, Close );
		}

		private static void SetControlThreadSafe<T> ( T control, Action action )
			where T : Control
		{
			if ( control.InvokeRequired )
				try
				{
					control.Invoke ( action, null );
				}
				catch
				{
					// ignored
				}
			else
				action ( );
		}
	}
}
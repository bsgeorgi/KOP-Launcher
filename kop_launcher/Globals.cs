using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using kop_launcher.Models;

namespace kop_launcher
{
	public static class Globals
	{
		public static bool   RenderNotification      = true;
		public static bool   RenderNotificationShown = false;
		public static bool   HasBeenReported         = false;
        public static ConnectionInfo LastOpenedConnectionInfo;
        public static string LastOpenedRegion;

		public static short MaximumPortals      = 3;

		public static readonly List<int>    GameInstances         = new List<int> ( );
		public static readonly List<string> GenuineResourceHashes = new List<string> ( );
		public static readonly List<string> CurrentResourceHashes = new List<string> ( );

		public static readonly string RootDirectory =
			Path.GetDirectoryName ( Assembly.GetExecutingAssembly ( ).Location );

		public static readonly string SaveDownloadsPath = Path.Combine ( RootDirectory, "scripts", "update" );

		public static Dispatcher UiDispatcher;

        public static string SecurityCode;

        public static List<GameAccount> GameAccounts;

		public static bool KillProcess ( int pid )
		{
			var processes = Process.GetProcesses ( );

			foreach ( var process in processes.Where ( x => x.Id == pid ) )
			{
				process.Kill ( );
				return true;
			}

			return false;
		}

        private static async Task<string> GetBestServer(IEnumerable<string> regions, string defaultServer)
        {
            string server = null;
            try
            {
                var tasks = regions.Select(ip => new Ping().SendPingAsync(ip, 2000));
                var results = await Task.WhenAll(tasks);

                var data = results.ToList();

                var sortedResults = (from result in data select new Tuple<long, string> ( result.RoundtripTime, result.Address.ToString ( ) )).ToList ( );

                sortedResults = sortedResults.OrderBy(i => i.Item1).ToList();
                var (latency, address) = sortedResults.ElementAt(0);
				//"51.124.120.48"

                server = latency <= 100 ? address : defaultServer;
            }
            catch
            {
                // do nothing
            }

            return server;
        }

		public static ConnectionInfo GetServerConnectionInfo ( string server )
		{
			string ip;
            const string defaultServer = "51.124.120.48";

            var morganRegions = new List<string> { "20.68.240.41", "20.84.147.28", "51.13.69.172", "20.197.224.66", "51.124.120.48" };
			
            switch ( server )
			{
				case string external when external.ToLowerInvariant (  ).Contains ( "morgan" ):
					ip = Task.Run(async () => await GetBestServer( morganRegions, defaultServer ) ).Result;
					break;
				default:
					ip = defaultServer;
					break;
			}

            string port;
            switch ( ip )
            {
				case "20.68.240.41":
                    port = "23215";
                    break;
                case "20.84.147.28":
                    port = "56381";
                    break;
                case "51.13.69.172":
                    port = "64728";
                    break;
                case "20.197.224.66":
                    port = "14799";
                    break;

                default:
                    ip = defaultServer;
					port = "55721";
                    break;
			}

			return new ConnectionInfo { IPAddress = ip, GamePort = port };
        }

		public static int StartGameInstance ( ConnectionInfo connectionInfo, GameAccount account )
        {
			var systemPath = Path.Combine ( RootDirectory, "system" );
			var gameExe    = File.Exists ( Path.Combine ( systemPath, "game.exe" ) ) ? "game.exe" : "Game.exe";
			var startPath  = Path.Combine ( systemPath, gameExe );

            Process process;

			if (account == null)
            {
                process = new Process
                {
                    StartInfo =
                    {
                        FileName         = startPath,
                        Arguments        = $"hhfa029N27ckop iwodpuJTCM:{connectionInfo.IPAddress} nLpnZKuiFENK:{connectionInfo.GamePort}",
                        WorkingDirectory = RootDirectory
                    }
                };
            }
            else
            {
                process = new Process
                {
                    StartInfo =
                    {
                        FileName         = startPath,
                        Arguments        = account.Character != null ? 
                                            $"hhfa029N27ckop iwodpuJTCM:{connectionInfo.IPAddress} nLpnZKuiFENK:{connectionInfo.GamePort} heeQjg8TI:{account.Username},{account.Password},{account.Character}" :
                                            $"hhfa029N27ckop iwodpuJTCM:{connectionInfo.IPAddress} nLpnZKuiFENK:{connectionInfo.GamePort} heeQjg8TI:{account.Username},{account.Password}",
                        WorkingDirectory = RootDirectory
                    }
                };
            }


            if ( process.Start ( ) )
				return process.Id;

			return -1;
		}

		public static bool ProcessExists ( int id )
		{
			return Process.GetProcesses ( ).Any ( x => x.Id == id );
		}

		public static bool AnyInstancesRunning ( )
        {
            return GameInstances.Count > 0 && GameInstances.Any ( ProcessExists );
        }

		public static bool RestartGameInstances ( )
		{
			var ret = true;

			try
			{
				if ( GameInstances.Count > 0 && AnyInstancesRunning())
						foreach (var processId in GameInstances.Where ( processId => !KillProcess ( processId ) ))
                            ret = false;

				var toBeRestarted = GameInstances.Count;
				GameInstances.Clear ( );

				for ( var i = 0; i < toBeRestarted; i++ )
				{
					var connectionInfo = GetServerConnectionInfo ( LastOpenedRegion );
					var procId = StartGameInstance (connectionInfo, null );

					if ( procId != -1 )
					{
						GameInstances.Add ( procId );
					}
					else
					{
						Utils.ShowMessageA ( "An error occurred while opening a game instanc1e." );
					}
				}
			}
			catch
			{
				ret = false;
			}

			return ret;
		}

		public static bool IsGameRunning ( )
        {
            return GameInstances.Count > 0;
        }

		public static string CalculateMD5 ( string filename )
		{
			using ( var md5 = MD5.Create ( ) )
			{
				using ( var stream = File.OpenRead ( filename ) )
				{
					var hash = md5.ComputeHash ( stream );
					return BitConverter.ToString ( hash ).Replace ( "-", "" ).ToLowerInvariant ( );
				}
			}
		}

		public static async Task<bool> UrlIsReachable ( string url )
		{
			try
			{
				using ( var client = new HttpClient ( ) )
				{
					var response = await client.GetAsync ( url );
					return response.StatusCode == HttpStatusCode.OK;
				}
			}
			catch
			{
				return false;
			}
		}
	}
}
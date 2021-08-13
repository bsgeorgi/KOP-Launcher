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
using System.Windows.Threading;
using kop_launcher.Models;

namespace kop_launcher
{
	public static class Globals
	{
		public static bool   RenderNotification      = true;
		public static bool   RenderNotificationShown = false;
		public static bool   HasBeenReported         = false;
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

		public static string GetIpByServer ( string server )
		{
			string ip;

            var morganRegions = new List<string> { "83.58.35.155", "172.67.75.10", "172.67.200.80", "159.69.54.53", "54.94.234.144", "18.138.241.184" };
			
            switch ( server )
			{
				case string external when external.ToLowerInvariant (  ).Contains ( "morgan" ):
					ip = Task.Run(async () => await GetBestServer(morganRegions, "51.124.120.48")).Result;
					break;
				default:
					ip = "51.124.120.48";
					break;
			}

			return ip;
		}

		public static int StartGameInstance ( string region, GameAccount account )
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
                        Arguments        = $"startgame ip:{region}",
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
                                            $"startgame ip:{region} autolog:{account.Username},{account.Password},{account.Character}" :
                                            $"startgame ip:{region} autolog:{account.Username},{account.Password}",
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
					var region = GetIpByServer ( LastOpenedRegion );
					var procId = StartGameInstance ( region, null );

					if ( procId != -1 )
					{
						LastOpenedRegion = region;
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
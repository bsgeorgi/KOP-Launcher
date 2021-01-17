using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using kop_launcher.Properties;

// ReSharper disable StringLiteralTypo

namespace kop_launcher
{
	public static class Security
	{
		private static readonly string[] IllegalSoftware =
		{
			/* Packet Editors */
			"Tsearch",
			"ArtMoney",
			"Cheat Engine",
			"Kiki",
			"GhostKiller",
			"MoonLight",
			"Winsock Packet Editor",
			"Redox Packet Editor",
			"WPE",
			"RPE",
			"Squalr",
			"CrySearch",
			"Binwalk",
			"PSR (Pointer Sequence Reverser)",
			"PSR",
			"XenoScan",
			"Hack",
			"Cheat",
			"Packet",

			/* Debuggers */
			"PINCE",
			"Binary Ninja",
			"Ghidra",
			"x64dbg",
			"x32dbg",
			"WinDbg",
			"Hopper",
			"Ninja Ripper",
			"PIX",
			"Ollydbg",
			"IDA",
			"IDA Pro",
			"radare2",
			"GNU Project Debugger",
			"Cutter",
			"REDasm",
			"Debugger",
			"Disassembler",
			"Decompiler",
			"RenderDoc",
			"Process Hacker",
			"WinExplorer",
			"CDA: Code Dynamic Analysis",
			"CDA",
			"QuickBMS",
			"MultiEx Commander",
			"YARA",

			/* NET Debuggers */
			"dnSpy",
			"ILSpy",
			"ReClassEx",
			"ReClass.NET",
			"NET Reflector",
			"DotNet Resolver",
			"dotPeek",

			/* Injectors */
			"CFF Explorer",
			"Xenos",
			"CCI Explorer",
			"DLL Injector",
			"DLL Vaccine",
			"Injector",
			"Lunar",
			"Inject",
			"Memject",

			/* Sniffers */
			"Fiddler",
			"Wireshark",
			"Microsoft Message Analyzer",
			"Sysinternals - Process Monitor",
			"Sysinternals - Process Explorer",
			"WinDump",
			"NetworkMiner",
			"Colasoft Capsa",
			"Network Protocol Analyzer",
			"Capsa",
			"Network Packet Sniffer",
			"Paessler",
			"PRTG",
			"NetFlow Analyzer",
			"TCPdump"
		};

		private static readonly string[] Exclude =
		{
			"dllhost",
			"hamachi"
		};

		public static string GetUserDataFilePath ( )
		{
			return Path.Combine ( Globals.RootDirectory, "user", "username.txt" );
		}

		public static string IsRunningIllegalSoftware ( )
		{
			var processlist = Process.GetProcesses ( );

			foreach ( var proc in processlist )
			{
				if ( Exclude.Any ( proc.ProcessName.ToLowerInvariant ( ).Contains ) ) continue;

				if ( IllegalSoftware.Any ( s => proc.ProcessName.ToLowerInvariant ( )
													.Contains ( s.ToLowerInvariant ( ) ) ) ) return proc.ProcessName;
			}

			return null;
		}

		public static bool IsSystemHashChanged ( )
		{
			var unused = new DiscordWebHookHandler ( Resources.LauncherSecurityChannel );

			try
			{
				if ( Globals.GenuineResourceHashes.Count > 0 && Globals.CurrentResourceHashes.Count > 0 )
					for ( var i = 0; i < Globals.GenuineResourceHashes.Count; i++ )
						if ( Globals.GenuineResourceHashes.ElementAt ( i ) !=
							 Globals.CurrentResourceHashes.ElementAt ( i ) )
							return true;
			}
			catch
			{
				// ignored
			}

			return false;
		}

		public static string GetModifiedSystemFiles ( )
		{
			var holder = new List<int> ( );
			try
			{
				if ( Globals.GenuineResourceHashes.Count > 0 && Globals.CurrentResourceHashes.Count > 0 )
					for ( var i = 0; i < Globals.GenuineResourceHashes.Count; i++ )
						if ( Globals.GenuineResourceHashes.ElementAt ( i ) !=
							 Globals.CurrentResourceHashes.ElementAt ( i ) )
							holder.Add ( i );
			}
			catch
			{
				// ignored
			}

			var files = new List<string> ( );

			if ( holder.Count > 0 )
			{
				foreach ( var value in holder )
					if ( value == 0 )
						files.Add ( "Game.exe" );
					else if ( value == 1 )
						files.Add ( "MindPower3D_D8R.dll" );
					else
						files.Add ( "Engine.dll" );

				return string.Join ( ",", files.ToArray ( ) ).TrimEnd ( ',' );
			}

			return null;
		}

		public static bool UserDataExists ( )
		{
			var dir = Path.Combine ( Globals.RootDirectory, "user" );
			if ( Directory.Exists ( dir ) )
				if ( File.Exists ( GetUserDataFilePath ( ) ) )
					return true;

			return false;
		}

		public static bool CheckForInternetConnection ( )
		{
			try
			{
				ServicePointManager.DefaultConnectionLimit = 20;
				using ( var client = new WebClient ( ) )
				{
					client.Proxy = null;
					using ( client.OpenRead ( "http://google.com/generate_204" ) )
					{
						return true;
					}
				}
			}
			catch
			{
				return false;
			}
		}

		public static void KillAllGameInstances ( )
		{
			if ( Globals.GameInstances.Count > 0 )
			{
				foreach ( var processID in Globals.GameInstances ) Globals.KillProcess ( processID );

				Globals.GameInstances.Clear ( );
			}
		}

		public static string GetCurrentMachineIP ( )
		{
			try
			{
				var request = (HttpWebRequest) WebRequest.Create ( "http://ifconfig.me" );

				request.UserAgent = "curl";

				string publicIPAddress;

				request.Method = "GET";
				using ( var response = request.GetResponse ( ) )
				{
					// ReSharper disable once AssignNullToNotNullAttribute
					using ( var reader = new StreamReader ( response.GetResponseStream ( ) ) )
					{
						publicIPAddress = reader.ReadToEnd ( );
					}
				}

				return publicIPAddress.Replace ( "\n", "" );
			}
			catch
			{
				return null;
			}
		}
	}
}
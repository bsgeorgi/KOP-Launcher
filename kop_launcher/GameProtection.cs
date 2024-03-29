﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using kop_launcher.Properties;

// ReSharper disable StringLiteralTypo

namespace kop_launcher
{
	public static class GameProtection
	{
		private static readonly HashSet<string> IllegalSoftware =
			new HashSet<string> ( StringComparer.OrdinalIgnoreCase )
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

		private static readonly HashSet<string> Exclude = new HashSet<string> ( StringComparer.OrdinalIgnoreCase )
		{
			"dllhost",
			"hamachi"
		};

		private static readonly HashSet<string> IllegalSoftwareLower;

		static GameProtection ( )
		{
			IllegalSoftwareLower = IllegalSoftware
								   .Select ( x => x.ToLowerInvariant ( ) )
								   .ToHashSet ( StringComparer.OrdinalIgnoreCase );
		}

		public static string GetUserDataFilePath ( )
		{
			return Path.Combine ( Globals.RootDirectory, "user", "username.txt" );
		}

		public static string IsRunningIllegalSoftware ( )
		{
			var processlist = Process.GetProcesses ( );

			foreach ( var proc in processlist )
			{
				try
				{
					var procLower = proc.ProcessName.ToLowerInvariant ( );
					if ( Exclude.Any ( procLower.Contains ) )
						continue;

					if ( IllegalSoftwareLower.Any ( s => procLower.Contains ( s ) ) )
						return proc.ProcessName;
				}
				catch
				{
					// ignored
				}
			}

			return null;
		}

		public static bool IsSystemHashChanged ( )
		{
			var unused = new DiscordWebHookHandler ( Resources.LauncherSecurityChannel );

			try
			{
				if ( Globals.GenuineResourceHashes.Count > 0 && Globals.CurrentResourceHashes.Count > 0 )
					if ( Globals.GenuineResourceHashes.Where ( ( t, i ) => Globals.GenuineResourceHashes.ElementAt ( i ) !=
                                                                           Globals.CurrentResourceHashes.ElementAt ( i ) ).Any ( ) )
                    {
                        return true;
                    }
				/*
				 * 		for ( var i = 0; i < Globals.GenuineResourceHashes.Count; i++ )
						if ( Globals.GenuineResourceHashes.ElementAt ( i ) !=
							 Globals.CurrentResourceHashes.ElementAt ( i ) )
							return true;
				 */
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

            if ( holder.Count <= 0 ) return null;

            foreach ( var value in holder )
                switch (value)
                {
                    case 0:
                        files.Add ( "Game.exe" );
                        break;
                    case 1:
                        files.Add ( "MindPower3D_D8R.dll" );
                        break;
                    default:
                        files.Add ( "Engine.dll" );
                        break;
                }

            return string.Join ( ",", files.ToArray ( ) ).TrimEnd ( ',' );

        }

		public static bool UserDataExists ( )
		{
			var dir = Path.Combine ( Globals.RootDirectory, "user" );
            return Directory.Exists ( dir ) && File.Exists ( GetUserDataFilePath ( ) );
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
            if ( Globals.GameInstances.Count <= 0 ) return;

            foreach ( var processId in Globals.GameInstances ) Globals.KillProcess (processId);

            Globals.GameInstances.Clear ( );
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
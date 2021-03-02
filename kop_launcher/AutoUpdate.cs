using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using kop_launcher.Models;
using kop_launcher.Properties;

namespace kop_launcher
{
	public class AutoUpdate
	{
		private readonly Uri    _baseUri = new Uri ( "https://kingofpirates.net" );
		private readonly string _remoteVersion;

		public AutoUpdate ( string remoteVersion )
		{
			_remoteVersion = remoteVersion;
		}

		/*
		 * Checks if path exists, if not then creates it
		 * Returns true if path created successfully or already exists
		 */
		public static bool CheckCreateUpdatePath ( )
		{
			var path = Path.Combine ( Globals.RootDirectory, "scripts", "update" );
			try
			{
				Directory.CreateDirectory ( path );
				return true;
			}
			catch
			{
				return false;
			}
		}

		/*
		 * Returns version string
		 * If file does not exist, returns default version
		 * If exception was caught, returns null
		 */
		public string GetLocalVersion ( )
		{
			try
			{
				/*
				 * Check if update path exists
				 * Returns true if exists or was created successfully
				 */
				if ( CheckCreateUpdatePath ( ) )
				{
					var path = Path.Combine ( Globals.RootDirectory, "scripts", "update", ".version" );
					if ( File.Exists ( path ) )
					{
						// File exists, so read data and return string
						using ( TextReader tr = new StreamReader ( path, Encoding.UTF8 ) )
						{
							return tr.ReadLine ( )?.Trim ( );
						}
					}

					File.Create ( path ).Dispose ( );

					using ( TextWriter tw = new StreamWriter ( path ) )
					{
						tw.WriteLine ( Resources.DefaultGameVersion );
					}
				}
			}
			catch
			{
				return null;
			}

			return Resources.DefaultGameVersion;
		}

		public static bool OverrideLocalGameVersion ( string version )
		{
			try
			{
				var path = Path.Combine ( Globals.RootDirectory, "scripts", "update", ".version" );
                if ( !File.Exists ( path ) ) return false;

                using ( TextWriter tw = new StreamWriter ( path ) )
                {
                    tw.WriteLine ( version );
                }

                return true;

            }
			catch
			{
				return false;
			}
		}

		/*
		 * Validates if local game version matches remote game version
		 * Returns true if versions match, otherwise false
		 */
		public bool IsGameUpToDate ( )
		{
			return GetLocalVersion ( ) == _remoteVersion;
		}

		/*
		 * Casts string version to int
		 * Returns int representation of version or -1 if error occurred
		 */
		public static int CastVersionToInt ( string version )
		{
			if ( int.TryParse ( version.Replace ( ".", "" ), out var outInt ) ) return outInt;
			return -1;
		}

		public string GetFileNameFromUrl ( string url )
		{
			try
			{
				if ( !Uri.TryCreate ( url, UriKind.Absolute, out var uri ) )
					uri = new Uri ( _baseUri, url );

				return Path.GetFileName ( uri.LocalPath );
			}
			catch
			{
				return null;
			}
		}

		public static bool IsLinkReachable ( string uri )
		{
			try
			{
				var request = WebRequest.Create ( new Uri ( uri ) );
				request.Proxy  = null;
				request.Method = "HEAD";

				using ( var response = request.GetResponse ( ) )
				{
					if ( response.ContentLength > 0 ) return true;
				}
			}
			catch
			{
				return false;
			}

			return false;
		}

		public DownloadInfo GetDownloadData ( string fileUrl )
		{
			var fileName = GetFileNameFromUrl ( fileUrl );
			if ( !string.IsNullOrEmpty ( fileName ) )
				return new DownloadInfo
				{
					OriginalFile  = fileName,
					TemporaryFile = $"{Path.GetTempFileName ( )}.zip"
				};
			return null;
		}

		/*
		 * Generates a list of updates
		 * Returns list of updates bigger or equal to remote version and last patch version
		 */
		public (List<Patch> PatchList, int LastVersion) GetRequiredUpdates (
			string remoteVersionString,
			string xmlSource,
			bool forceUpdate )
		{
			var list          = new List<Patch> ( );
			var lastVersion   = 0;
			var remoteVersion = CastVersionToInt ( remoteVersionString );

			if ( remoteVersion <= 0 )
				return ( list, lastVersion );

			try
			{
				var xDoc = XDocument.Load ( xmlSource );

				var commands =
					from cmd in xDoc.Descendants ( "Update" )
					select new Patch
					{
						FileUrl      = cmd.Element ( "FileURL" )?.Value,
						FileMirror   = cmd.Element ( "FileMirror" )?.Value,
						PatchVersion = CastVersionToInt ( cmd.Element ( "Version" )?.Value )
					};

				foreach ( var patch in commands )
				{
					var version   = patch.PatchVersion;
					var patchInfo = new Patch ( );

					var patchUrl    = patch.FileUrl;
					var patchMirror = patch.FileMirror;

					var shouldUpdate = forceUpdate
						? version > 0 && !string.IsNullOrEmpty ( patch.FileUrl )
						: version > 0 && !string.IsNullOrEmpty ( patch.FileUrl ) && version <= remoteVersion;

                    if ( !shouldUpdate ) continue;

                    if ( IsLinkReachable ( patchUrl ) )
                    {
                        patchInfo.FileUrl      = patchUrl;
                        patchInfo.FileMirror   = patchMirror;
                        patchInfo.PatchVersion = version;
                    }
                    else
                    {
                        patchInfo.FileUrl      = patchMirror;
                        patchInfo.FileMirror   = patchInfo.FileUrl;
                        patchInfo.PatchVersion = version;
                    }

                    if ( !list.Contains ( patchInfo ) )
                        list.Add ( patchInfo );
                }

				// Get the last element in IEnumerable which indicates the last version
				if ( list.Count > 0 )
				{
					var last = list.Last ( );
					lastVersion = last.PatchVersion;
				}
				else
				{
					// List is empty, something has gone wrong cause version mismatched but there were no updates available
					// return -1 and throw exception in main
					lastVersion = -1;
				}
			}
			catch
			{
				// ignored
			}

			return ( PatchList: list, LastVersion: lastVersion );
		}
	}
}
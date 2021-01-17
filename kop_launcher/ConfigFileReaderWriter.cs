using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace kop_launcher
{
	internal class ConfigFileReaderWriter
	{
		public Dictionary<string, string> ReadConfigFile ( string fileName )
		{
			var configs = new Dictionary<string, string> ( );
			try
			{
				var path = Path.Combine ( Globals.RootDirectory, "system", "CandyFX", fileName );
				var line = "";

				using ( var Reader = new StreamReader ( path ) )
				{
					while ( ( line = Reader.ReadLine ( ) ) != null )
						if ( !string.IsNullOrEmpty ( line ) )
						{
							var value = line.Trim ( ).Split ( ' ' ).Last ( );
							var key   = line.Replace ( value, "" ).Replace ( "#define ", "" ).Trim ( );

							if ( !configs.ContainsKey ( key ) ) configs.Add ( key, value );
						}
				}
			}
			catch { }

			return configs;
		}

		public Dictionary<string, string> ReadCoreIniSettings ( string path )
		{
			var configs = new Dictionary<string, string> ( );
			try
			{
				if ( File.Exists ( path ) )
				{
					var iniReader = new IniFile ( path );

					if ( iniReader.KeyExists ( "musicSound", "audio" ) )
						configs.Add ( "musicSound", iniReader.Read ( "musicSound", "audio" ) );
					else
						configs.Add ( "musicSound", "100" );

					if ( iniReader.KeyExists ( "musicEffect", "audio" ) )
						configs.Add ( "musicEffect", iniReader.Read ( "musicEffect", "audio" ) );
					else
						configs.Add ( "musicEffect", "100" );

					if ( iniReader.KeyExists ( "fullScreen", "video" ) )
						configs.Add ( "fullScreen", iniReader.Read ( "fullScreen", "video" ) );
					else
						configs.Add ( "fullScreen", "0" );

					if ( iniReader.KeyExists ( "pixel1024", "video" ) )
						configs.Add ( "pixel1024", iniReader.Read ( "pixel1024", "video" ) );
					else
						configs.Add ( "pixel1024", "1" );

					if ( iniReader.KeyExists ( "depth32", "video" ) )
						configs.Add ( "depth32", iniReader.Read ( "depth32", "video" ) );
					else
						configs.Add ( "depth32", "0" );

					if ( iniReader.KeyExists ( "apparel", "gameOption" ) )
						configs.Add ( "apparel", iniReader.Read ( "apparel", "gameOption" ) );
					else
						configs.Add ( "apparel", "1" );

					if ( iniReader.KeyExists ( "effect", "gameOption" ) )
						configs.Add ( "effect", iniReader.Read ( "effect", "gameOption" ) );
					else
						configs.Add ( "effect", "1" );

					if ( iniReader.KeyExists ( "state", "gameOption" ) )
						configs.Add ( "state", iniReader.Read ( "state", "gameOption" ) );
					else
						configs.Add ( "state", "0" );

					if ( iniReader.KeyExists ( "quality", "video" ) )
						configs.Add ( "quality", iniReader.Read ( "quality", "video" ) );
					else
						configs.Add ( "quality", "0" );

					if ( iniReader.KeyExists ( "frames", "gameOption" ) )
						configs.Add ( "frames", iniReader.Read ( "frames", "gameOption" ) );
					else
						configs.Add ( "frames", "1" );

					if ( iniReader.KeyExists ( "stalls", "gameOption" ) )
						configs.Add ( "stalls", iniReader.Read ( "stalls", "gameOption" ) );
					else
						configs.Add ( "stalls", "1" );
				}
				else
				{
					/* File Does Not Exist, so we will load default settings */
					configs.Add ( "musicSound", "100" );
					configs.Add ( "musicEffect", "100" );
					configs.Add ( "fullScreen", "0" );
					configs.Add ( "pixel1024", "1" );
					configs.Add ( "depth32", "0" );
					configs.Add ( "apparel", "1" );
					configs.Add ( "effect", "1" );
					configs.Add ( "state", "0" );
					configs.Add ( "quality", "0" );
					configs.Add ( "frames", "1" );
					configs.Add ( "stalls", "1" );
				}
			}
			catch { }

			return configs;
		}

		public bool SaveConfigFile ( string fileName, Dictionary<string, string> settings )
		{
			var sb = new StringBuilder ( );

			try
			{
				foreach ( var kv in settings )
					if ( kv.Key.Contains ( "key_toggle_candyfx" ) || kv.Key.Contains ( "key_toggle_candyfx" )
																  || kv.Key.Contains ( "key_toggle_candyfx" ) )
					{
						sb.Append ( "// #define" );
						sb.Append ( " " );
						sb.Append ( kv.Key );
						sb.Append ( " " );
						sb.Append ( kv.Value );
						sb.Append ( Environment.NewLine );
					}
					else
					{
						sb.Append ( "#define" );
						sb.Append ( " " );
						sb.Append ( kv.Key );
						sb.Append ( " " );
						sb.Append ( kv.Value );
						sb.Append ( Environment.NewLine );
					}

				using ( var writer = new StreamWriter ( fileName, false ) )
				{
					writer.Write ( sb.ToString ( ) );
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool SaveGameSettings ( Dictionary<string, string> settings )
		{
			var sb       = new StringBuilder ( );
			var fileName = Path.Combine ( Globals.RootDirectory, "user", "system.ini" );
			var ini      = new IniFile ( fileName );

			try
			{
				foreach ( var kv in settings )
					if ( kv.Key == "quality" )
					{
						if ( kv.Value == "0" )
						{
							ini.Write ( "texture", "0", "video" );
							ini.Write ( "quality", "0", "video" );
						}
					}
					else if ( kv.Key == "fullScreen" || kv.Key == "pixel1024" || kv.Key == "depth32" )
					{
						ini.Write ( kv.Key, kv.Value, "video" );
					}
					else
					{
						ini.Write ( kv.Key, kv.Value, "gameOption" );
					}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool OverrideCamera ( short num )
		{
			if ( num < 1 || num > 4 )
				return false;

			try
			{
				var regPath = Path.Combine ( Globals.RootDirectory, "scripts", "lua", "table", "override", "camera" );
				var tempPath = "";
				var destination = Path.Combine ( Globals.RootDirectory, "scripts", "lua", "CameraConf1024.clu" );
				switch ( num )
				{
					case 1:
						tempPath = Path.Combine ( regPath, "low", "CameraConf1024.clu" );
						break;
					case 2:
						tempPath = Path.Combine ( regPath, "medium", "CameraConf1024.clu" );
						break;
					case 3:
						tempPath = Path.Combine ( regPath, "high", "CameraConf1024.clu" );
						break;
					case 4:
						tempPath = Path.Combine ( regPath, "ultrahigh", "CameraConf1024.clu" );
						break;
					default:
						tempPath = Path.Combine ( regPath, "medium", "CameraConf1024.clu" );
						break;
				}

				if ( File.Exists ( destination ) ) File.Delete ( destination );

				File.Copy ( tempPath, destination );
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool OverrideCamera ( bool regular )
		{
			try
			{
				var regPath = Path.Combine ( Globals.RootDirectory, "scripts", "lua", "table", "override",
											 "animation" );
				var tempPath    = "";
				var destination = Path.Combine ( Globals.RootDirectory, "scripts", "txt", "CharacterAction.tx" );

				if ( regular )
					tempPath = Path.Combine ( regPath, "reg", "CharacterAction.tx" );
				else
					tempPath = Path.Combine ( regPath, "patched", "CharacterAction.tx" );

				if ( File.Exists ( destination ) ) File.Delete ( destination );

				File.Copy ( tempPath, destination );
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
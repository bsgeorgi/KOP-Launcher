using System.Collections.Generic;
using System.IO;
using System.Text;

namespace kop_launcher.ConfigReaders
{
	internal class ConfigFileReaderWriter
	{
        public Dictionary<string, string> ReadCoreIniSettings ( string path )
		{
			var configs = new Dictionary<string, string> ( );
			try
			{
				if ( File.Exists ( path ) )
				{
					var iniReader = new IniFile ( path );

					configs.Add ( "musicSound",
								  iniReader.KeyExists ( "musicSound", "audio" )
									  ? iniReader.Read ( "musicSound", "audio" )
									  : "100" );

					configs.Add ( "musicEffect",
								  iniReader.KeyExists ( "musicEffect", "audio" )
									  ? iniReader.Read ( "musicEffect", "audio" )
									  : "100" );

					configs.Add ( "fullScreen",
								  iniReader.KeyExists ( "fullScreen", "video" )
									  ? iniReader.Read ( "fullScreen", "video" )
									  : "0" );

					configs.Add ( "pixel1024",
								  iniReader.KeyExists ( "pixel1024", "video" )
									  ? iniReader.Read ( "pixel1024", "video" )
									  : "1" );

					configs.Add (
						"depth32",
						iniReader.KeyExists ( "depth32", "video" ) ? iniReader.Read ( "depth32", "video" ) : "0" );

					configs.Add (
						"apparel",
						iniReader.KeyExists ( "apparel", "gameOption" )
							? iniReader.Read ( "apparel", "gameOption" )
							: "1" );

					configs.Add (
						"effect",
						iniReader.KeyExists ( "effect", "gameOption" )
							? iniReader.Read ( "effect", "gameOption" )
							: "1" );

                    configs.Add(
						"numericPanel",
                        iniReader.KeyExists("numericPanel", "gameOption")
                            ? iniReader.Read("numericPanel", "gameOption")
                            : "1");

					configs.Add (
						"state",
						iniReader.KeyExists ( "state", "gameOption" )
							? iniReader.Read ( "state", "gameOption" )
							: "0" );

					configs.Add (
						"quality",
						iniReader.KeyExists ( "quality", "video" ) ? iniReader.Read ( "quality", "video" ) : "0" );

					configs.Add (
						"frames",
						iniReader.KeyExists ( "frames", "gameOption" )
							? iniReader.Read ( "frames", "gameOption" )
							: "1" );

					configs.Add (
						"stalls",
						iniReader.KeyExists ( "stalls", "gameOption" )
							? iniReader.Read ( "stalls", "gameOption" )
							: "1" );
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
                    configs.Add ( "numericPanel", "1");
					configs.Add ( "state", "0" );
					configs.Add ( "quality", "0" );
					configs.Add ( "frames", "1" );
					configs.Add ( "stalls", "1" );
				}
			}
			catch
			{
				// ignored
			}

			return configs;
		}

		public bool SaveGameSettings ( Dictionary<string, string> settings )
		{
			var fileName = Path.Combine ( Globals.RootDirectory, "user", "system.ini" );
			var ini      = new IniFile ( fileName );

			try
			{
				foreach ( var kv in settings )
					switch (kv.Key)
                    {
                        case "quality":
                        {
                            if ( kv.Value == "0" )
                            {
                                ini.Write ( "texture", "0", "video" );
                                ini.Write ( "quality", "0", "video" );
                            }

                            break;
                        }
                        case "fullScreen":
                        case "pixel1024":
                        case "depth32":
                            ini.Write ( kv.Key, kv.Value, "video" );
                            break;
                        default:
                            ini.Write ( kv.Key, kv.Value, "gameOption" );
                            break;
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

		public bool OverrideAnimations ( bool regular )
		{
			try
			{
				var regPath = Path.Combine ( Globals.RootDirectory, "scripts", "lua", "table", "override",
											 "animation" );
				var tempPath    = "";
				var destination = Path.Combine ( Globals.RootDirectory, "scripts", "txt", "CharacterAction.tx" );

				tempPath = Path.Combine ( regPath, regular ? "reg" : "patched", "CharacterAction.tx" );

				if ( File.Exists ( destination ) )
					File.Delete ( destination );

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
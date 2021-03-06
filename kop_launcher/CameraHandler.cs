using System.IO;

namespace kop_launcher
{
	public class CameraHandler
	{
		public bool IsAnimationTweaked ( )
		{
			var path    = Path.Combine ( Globals.RootDirectory, "scripts", "txt", "CharacterAction.tx" );
			var tweaked = false;

			try
			{
				if ( !File.Exists ( path ) )
				{
					Utils.ShowMessageA ( "Could not locate animation config file." );
				}
				else
				{
					var hash = Globals.CalculateMD5 ( path );

					//if (hashsum != "f0c17f4f9795db413974aa1eb260baa3")
					if ( hash != "7c07d1dba5e1a59b45203c5d21cef7bd")
						tweaked = true;
				}
			}
			catch
			{
				// ignored
			}

			return tweaked;
		}

		public short GetCurrentCameraConfig ( )
		{
			var   path   = Path.Combine ( Globals.RootDirectory, "scripts", "lua", "CameraConf1024.clu" );
			short camera = -1;

			try
			{
				if ( !File.Exists ( path ) )
				{
					Utils.ShowMessageA ( "Could not locate current config file." );
				}
				else
				{
					var hash = Globals.CalculateMD5 ( path );
					switch ( hash )
					{
						//case "3228be4db1e8dffcb5afe80b5fce7bae":
						case "2438eea745eccc8499eac9e9ce3f9dfc":
							camera = 1;
							break;
						//case "06971ca3885a3bcf31d5eedf6587ac99":
						case "482e316edcf311c5765a09355a30ec7d":
							camera = 2;
							break;
						//case "6b2fc071d7c60745568edaacd056b924":
						case "815ef257475b530e21974b84c3e138de":
							camera = 3;
							break;
						//case "f21b64a99e0bd42f1b421d1d101a0ab5":
						case "1d3f6def274c79409b47ece408f5318e":
							camera = 4;
							break;
						default:
							camera = 2;
							break;
					}
				}
			}
			catch
			{
				// ignored
			}

			return camera;
		}
	}
}
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace kop_launcher.ConfigReaders
{
	internal class IniFile
	{
		private readonly string _path;
		private readonly string _exe = Assembly.GetExecutingAssembly ( ).GetName ( ).Name;

		public IniFile ( string initPath = null )
		{
			_path = new FileInfo (initPath ?? _exe + ".ini" ).FullName;
		}

		[DllImport ( "kernel32", CharSet = CharSet.Unicode )]
		private static extern long WritePrivateProfileString ( string section,
															   string key,
															   string value,
															   string filePath );

		[DllImport ( "kernel32", CharSet = CharSet.Unicode )]
		private static extern int GetPrivateProfileString ( string section,
                                                            string key,
															string default_,
															StringBuilder retVal,
															int size,
															string filepath );

		public string Read ( string key, string section = null )
		{
			var retVal = new StringBuilder ( 255 );
			GetPrivateProfileString (section ?? _exe, key, "", retVal, 255, _path );
			return retVal.ToString ( );
		}

		public void Write ( string key, string value, string section = null )
		{
			WritePrivateProfileString (section ?? _exe, key, value, _path );
		}

		public void DeleteKey ( string key, string section = null )
		{
			Write (key, null, section ?? _exe );
		}

		public void DeleteSection ( string section = null )
		{
			Write ( null, null, section ?? _exe );
		}

		public bool KeyExists ( string key, string section = null )
		{
			return Read (key, section).Length > 0;
		}
	}
}
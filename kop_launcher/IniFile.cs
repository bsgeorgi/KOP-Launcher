using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace kop_launcher
{
	internal class IniFile
	{
		private readonly string _path;
		private readonly string _exe = Assembly.GetExecutingAssembly ( ).GetName ( ).Name;

		public IniFile ( string IniPath = null )
		{
			_path = new FileInfo ( IniPath ?? _exe + ".ini" ).FullName;
		}

		[DllImport ( "kernel32", CharSet = CharSet.Unicode )]
		private static extern long WritePrivateProfileString ( string Section,
															   string Key,
															   string Value,
															   string FilePath );

		[DllImport ( "kernel32", CharSet = CharSet.Unicode )]
		private static extern int GetPrivateProfileString ( string Section,
															string Key,
															string Default,
															StringBuilder RetVal,
															int Size,
															string FilePath );

		public string Read ( string Key, string Section = null )
		{
			var RetVal = new StringBuilder ( 255 );
			GetPrivateProfileString ( Section ?? _exe, Key, "", RetVal, 255, _path );
			return RetVal.ToString ( );
		}

		public void Write ( string Key, string Value, string Section = null )
		{
			WritePrivateProfileString ( Section ?? _exe, Key, Value, _path );
		}

		public void DeleteKey ( string Key, string Section = null )
		{
			Write ( Key, null, Section ?? _exe );
		}

		public void DeleteSection ( string Section = null )
		{
			Write ( null, null, Section ?? _exe );
		}

		public bool KeyExists ( string Key, string Section = null )
		{
			return Read ( Key, Section ).Length > 0;
		}
	}
}
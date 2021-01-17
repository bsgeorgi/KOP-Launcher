using System.Windows.Forms;

namespace kop_launcher
{
	public static class Utils
	{
		public static void ShowMessageA ( string message, string caption = "KOPO" )
		{
			using ( var msg = new MessageBoxA ( message, caption ) )
			{
				msg.ShowDialog ( );
				msg.BringToFront ( );
			}
		}

		public static bool ShowMessageOK ( string message )
		{
			bool q;
			using ( var msg = new MessageBoxAccept ( message ) )
			{
				var result = msg.ShowDialog ( );
				msg.BringToFront ( );

				q = result == DialogResult.OK;
				msg.Close ( );
			}

			return q;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using kop_launcher.Forms;
using kop_launcher.Models;

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

		public static bool GetIsWindowsOld ( )
		{
			const string loc = @"SOFTWARE\Wow6432Node\Microsoft\Windows NT\CurrentVersion";
			var key          = Microsoft.Win32.Registry.LocalMachine;
			var subKey       = key.OpenSubKey ( loc );

			return subKey?.GetValue ( "ProductName" ).ToString ( ).Contains ( "Windows 7" ) == true;
        }

		public static DateTime GetServerTime ( )
		{
			return TimeZoneInfo.ConvertTime ( DateTime.Now,
											  TimeZoneInfo.FindSystemTimeZoneById (
												  "Central Europe Standard Time" ) );
		}

		public static bool PopulateRegion ( Guna2ComboBox Control )
		{
			try
			{
				if ( Control == null ) return false;

				Control.Items.Add ( "Morgan" );
				Control.Items.Add ( "Local" );
				Control.Items.Add ( "Jan" );
				Control.SelectedItem = "Select Region";

				return true;
			}
			catch
			{
				return false;
			}
		}

		public static void OpenGameSettingsForm ( )
        {
            if (Application.OpenForms.OfType<SettingsLoaderF>().Any()) return;

            var settingsLoader = new SettingsLoaderF ( );
            settingsLoader.Show ( );
        }

        public static void OpenGameLoginsForm()
        {
            if (Application.OpenForms.OfType<ManageGameLoginsF>().Any()) return;

            var settingsLoader = new ManageGameLoginsF();
            settingsLoader.Show();
        }

		public static IEnumerable<Portal> GetDefaultPortals ( )
		{
			return new List<Portal>
			{
				new Portal
				{
					PortalName = "Forsaken City",
					OpeningInfo = new PortalOpeningInfo ( TimeSpan.Zero,
														  TimeSpan.FromHours ( 3 ),
														  TimeSpan.FromMinutes ( 60 ) )
				},
				new Portal
				{
					PortalName = "Dark Swamp",
					OpeningInfo = new PortalOpeningInfo ( TimeSpan.Zero,
														  TimeSpan.FromHours ( 3 ),
														  TimeSpan.FromMinutes ( 60 ) )
				},
				new Portal
				{
					PortalName = "Chaos Argent",
					OpeningInfo = new PortalOpeningInfo ( TimeSpan.FromHours ( 11 ),
														  TimeSpan.FromHours ( 12 ),
														  TimeSpan.FromMinutes ( 30 ) )
				},
				new Portal
				{
					PortalName = "Demonic World",
					OpeningInfo = new PortalOpeningInfo ( TimeSpan.Zero,
														  TimeSpan.FromHours ( 3 ),
														  TimeSpan.FromMinutes ( 40 ) )
				},
			};
		}
	}

	/* Custom Colour Table for Tray Menu */
	public class CustomColorTable : ProfessionalColorTable
	{
		public override Color MenuItemSelected => Color.Transparent;

		public override Color MenuBorder => Color.Transparent;

		public override Color MenuItemBorder => Color.Transparent;

		public override Color SeparatorDark => Color.FromArgb ( 72, 80, 88 );
	}
}
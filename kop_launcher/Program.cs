﻿using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace kop_launcher
{
	internal static class Program
	{
		/// <summary>
		///     The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main ( )
		{
			//if (!ProcessExtensions.ParentProcessUtilities.GetParentProcess().ProcessName.ToLowerInvariant().Contains("kop")
			//	&& !ProcessExtensions.ParentProcessUtilities.GetParentProcess().ProcessName.ToLowerInvariant().Contains("launcher"))
			////{
			//	MessageBox.Show("Please open the launcher correctly!", "KOPO - error");
			//	return;
			//}
			if ( !GameProtection.CheckForInternetConnection ( ) )
			{
				MessageBox.Show ( "Please ensure an internet connection has been established!", "KOPO - error" );
				return;
			}

			if ( Environment.OSVersion.Version.Major >= 6 )
				SetProcessDPIAware ( );

			var mutex = new Mutex ( false, "GetDuplicateApp" );
			try
			{
				if ( mutex.WaitOne ( 0, false ) )
				{
					// Run the application
					Application.EnableVisualStyles ( );
					Application.SetCompatibleTextRenderingDefault ( false );
					Application.ApplicationExit         += Application_ApplicationExit;
					AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
					Application.Run ( new KopmainF ( ) );
				}
				else
				{
					MessageBox.Show ( "An instance of the application is already running", "KOPO - error" );
				}
			}
			finally
            {
                mutex.Close ( );
            }
		}

		private static void CurrentDomain_ProcessExit ( object sender, EventArgs e )
		{
            if (!Globals.IsGameRunning()) return;

            foreach (var processId in Globals.GameInstances)
                Globals.KillProcess(processId);
		}

		private static void Application_ApplicationExit ( object sender, EventArgs e )
        {
            if ( !Globals.IsGameRunning ( ) ) return;

			foreach ( var processId in Globals.GameInstances )
				Globals.KillProcess (processId);
		}

		[DllImport ( "user32.dll" )]
		private static extern bool SetProcessDPIAware ( );
	}
}
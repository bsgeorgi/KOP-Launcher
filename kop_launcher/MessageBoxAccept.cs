using System;
using System.Windows.Forms;

namespace kop_launcher
{
	public partial class MessageBoxAccept : Form
	{
		public MessageBoxAccept ( string message )
		{
			InitializeComponent ( );
			label1.Text = message;
		}

		private void guna2Button1_Click ( object sender, EventArgs e )
		{
			DialogResult = DialogResult.OK;
			Close ( );
		}

		private void guna2Button2_Click ( object sender, EventArgs e )
		{
			DialogResult = DialogResult.Cancel;
			Close ( );
		}
	}
}
using System;
using System.Windows.Forms;

namespace kop_launcher
{
	public partial class MessageBoxA : Form
	{
		public MessageBoxA ( string message, string caption = "KOPO" )
		{
			InitializeComponent ( );
			Text        = caption;
			label1.Text = message;
		}

		public sealed override string Text
		{
			get => base.Text;
			set => base.Text = value;
		}

		private void guna2Button1_Click ( object sender, EventArgs e )
		{
			Close ( );
		}
	}
}
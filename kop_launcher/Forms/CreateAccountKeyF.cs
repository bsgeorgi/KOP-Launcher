using System;
using System.Windows.Forms;

namespace kop_launcher.Forms
{
    public partial class CreateAccountKeyF : Form
    {
        public string SecureKey => secureKey.Text;

        public CreateAccountKeyF()
        {
            InitializeComponent ( );
            secureKey.Select ( );
            secureKey.Focus ( );
        }

        private void guna2Button1_Click ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.OK;
            Close ( );
        }

        private void secureKey_KeyDown ( object sender, KeyEventArgs e )
        {
            if ( e.KeyData == Keys.Enter ) guna2Button1.PerformClick (  );
        }
    }
}
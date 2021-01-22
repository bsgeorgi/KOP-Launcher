using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using kop_launcher.Models;

namespace kop_launcher.Forms
{
    public partial class ManageGameLoginsF : Form
    {
        private const string SelectAccount   = "Select Account";
        private const string SelectCharacter = "Select Character";
        public ManageGameLoginsF()
        {
            InitializeComponent();
            GameAccounts.Items.Add(SelectAccount);
            GameAccounts.SelectedItem = SelectAccount;
            GameCharacters.Items.Add(SelectCharacter);
            GameCharacters.SelectedItem = SelectCharacter;
        }

        private void guna2CustomCheckBox2_CheckedChanged(object sender, System.EventArgs e)
        {
            if (!(sender is Guna2CustomCheckBox ck))
                return;

            ck.ShadowDecoration.Enabled = ck.Checked;

            if ( ck.Name == "LoginCharCheckBox" && ck.Enabled )
            {
                GameCharacters.Enabled = ck.Enabled;
            }
        }

        private void SetPanelVisible(short panelType, bool visible)
        {
            if (panelType == 1)
            {
                acclabel.Visible                 = visible;
                AccountUsernameTextBox.Visible   = visible;
                passlabel.Visible                = visible;
                AccountPasswordTextBox.Visible   = visible;
                AddAccountBtn.Visible            = visible;
                DeleteAccountBtn.Visible         = visible;

                chalabel.Visible                 = !visible;
                CharacterNameTextBox.Visible     = !visible;

                AddCharacterBtn.Visible          = !visible;
                DeleteCharacterBtn.Visible       = !visible;
            }
            else
            {
                acclabel.Visible                 = !visible;
                AccountUsernameTextBox.Visible   = !visible;
                passlabel.Visible                = !visible;
                AccountPasswordTextBox.Visible   = !visible;
                AddAccountBtn.Visible            = !visible;
                DeleteAccountBtn.Visible         = !visible;

                chalabel.Visible                 = visible;
                CharacterNameTextBox.Visible     = visible;

                AddCharacterBtn.Visible          = visible;
                DeleteCharacterBtn.Visible       = visible;
            }
        }

        private void GameCharacters_Click(object sender, System.EventArgs e)
        {
            SetPanelVisible(1, false);
            SetPanelVisible(2, true);
        }

        private void GameAccounts_Click(object sender, System.EventArgs e)
        {
            SetPanelVisible(1, true);
            SetPanelVisible(2, false);
        }

        private void AddAccountBtn_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(AccountUsernameTextBox.Text) &&
                !string.IsNullOrEmpty(AccountPasswordTextBox.Text))
            {
                GameAccount gameAccount = new GameAccount()
                {
                    Password = AccountPasswordTextBox.Text,
                    Username = AccountUsernameTextBox.Text
                };

                if (!GameAccounts.Items.Contains(AccountUsernameTextBox.Text))
                    GameAccounts.Items.Add(AccountUsernameTextBox.Text);

                GameAccounts.SelectedItem = AccountUsernameTextBox.Text;

                AccountPasswordTextBox.Clear();
                AccountUsernameTextBox.Clear();
            }
            else
            {
                Utils.ShowMessageA("Please fill out all the required fields!");
            }
        }
    }
}

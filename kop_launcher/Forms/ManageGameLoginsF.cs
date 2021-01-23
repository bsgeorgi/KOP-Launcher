using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using kop_launcher.Models;

namespace kop_launcher.Forms
{
    public partial class ManageGameLoginsF : Form
    {
        private const string SelectAccount   = "Select Account";
        private const string SelectCharacter = "Enter Character Name...";
        private GameAccountsController _gameAccountsController;
        private List<GameAccount> _gameAccounts;
        public ManageGameLoginsF()
        {
            var cipher = new StringCipher();

            if (cipher.CheckRetrieveKey() == null)
            {
                if (!cipher.GenerateKey(Utils.ShowSecurePasswordF()))
                {
                    Utils.ShowMessageA("An error occured while creating a security code.");
                    Close();
                }
            }

            Globals.SecurityCode = cipher.CheckRetrieveKey();

            InitializeComponent();

            DefaultCharacterTextbox.PlaceholderText = SelectCharacter;

            _gameAccountsController = new GameAccountsController( Globals.SecurityCode );

            _gameAccounts = _gameAccountsController.GetFileData();

            Globals.GameAccounts = _gameAccounts;
            PopulateGameAccounts(_gameAccounts);
        }

        private void RefreshForm()
        {
            Controls.Clear();
            InitializeComponent();

            GameAccounts.Items.Add(SelectAccount );
            GameAccounts.SelectedItem = SelectAccount;

            DefaultCharacterTextbox.PlaceholderText = SelectCharacter;

            _gameAccountsController = new GameAccountsController ( Globals.SecurityCode );
            _gameAccounts = _gameAccountsController.GetFileData ( );

            Globals.GameAccounts = _gameAccounts;

            PopulateGameAccounts( _gameAccounts );
        }

        private void guna2CustomCheckBox2_CheckedChanged ( object sender, System.EventArgs e )
        {
            if (! ( sender is Guna2CustomCheckBox ck ) ) return;

            ck.ShadowDecoration.Enabled = ck.Checked;

            if ( ck.Name == "LoginCharCheckBox" )
            {
                DefaultCharacterTextbox.Enabled = ck.Enabled;
            }
        }

        private void PopulateGameAccounts ( IEnumerable<GameAccount> accounts )
        {
            GameAccounts.Items.Clear ( );
            GameAccounts.Items.Add(SelectAccount);
            GameAccounts.SelectedItem = SelectAccount;

            if ( accounts == null ) return;

            foreach ( var account in accounts.Where ( account => !GameAccounts.Items.Contains ( account ) ) )
            {
                GameAccounts.Items.Add ( account.Username );
            }
        }

        private void AddUpdateGameAccount ( )
        {
            if ( !string.IsNullOrEmpty ( AccountUsernameTextBox.Text ) && !string.IsNullOrEmpty ( AccountPasswordTextBox.Text ) )
            {
                var character  = DefaultCharacterTextbox.Text;
                var isCharacterEmpty = string.IsNullOrEmpty ( character );

                var characterUpdateRequired = ForceChaLoginBox.Checked && !isCharacterEmpty;

                var gameAccount = new GameAccount
                {
                    Password            = AccountPasswordTextBox.Text,
                    Username            = AccountUsernameTextBox.Text,
                    ForceCharacterLogin = characterUpdateRequired ? '1' : '0',
                    Character           = characterUpdateRequired ? character : null
                };

                if ( _gameAccountsController.AppendAccount ( gameAccount, true ) )
                {
                    GameAccounts.Items.Add ( gameAccount.Username );
                    GameAccounts.SelectedItem = gameAccount.Username;

                    Utils.ShowMessageA( _gameAccountsController.CheckAccountExists ( gameAccount.Username )
                        ? "Account has been successfully updated."
                        : "Account has been successfully saved." );

                    RefreshForm ( );
                }
            }
            else
                Utils.ShowMessageA ( "Please fill out all the required fields." );
        }

        private void AccountUsernameTextBox_KeyDown ( object sender, KeyEventArgs e )
        {
            if ( e.KeyData != Keys.Enter ) return;

            AccountPasswordTextBox.Select ( );
            AccountPasswordTextBox.Focus ( );
        }

        private void AccountPasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyData != Keys.Enter ) return;

            DefaultCharacterTextbox.Focus ( );
            DefaultCharacterTextbox.Select ( );
        }

        private void GameAccounts_SelectedIndexChanged ( object sender, System.EventArgs e )
        {
            DeleteAccountBtn.Enabled = GameAccounts.SelectedIndex >= 1;

            if (_gameAccounts == null) return;

            var accountInfo = _gameAccounts.Where ( account => account.Username == GameAccounts.SelectedItem.ToString( ) );
            var gameAccounts = accountInfo.ToList ( );

            foreach ( var account in gameAccounts )
            {
                AccountUsernameTextBox.Text = account.Username;
                AccountPasswordTextBox.Text = account.Password;
                ForceChaLoginBox.Checked    = account.ForceCharacterLogin == '1';

                if ( account.Character == null ) continue;

                DefaultCharacterTextbox.Text = account.Character;
            }
        }

        private void DeleteAccountBtn_Click(object sender, System.EventArgs e)
        {
            var account = GameAccounts.SelectedItem.ToString ( );

            if ( _gameAccountsController.DeleteAccount( account, true ) )
            {
                Utils.ShowMessageA ( "Account was successfully removed from game launcher." );

                RefreshForm ( );
            }
            else
                Utils.ShowMessageA ( "An error occured while deleting this account." );
        }

        private void label1_Click ( object sender, System.EventArgs e )
        {
            ForceChaLoginBox.Checked = !ForceChaLoginBox.Checked;
        }

        private void DefaultCharacterTextbox_KeyDown ( object sender, KeyEventArgs e )
        {
            if ( e.KeyData != Keys.Enter ) return;
            AddUpdateGameAccount ( );
        }

        private void DefaultCharacterTextbox_TextChanged ( object sender, System.EventArgs e )
        { 
            ForceChaLoginBox.Checked = DefaultCharacterTextbox.Text.Length > 1;
        }

        private void ApplyButtonBtn_Click ( object sender, System.EventArgs e )
        {
            AddUpdateGameAccount ( );
        }
    }
}

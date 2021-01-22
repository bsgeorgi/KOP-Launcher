using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using kop_launcher.Models;

namespace kop_launcher.Forms
{
    public partial class ManageGameLoginsF : Form
    {
        private const string SelectAccount   = "Select Account";
        private const string SelectCharacter = "Select Character";
        private GameAccountsController _gameAccountsController;
        private List<GameAccount> _gameAccounts;
        public ManageGameLoginsF()
        {
            InitializeComponent();

            GameCharacters.Items.Add(SelectCharacter);
            GameCharacters.SelectedItem = SelectCharacter;

            _gameAccountsController = new GameAccountsController();
            _gameAccounts = _gameAccountsController.GetFileData();
            Globals.GameAccounts = _gameAccounts;
            AddAccounts(_gameAccounts);
        }

        void RefreshAll()
        {
            Controls.Clear();
            InitializeComponent();

            GameAccounts.Items.Add(SelectAccount);
            GameAccounts.SelectedItem = SelectAccount;
            GameCharacters.Items.Add(SelectCharacter);
            GameCharacters.SelectedItem = SelectCharacter;

            _gameAccountsController = new GameAccountsController();
            _gameAccounts = _gameAccountsController.GetFileData();
            AddAccounts(_gameAccounts);
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

        private void AddAccounts(IEnumerable<GameAccount> accounts)
        {
            GameAccounts.Items.Clear();
            GameAccounts.Items.Add(SelectAccount);
            GameAccounts.SelectedItem = SelectAccount;
            foreach (var account in accounts.Where(account => !GameAccounts.Items.Contains(account)))
            {
                GameAccounts.Items.Add(account.Username);
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

        void RefreshData()
        {
            _gameAccounts = _gameAccountsController.GetFileData();
            Globals.GameAccounts = _gameAccounts;
            AddAccounts(_gameAccounts);
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

        private void AddAccount()
        {
            if (!string.IsNullOrEmpty(AccountUsernameTextBox.Text) &&
                !string.IsNullOrEmpty(AccountPasswordTextBox.Text))
            {
                var gameAccount = new GameAccount()
                {
                    Password = AccountPasswordTextBox.Text,
                    Username = AccountUsernameTextBox.Text
                };

                _gameAccountsController = new GameAccountsController();
                if (_gameAccountsController.AppendAccount(gameAccount))
                {
                    GameAccounts.Items.Add(AccountUsernameTextBox.Text);

                    GameAccounts.SelectedItem = AccountUsernameTextBox.Text;

                    Utils.ShowMessageA("Account has been successfully saved.");

                    RefreshAll();
                }
            }
            else
            {
                Utils.ShowMessageA("Please fill out all the required fields.");
            }
        }

        private void AddCharacter()
        {
            string character = null;
            if (GameCharacters.Items.Count > 1)
                character = GameCharacters.Items[1].ToString();

            if (!string.IsNullOrEmpty(CharacterNameTextBox.Text) && GameAccounts.SelectedIndex > 0)
            {
                _gameAccountsController = new GameAccountsController();
                var account = GameAccounts.SelectedItem.ToString();

                if (_gameAccountsController.AppendCharacter(account, CharacterNameTextBox.Text))
                {
                    GameCharacters.Items.Add(CharacterNameTextBox.Text);

                    if (!string.IsNullOrEmpty(character))
                        GameCharacters.Items.Remove(character);

                    GameCharacters.SelectedItem = CharacterNameTextBox.Text;

                    CharacterNameTextBox.Clear();

                    Utils.ShowMessageA("Character has been successfully saved.");
                }
            }
            else
            {
                Utils.ShowMessageA("Please fill out all the required fields.");
            }
        }

        private void AddAccountBtn_Click(object sender, System.EventArgs e)
        {
            AddAccount();
        }

        private void AccountUsernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AccountPasswordTextBox.Select();
                AccountPasswordTextBox.Focus();
            }
        }

        private void AccountPasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter) return;
            AddAccount();
        }

        private void GameAccounts_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            GameCharacters.Enabled = LoginCharCheckBox.Checked && GameAccounts.SelectedIndex > 0;
            DeleteAccountBtn.Enabled = GameAccounts.SelectedIndex > 0;

            if (string.IsNullOrEmpty(GameAccounts.SelectedItem.ToString()) || _gameAccounts == null || _gameAccounts.Count == 0) return;

            var accountInfo = _gameAccounts.Where(account => account.Username == GameAccounts.SelectedItem.ToString());
            var gameAccounts = accountInfo.ToList();

            foreach (var account in gameAccounts)
            {
                AccountUsernameTextBox.Text = account.Username;
                AccountPasswordTextBox.Text = account.Password;
            }

            foreach (var account in gameAccounts.Where(act => act.Character != null))
            {
                if (!GameCharacters.Items.Contains(account.Character))
                    GameCharacters.Items.Add(account.Character);
            }
        }

        private void GameCharacters_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DeleteCharacterBtn.Enabled = LoginCharCheckBox.Checked && GameCharacters.SelectedIndex > 0;

            if (GameCharacters.SelectedIndex > 0)
                CharacterNameTextBox.Text = GameCharacters.SelectedItem.ToString();
        }

        private void DeleteCharacterBtn_Click(object sender, System.EventArgs e)
        {
            var character = GameCharacters.SelectedItem.ToString();
            var account = GameAccounts.SelectedItem.ToString();

            if (_gameAccountsController.DeleteCharacter(account, character))
            {
                Utils.ShowMessageA("Character was successfully removed from this account.");
                GameCharacters.Items.Remove(character);
                GameCharacters.Refresh();
                DeleteCharacterBtn.Enabled = false;
            }
            else
                Utils.ShowMessageA("An error occured while deleting character from this.");

        }

        private void DeleteAccountBtn_Click(object sender, System.EventArgs e)
        {
            var account = GameAccounts.SelectedItem.ToString();

            if (_gameAccountsController.DeleteAccount(account))
            {
                Utils.ShowMessageA("Account was successfully removed from game launcher.");
                GameAccounts.Items.Remove(account);
                GameAccounts.SelectedItem = GameAccounts.Items[0];
                DeleteAccountBtn.Enabled = false;

                RefreshAll();
            }
            else
                Utils.ShowMessageA("An error occured while deleting this account.");
        }

        private void AddCharacterBtn_Click(object sender, System.EventArgs e)
        {
            AddCharacter();
        }

        private void CharacterNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter) return;
            AddCharacter();
        }
    }
}

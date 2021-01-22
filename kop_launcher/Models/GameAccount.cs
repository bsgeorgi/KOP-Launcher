namespace kop_launcher.Models
{
    class GameAccount
    {
        private string _hashedPassword;
        public string Username { get; set; }

        public string Password
        {
            get => _hashedPassword;
            set => _hashedPassword = SecurePasswordHasher.Hash( value );
        }
    }
}

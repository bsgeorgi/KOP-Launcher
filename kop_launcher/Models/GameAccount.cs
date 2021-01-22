namespace kop_launcher.Models
{
    public class GameAccount
    {
        public string Username { get; set; }
        public string Character { get; set; }

        public string Password
        {
            get;
            set;
            //set => _hashedPassword = SecurePasswordHasher.Hash( value );
        }
    }
}

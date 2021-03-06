using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using kop_launcher.Models;

namespace kop_launcher
{
    public class GameAccountsController
    {
        /*
         * Login.dat file structure:
         * line 1: account count number
         * line 2: force cha login (0/ 1),account 1 username,password,character(nullable)
         * line 2: force cha login (0/ 1),account 2 username,password,character(nullable)
         * line n: force cha login (0/ 1),account n username,password,character(nullable)
         */

        private readonly string _folderPath;
        private readonly string _filePath;
        private readonly string _key;
        private readonly List<string> _fileContents;

        public GameAccountsController ( string key, string folderPath = "user", string filePath = "login.txt" )
        {
            _folderPath = folderPath;
            _filePath = filePath;
            _key = key;
            _fileContents = GetFileLines ( )?.ToList ( );
        }

        private string CheckFileReachable()
        {
            try
            {
                var dir = Path.Combine ( Globals.RootDirectory, _folderPath );
                var pathToFile = Path.Combine ( dir, _filePath );

                if ( Directory.Exists ( dir ) )
                {
                    if ( !File.Exists ( pathToFile ) )
                        File.Create ( pathToFile ).Dispose ( );
                }
                else
                {
                    Directory.CreateDirectory ( dir );
                    File.Create ( pathToFile ).Dispose ( );
                }

                return pathToFile;
            }
            catch
            {
                return null;
            }
        }

        private short GetTotalAccounts()
        {
            try
            {
                var pathToFile = CheckFileReachable ( );
                var firstLine = File.ReadLines ( pathToFile ).FirstOrDefault ( );
                var num = new StringCipher ( ).DecryptString ( firstLine, _key );

                return Convert.ToInt16 ( num );
            }
            catch
            {
                return 1;
            }
        }

        private IEnumerable<string> GetFileLines()
        {
            try
            {
                if ( new FileInfo ( CheckFileReachable ( ) ).Length == 0 ) return null;

                var encryptedText = File.ReadAllText ( CheckFileReachable ( ) );

                var text = new StringCipher ( ).DecryptString ( encryptedText, _key );

                var lines = text.Split ( new[] {Environment.NewLine}, StringSplitOptions.None );

                return lines.Where ( line => !string.IsNullOrEmpty ( line ) );
            }
            catch
            {
                return null;
            }
        }

        public List<GameAccount> GetFileData()
        {
            try
            {
                var list = new List<GameAccount> ( );
                var lines = _fileContents;

                foreach (var line in lines.Skip ( 1 ))
                {
                    var contents = line.Split ( ',' );
                    var account = new GameAccount ( )
                    {
                        Character = contents.Length > 3 ? contents[3] : null,
                        Password = contents[2],
                        Username = contents[1],
                        ForceCharacterLogin = char.Parse ( contents[0] )
                    };

                    if ( !list.Contains ( account ) )
                        list.Add ( account );
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        private bool SaveToFile ( int accountTotal, IReadOnlyCollection<GameAccount> gameAccounts, bool encrypt )
        {
            try
            {
                var path = CheckFileReachable ( );

                if ( accountTotal <= 0 || gameAccounts == null ) return false;

                var cipher = new StringCipher ( );
                var sb = new StringBuilder ( );

                sb.AppendLine ( accountTotal.ToString ( ) );

                foreach (var account in gameAccounts)
                {
                    var withCharacter =
                        $"{account.ForceCharacterLogin},{account.Username},{account.Password},{account.Character}";
                    var withoutCharacter = $"{account.ForceCharacterLogin},{account.Username},{account.Password}";

                    sb.AppendLine ( account.Character == null ? withoutCharacter : withCharacter );
                }

                using (var sw = new StreamWriter ( path, false ))
                    sw.Write ( cipher.EncryptString ( sb.ToString ( ), _key ) );

                return true;
            }
            catch
            {
                //MessageBox.Show ( e.Message );
                return false;
            }
        }

        public bool CheckAccountExists ( string accountUsername )
        {
            var gameAccounts = GetFileData ( );

            return gameAccounts != null && gameAccounts.Any ( act => act.Username == accountUsername );
        }

        public bool AppendAccount ( GameAccount account, bool encrypt )
        {
            try
            {
                var nextAccount = GetTotalAccounts ( ) + 1;

                var gameAccounts = GetFileData ( );

                if ( gameAccounts != null && gameAccounts.Any ( act => act.Username == account.Username ) )
                {
                    gameAccounts.RemoveAll ( act => act.Username == account.Username );
                }

                if ( gameAccounts == null || gameAccounts.Count == 0 )
                {
                    nextAccount = 1;
                    gameAccounts = new List<GameAccount> ( );
                }

                gameAccounts?.Add ( account );

                return SaveToFile ( nextAccount, gameAccounts, encrypt );
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAccount ( string accountUsername, bool encrypt )
        {
            try
            {
                var nextAccount = GetTotalAccounts ( ) - 1 == 0 ? 1 : GetTotalAccounts (  );

                var gameAccounts = GetFileData ( );

                gameAccounts.RemoveAll ( act => act.Username == accountUsername );

                return SaveToFile ( nextAccount, gameAccounts, encrypt );
            }
            catch
            {
                return false;
            }
        }
    }

    public class StringCipher
    {
        public string CheckRetrieveKey ( string fileName = "account.key" )
        {
            if ( fileName == null ) throw new ArgumentNullException ( nameof(fileName) );

            try
            {
                var dir = Path.Combine ( Globals.RootDirectory, "user" );
                var pathToFile = Path.Combine ( dir, fileName );

                if ( !Directory.Exists ( dir ) ) return null;
                return File.Exists ( pathToFile ) ? File.ReadAllText ( pathToFile ) : null;
            }
            catch
            {
                return null;
            }
        }

        public bool GenerateKey ( string key, string fileName = "account.key" )
        {
            try
            {
                var dir = Path.Combine ( Globals.RootDirectory, "user" );
                var pathToFile = Path.Combine ( dir, fileName );

                if ( File.Exists ( pathToFile ) ) return false;

                using (var sw = new StreamWriter ( pathToFile, false, Encoding.UTF8 ))
                {
                    var pass = new StringCipher ( ).EncryptString ( "kingofpirates.net", key );
                    sw.Write ( pass.Substring ( 0, 32 ) );
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public string EncryptString ( string plainText, string password )
        {
            if ( plainText == null )
                return null;

            var bytesToBeEncrypted = Encoding.UTF8.GetBytes ( plainText );
            var passwordBytes = Encoding.UTF8.GetBytes ( password );

            passwordBytes = SHA256.Create ( ).ComputeHash ( passwordBytes );

            var bytesEncrypted = Encrypt ( bytesToBeEncrypted, passwordBytes );

            return Convert.ToBase64String ( bytesEncrypted );
        }

        public string DecryptString ( string encryptedText, string password )
        {
            if ( encryptedText == null ) return null;

            var bytesToBeDecrypted = Convert.FromBase64String ( encryptedText );
            var passwordBytes = Encoding.UTF8.GetBytes ( password );

            passwordBytes = SHA256.Create ( ).ComputeHash ( passwordBytes );

            var bytesDecrypted = Decrypt ( bytesToBeDecrypted, passwordBytes );

            return Encoding.UTF8.GetString ( bytesDecrypted );
        }

        private static byte[] Encrypt ( byte[] bytesToBeEncrypted, byte[] passwordBytes )
        {
            byte[] encryptedBytes;

            var saltBytes = new byte[] {1, 2, 3, 4, 5, 6, 7, 8};

            using (var ms = new MemoryStream ( ))
            {
                using (var aes = new RijndaelManaged ( ))
                {
                    var key = new Rfc2898DeriveBytes ( passwordBytes, saltBytes, 1000 );

                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    aes.Key = key.GetBytes ( aes.KeySize / 8 );
                    aes.IV = key.GetBytes ( aes.BlockSize / 8 );

                    aes.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream ( ms, aes.CreateEncryptor ( ), CryptoStreamMode.Write ))
                    {
                        cs.Write ( bytesToBeEncrypted, 0, bytesToBeEncrypted.Length );
                        cs.Close ( );
                    }

                    encryptedBytes = ms.ToArray ( );
                }
            }

            return encryptedBytes;
        }

        private static byte[] Decrypt ( byte[] bytesToBeDecrypted, byte[] passwordBytes )
        {
            byte[] decryptedBytes;

            var saltBytes = new byte[] {1, 2, 3, 4, 5, 6, 7, 8};

            using (var ms = new MemoryStream ( ))
            {
                using (var aes = new RijndaelManaged ( ))
                {
                    var key = new Rfc2898DeriveBytes ( passwordBytes, saltBytes, 1000 );

                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    aes.Key = key.GetBytes ( aes.KeySize / 8 );
                    aes.IV = key.GetBytes ( aes.BlockSize / 8 );
                    aes.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream ( ms, aes.CreateDecryptor ( ), CryptoStreamMode.Write ))
                    {
                        cs.Write ( bytesToBeDecrypted, 0, bytesToBeDecrypted.Length );
                        cs.Close ( );
                    }

                    decryptedBytes = ms.ToArray ( );
                }
            }

            return decryptedBytes;
        }
    }
}
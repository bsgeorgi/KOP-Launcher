using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using kop_launcher.Models;

namespace kop_launcher
{
    public class GameAccountsController
    {
        /*
         * Login.dat file structure:
         * line 1: account count number
         * line 2: account 1 username,password,character(nullable)
         * line 2: account 2 username,password,character(nullable)
         * line n: account n username,password,character(nullable)
         */

        private readonly string _folderPath;
        private readonly string _filePath;
        private readonly List<string> _fileContents;
        public GameAccountsController(string folderPath = "user", string filePath = "login.dat")
        {
            _folderPath = folderPath;
            _filePath = filePath;
            _fileContents = GetFileLines().ToList();
        }
        private string CheckFileReachable()
        {
            try
            {
                var dir = Path.Combine(Globals.RootDirectory, _folderPath);
                var pathToFile = Path.Combine(dir, _filePath);

                if (Directory.Exists(dir))
                {
                    if (!File.Exists(pathToFile))
                        File.Create(pathToFile).Dispose();
                }
                else
                {
                    Directory.CreateDirectory(dir);
                    File.Create(pathToFile).Dispose();
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
                var pathToFile = CheckFileReachable();
                return Convert.ToInt16(File.ReadLines(pathToFile).FirstOrDefault());
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
                return File.ReadLines(CheckFileReachable()).Where(line => !string.IsNullOrEmpty(line));
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
                var list = new List<GameAccount>();
                var lines = _fileContents;

                foreach (var line in lines.Skip(1))
                {
                    var contents = line.Split(',');
                    var account = new GameAccount()
                    {
                        Character = contents.Length > 2 ? contents[2] : null,
                        Password = contents[1],
                        Username = contents[0]
                    };

                    if (!list.Contains(account))
                        list.Add(account);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        private bool SaveToFile(int accountTotal, List<GameAccount> gameAccounts)
        {
            try
            {
                var path = CheckFileReachable();
                using (var sw = new StreamWriter(path, false))
                {
                    if (accountTotal <= 0 || gameAccounts == null)
                    {
                        sw.WriteLine(Environment.NewLine);
                    }
                    else
                    {
                        sw.WriteLine(accountTotal);
                        foreach (var account in gameAccounts)
                        {
                            sw.WriteLine(account.Character == null
                                ? $"{account.Username},{account.Password}"
                                : $"{account.Username},{account.Password},{account.Character}");
                        }

                        sw.WriteLine(Environment.NewLine);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AppendAccount(GameAccount account)
        {
            try
            {
                var nextAccount = GetTotalAccounts() + 1;

                var gameAccounts = GetFileData();

                if (gameAccounts == null || gameAccounts.Count == 0)
                    nextAccount = 1;

                if (gameAccounts != null && gameAccounts.Any(act => act.Username == account.Username))
                {
                    Utils.ShowMessageA("You have already added this account!");
                    return false;
                }

                gameAccounts?.Add(account);

                return SaveToFile(nextAccount, gameAccounts);
            }
            catch
            {
                return false;
            }
        }

        public bool AppendCharacter(string accountUsername, string characterName)
        {
            try
            {
                var nextAccount = GetTotalAccounts();

                var gameAccounts = GetFileData();

                foreach (var act in gameAccounts.Where(x => x.Username == accountUsername))
                    act.Character = characterName;

                return SaveToFile(nextAccount, gameAccounts);
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteAccount(string accountUsername)
        {
            try
            {
                var nextAccount = GetTotalAccounts() - 1;

                var gameAccounts = GetFileData();

                gameAccounts.RemoveAll(act => act.Username == accountUsername);

                return SaveToFile(nextAccount, gameAccounts);
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCharacter(string accountUsername, string characterName)
        {
            try
            {
                var nextAccount = GetTotalAccounts();

                var gameAccounts = GetFileData();

                foreach (var act in gameAccounts.Where(x => x.Username == accountUsername))
                    act.Character = null;

                return SaveToFile(nextAccount, gameAccounts);
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePassword(string accountUsername, string newPassword)
        {
            try
            {
                var nextAccount = GetTotalAccounts();

                var gameAccounts = GetFileData();

                foreach (var act in gameAccounts.Where(x => x.Username == accountUsername))
                    act.Password = newPassword;

                return SaveToFile(nextAccount, gameAccounts);
            }
            catch
            {
                return false;
            }
        }
    }
}

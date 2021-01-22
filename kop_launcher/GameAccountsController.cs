using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exception = System.Exception;

namespace kop_launcher
{
    class GameAccountsController
    {
        /*
         * Login.dat file structure:
         * line 1: account count number
         * line 2: account 1 username,password,character(nullable)
         * line 2: account 2 username,password,character(nullable)
         * line n: account n username,password,character(nullable)
         *
         */

        private static string _folderPath;
        private static string _filePath;
        public GameAccountsController(string folderPath = "user", string filePath = "login.dat")
        {
            _folderPath = folderPath;
            _filePath = filePath;
        }
        private static string CheckFileReachable()
        {
            try
            {
                var dir = Path.Combine(Globals.RootDirectory, _folderPath);
                var pathToFile = Path.Combine(dir, _filePath);

                if (Directory.Exists(pathToFile))
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

        private short GetAccountNumber()
        {
            try
            {
                var pathToFile = CheckFileReachable();
                return Convert.ToInt16(File.ReadLines(pathToFile).First());
            }
            catch
            {
                return -1;
            }
        }

        // TODO: overwrite account number
        // TODO: append account
        // TODO: append character to account
    }
}

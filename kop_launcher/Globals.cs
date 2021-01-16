using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace kop_launcher
{

    public static class Globals
    {
        public static bool RenderNotification = true;
        public static bool RenderNotificationShown = false;
        public static List<int> GameInstances = new List<int>();
        public static string lastOpenedRegion = null;
        public static List<string> GenuineResourceHashes = new List<string>();
        public static List<string> CurrentResourceHashes = new List<string>();
        public static bool hasBeenReported = false;
        public static string rootDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public static string SaveDownloadsPath = Path.Combine(rootDirectory, "scripts", "update");

        public static bool KillProcess(int pid)
        {
            Process[] process = Process.GetProcesses();
            bool ret = false;

            foreach (Process prs in process)
            {
                if (prs.Id == pid)
                {
                    prs.Kill();
                    ret = true;
                    break;
                }
            }

            return ret;
        }
        public static string GetIPByServer(string server)
        {
            string IP = "";

            switch (server)
            {
                case "Local":
                    IP = "127.0.0.1";
                    break;
                case "Jan":
                    IP = "192.168.1.49";
                    break;
                case "Morgan":
                default:
                    IP = "51.124.120.48";
                    break;
            }

            return IP;
        }

        public static int StartGameInstance(string Region)
        {
            string systemPath = Path.Combine(rootDirectory, "system");
            string gameExe = File.Exists(Path.Combine(systemPath, "game.exe")) ? "game.exe" : "Game.exe";
            string startPath = Path.Combine(systemPath, gameExe);

            var process = new Process
            {
                StartInfo =
                {
                    FileName = startPath,
                    Arguments = string.Format("startgame ip:{0}", Region),
                    WorkingDirectory = rootDirectory
                }
            };

            if (process.Start())
                return process.Id;
            else
                return -1;
        }
        public static bool ProcessExists(int id)
        {
            return Process.GetProcesses().Any(x => x.Id == id);
        }

        public static bool AnyInstancesRunning()
        {
            bool ret = false;

            if (GameInstances.Count > 0)
            {
                foreach (var id in GameInstances)
                {
                    if (ProcessExists(id))
                    {
                        ret = true;
                        break;
                    }
                }
            }

            return ret;
        }

        public static bool RestartGameInstances()
        {
            bool ret = true;

            try
            {
                if (GameInstances.Count > 0)
                {
                    if (AnyInstancesRunning())
                    {
                        foreach (int processID in GameInstances)
                        {
                            if (!KillProcess(processID))
                            {
                                ret = false;
                            }
                        }
                    }
                }

                int tobeRestarted = GameInstances.Count;
                GameInstances.Clear();
                Utils utils = new Utils();

                for (int i = 0; i < tobeRestarted; i++)
                {
                    string region = GetIPByServer(lastOpenedRegion);
                    int procID = StartGameInstance(region);

                    if (procID != -1)
                    {
                        lastOpenedRegion = region;
                        GameInstances.Add(procID);
                    }
                    else
                        utils.ShowMessageA("An error occured while opening a game instance.");
                }
            }
            catch
            {
                ret = false;
            }

            return ret;
        }
        public static bool IsGameRunning()
        {
            if (GameInstances.Count > 0)
                return true;

            return false;
        }

        public static string CalculateMD5(string filename)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}

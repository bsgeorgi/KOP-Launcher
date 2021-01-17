using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;
using System;
using System.Net;

namespace kop_launcher
{
    public class Patch
    {
        public string FileURL { get; set; }
        public string FileMirror { get; set; }
        public int PatchVersion { get; set; }
    }
    public class DownloadInfo
    {
        public string OriginalFile { get; set; }
        public string TemporaryFile { get; set; }
    }
    public class AutoUpdate
    {
        private string RemoteVersion;
        private readonly Uri BaseURI = new Uri("https://kingofpirates.net");
        public AutoUpdate(string RemoteVersion)
        {
            this.RemoteVersion = RemoteVersion;
        }

        /*
         * Checks if path exists, if not then creates it
         * Returns true if path created successfully or already exists
         */
        public bool CheckCreateUpdatePath()
        {
            string path = Path.Combine(Globals.rootDirectory, "scripts", "update");
            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /*
         * Returns version string
         * If file does not exist, returns default version
         * If exception was caught, returns null
         */
        public string GetLocalVersion()
        {
            try
            {
                /*
                 * Check if update path exists
                 * Returns true if exists or was created successfully
                 */
                if (CheckCreateUpdatePath())
                {
                    string path = Path.Combine(Globals.rootDirectory, "scripts", "update", ".version");
                    if (File.Exists(path))
                    {
                        // File exists, so read data and return string
                        using (TextReader tr = new StreamReader(path, Encoding.UTF8))
                        {
                            return tr.ReadLine().Trim();
                        }
                    }
                    else
                    {
                        File.Create(path).Dispose();

                        using (TextWriter tw = new StreamWriter(path))
                        {
                            tw.WriteLine(Properties.Resources.DefaultGameVersion);
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
            return Properties.Resources.DefaultGameVersion;
        }

        public bool OverrideLocalGameVersion(string Version)
        {
            try
            {
                string path = Path.Combine(Globals.rootDirectory, "scripts", "update", ".version");
                if (File.Exists(path))
                {
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        tw.WriteLine(Version);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /*
         * Validates if local game version matches remote game version
         * Returns true if versions match, otherwise false
         */
        public bool IsGameUpToDate()
        {
            return GetLocalVersion() == RemoteVersion;
        }

        /*
         * Casts string version to int
         * Returns int representation of version or -1 if error occured
         */
        public static int CastVersionToInt(string Version)
        {
            if (int.TryParse(Version.Replace(".", ""), out int outInt))
            {
                return outInt;
            }
            return -1;
        }

        public string GetFileNameFromUrl(string url)
        {
            try
            {
                Uri uri;
                if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
                    uri = new Uri(BaseURI, url);

                return Path.GetFileName(uri.LocalPath);
            }
            catch
            {
                return null;
            }
        }

        public bool IsLinkReachable(string uri)
        {
            try
            {
                WebRequest request = WebRequest.Create(new Uri(uri));
                request.Proxy = null;
                request.Method = "HEAD";

                using (WebResponse response = request.GetResponse())
                {
                    if (response.ContentLength > 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public DownloadInfo GetDownloadData(string FileURL)
        {
            string fileName = GetFileNameFromUrl(FileURL);
            if (!string.IsNullOrEmpty(fileName))
            {
                return new DownloadInfo()
                {
                    OriginalFile = fileName,
                    TemporaryFile = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 16) + ".zip"
            };
            }
            return null;
        }

        /*
         * Generates a list of updates
         * Returns list of updates bigger or equal to remote version and last patch version
         */
        public (List<Patch> PatchList, int LastVersion) GetRequiredUpdates(string RemoteVersion, string XMLSource, bool ForceUpdate)
        {
            var list = new List<Patch>();
            int lastVersion = 0;
            int remoteVersion = CastVersionToInt(RemoteVersion);

            if (remoteVersion > 0)
            {
                try
                {
                    var xdoc = XDocument.Load(XMLSource);

                    var commands =
                    from cmd in xdoc.Descendants("Update")
                    select new
                    {
                        FileURL     = (string)cmd.Element("FileURL"),
                        FileMirror  = (string)cmd.Element("FileMirror"),
                        Version     = (string)cmd.Element("Version"),
                    };

                    foreach (var patch in commands)
                    {
                        int version = CastVersionToInt(patch.Version);
                        Patch PatchInfo = new Patch();

                        var patchURL = patch.FileURL;
                        var patchMirror = patch.FileMirror;

                        if (ForceUpdate)
                        {
                            if (version > 0 && !string.IsNullOrEmpty(patch.FileURL))
                            {
                                if (IsLinkReachable(patchURL))
                                {
                                    PatchInfo.FileURL = patchURL;
                                    PatchInfo.FileMirror = patchMirror;
                                    PatchInfo.PatchVersion = version;
                                }
                                else
                                {
                                    PatchInfo.FileURL = patchMirror;
                                    PatchInfo.FileMirror = PatchInfo.FileURL;
                                    PatchInfo.PatchVersion = version;
                                }

                                if (!list.Contains(PatchInfo))
                                    list.Add(PatchInfo);
                            }
                        }
                        else
                        {
                            if (version > 0 && !string.IsNullOrEmpty(patch.FileURL) && version <= remoteVersion)
                            {
                                if (IsLinkReachable(patchURL))
                                {
                                    PatchInfo.FileURL = patchURL;
                                    PatchInfo.FileMirror = patchMirror;
                                    PatchInfo.PatchVersion = version;
                                }
                                else
                                {
                                    PatchInfo.FileURL = patchMirror;
                                    PatchInfo.FileMirror = PatchInfo.FileURL;
                                    PatchInfo.PatchVersion = version;
                                }

                                if (!list.Contains(PatchInfo))
                                    list.Add(PatchInfo);
                            }
                        }
                    }

                    // Get the last element in IEnumerable which indicates the last version
                    if (list != null && list.Count > 0)
                    {
                        var last = list.Last();
                        lastVersion = last.PatchVersion;
                    }
                    else
                    {
                        // List is empty, something has gone wrong cause version mismatched but there were no updates available
                        // return -1 and throw exception in main
                        lastVersion = -1;
                    }
                }
                catch { }
            }
            return (PatchList: list, LastVersion: lastVersion);
        }
    }
}

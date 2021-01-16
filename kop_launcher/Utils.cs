using System.IO;
using System.Windows.Forms;

namespace kop_launcher
{
    public class Utils
    {
        public void ShowMessageA(string message, string caption="KOPO")
        {
            MessageBoxA msg = new MessageBoxA(message, caption);
            msg.Show();
            msg.BringToFront();
        }

        public bool ShowMessageOK(string message)
        {
            MessageBoxAccept msg = new MessageBoxAccept(message);
            DialogResult result = msg.ShowDialog();
            msg.BringToFront();

            bool q = result == DialogResult.OK ? true : false;
            msg.Close();

            return q;
        }
    }

    public class Camera
    {
        public bool IsAnimationTweaked()
        {
            string path = Path.Combine(Globals.rootDirectory, "scripts", "txt", "CharacterAction.tx");
            Utils utils = new Utils();
            bool tweaked = false;

            try
            {
                if (!File.Exists(path))
                {
                    utils.ShowMessageA("Could not locate animation config file.");
                }
                else
                {
                    string hashsum = Globals.CalculateMD5(path);

                    //if (hashsum != "f0c17f4f9795db413974aa1eb260baa3")
                    if (hashsum != "441ab7f4bbfecd29446fb4bbc62c05bb")
                        tweaked = true;
                }
            }
            catch { }

            return tweaked;
        }

        public short GetCurrentCameraConfig()
        {
            string path = Path.Combine(Globals.rootDirectory, "scripts", "lua", "CameraConf1024.clu");
            Utils utils = new Utils();
            short camera = -1;

            try
            {
                if (!File.Exists(path))
                {
                    utils.ShowMessageA("Could not locate current config file.");
                }
                else
                {
                    string hashsum = Globals.CalculateMD5(path);
                    switch (hashsum)
                    {
                        //case "3228be4db1e8dffcb5afe80b5fce7bae":
                        case "080e6b718d36826fbef34cc3f72ad231":
                            camera = 1;
                            break;
                        //case "06971ca3885a3bcf31d5eedf6587ac99":
                        case "fa0fce42b2ac46ed61610a38292e1332":
                            camera = 2;
                            break;
                        //case "6b2fc071d7c60745568edaacd056b924":
                        case "063ddb36061b6e52aaab501566a18a82":
                            camera = 3;
                            break;
                        //case "f21b64a99e0bd42f1b421d1d101a0ab5":
                        case "b0cbf664048a3ab00768ba348790c048":
                            camera = 4;
                            break;
                        default:
                            camera = 2;
                            break;
                    }
                }
            }
            catch { }

            return camera;
        }
    }
}

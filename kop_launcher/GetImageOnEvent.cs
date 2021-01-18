using System.IO;

namespace kop_launcher
{
    public static class GetImageOnEvent
    {
        public static string GetImageOnEnterSidebar(string controlName)
        {
            var uiPath = Path.Combine(Globals.RootDirectory, "texture", "launcher", "sidebar_buttons");
            string buttonPath;

            switch (controlName)
            {
                case string facebook when facebook.Contains("facebook"):
                    buttonPath = Path.Combine(uiPath, "facebook_btn_hover.png");
                    break;
                case string instagram when instagram.Contains("insta"):
                    buttonPath = Path.Combine(uiPath, "insta_btn_hover.png");
                    break;
                case string mail when mail.Contains("mail"):
                    buttonPath = Path.Combine(uiPath, "mail_btn_hover.png");
                    break;
                case string forum when forum.Contains("forum"):
                    buttonPath = Path.Combine(uiPath, "forum_btn_hover.png");
                    break;
                default:
                    buttonPath = Path.Combine(uiPath, "settings_btn_hover.png");
                    break;
            }

            return buttonPath;
        }

        public static string GetImageOnLeaveSidebar(string controlName)
        {
            var uiPath = Path.Combine(Globals.RootDirectory, "texture", "launcher", "sidebar_buttons");
            string buttonPath;

            switch (controlName)
            {
                case string facebook when facebook.Contains("facebook"):
                    buttonPath = Path.Combine(uiPath, "facebook_btn.png");
                    break;
                case string instagram when instagram.Contains("insta"):
                    buttonPath = Path.Combine(uiPath, "insta_btn.png");
                    break;
                case string mail when mail.Contains("mail"):
                    buttonPath = Path.Combine(uiPath, "mail_btn.png");
                    break;
                case string forum when forum.Contains("forum"):
                    buttonPath = Path.Combine(uiPath, "forum_btn.png");
                    break;
                default:
                    buttonPath = Path.Combine(uiPath, "settings_btn.png");
                    break;
            }

            return buttonPath;
        }

        public static string GetImageOnEnterPackage(string controlName)
        {
            var uiPath = Path.Combine(Globals.RootDirectory, "texture", "launcher", "packages");
            var buttonPath = "";

            switch (controlName)
            {
                case string facebook when facebook.Contains("1"):
                    buttonPath = Path.Combine(uiPath, "1_hover.png");
                    break;
                case string instagram when instagram.Contains("2"):
                    buttonPath = Path.Combine(uiPath, "2_hover.png");
                    break;
                case string mail when mail.Contains("3"):
                    buttonPath = Path.Combine(uiPath, "3_hover.png");
                    break;
                case string forum when forum.Contains("4"):
                    buttonPath = Path.Combine(uiPath, "4_hover.png");
                    break;
            }

            return buttonPath;
        }

        public static string GetImageOnLeavePackage(string controlName)
        {

            var uiPath = Path.Combine(Globals.RootDirectory, "texture", "launcher", "packages");
            var buttonPath = "";

            switch (controlName)
            {
                case string facebook when facebook.Contains("1"):
                    buttonPath = Path.Combine(uiPath, "1.png");
                    break;
                case string instagram when instagram.Contains("2"):
                    buttonPath = Path.Combine(uiPath, "2.png");
                    break;
                case string mail when mail.Contains("3"):
                    buttonPath = Path.Combine(uiPath, "3.png");
                    break;
                case string forum when forum.Contains("4"):
                    buttonPath = Path.Combine(uiPath, "4.png");
                    break;
            }

            return buttonPath;
        }
    }
}

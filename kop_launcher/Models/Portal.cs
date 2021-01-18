using System;

namespace kop_launcher.Models
{
    public class Portal
    {
        public string PortalName { get; set; }

        private string[] _portalInfo = new string[3];
        public string[] PortalOpeningInfo
        {
            get => _portalInfo;

            set
            {
                if (value.Length < 2)
                {
                    throw new Exception("Portal model requires 3 params!");
                }

                _portalInfo = value;
            }
        }
    }
}

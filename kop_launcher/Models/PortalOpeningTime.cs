using System;

namespace kop_launcher.Models
{
    internal class PortalOpeningTIme
    {
        public PortalOpeningTIme(string portalTime)
        {
            var results = portalTime.Split('/');
            Hour = Convert.ToInt16(results[0]);
            Minute = Convert.ToInt16(results[1]);
        }
        public short Hour { get; set; }
        public short Minute { get; set; }
    }
}
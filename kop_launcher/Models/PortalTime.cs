using System;

namespace kop_launcher.Models
{
    internal class PortalTime
    {
        public PortalTime( string portalTime )
        {
            var results = portalTime.Split('/');
            Day    = Convert.ToInt16( results[0] );
            Hour   = Convert.ToInt16( results[1] );
            Minute = Convert.ToInt16( results[2] );
        }

        public short Day { get; set; }
        public short Hour { get; set; }
        public short Minute { get; set; }
    }
}

using System;
using kop_launcher.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace kop_launcher
{
    class Portals
    {
        private readonly IEnumerable<Portal> _portals;
        public Portals ( IEnumerable<Portal> portals )
        {
            _portals = portals;
        }

        private PortalInfo FormatPortalInfo ( Portal portal )
        {
            if ( string.IsNullOrEmpty( portal.PortalName ) ) return null;

            var serverTime        = Utils.GetServerTime ( );
            var openingTimes      = new PortalOpeningTIme ( portal.PortalOpeningInfo[0] );
            var openInterval      = new PortalIntervalTime( portal.PortalOpeningInfo[1] );
            var openDuration      = new PortalIntervalTime ( portal.PortalOpeningInfo[2] );

            var openHours = new List<int> ( );

            if (openingTimes.Hour == 0 && openingTimes.Minute == 0)
                openHours = Enumerable.Range(1, 24).Where(i => i % openInterval.Hour == 0).ToList();
            else
            {
                var initialOpenAt = openingTimes.Hour * 60 + openingTimes.Minute;
                openHours = Enumerable.Range(1, 24).Where(i => i * 60 % initialOpenAt == 0).ToList();
            }

            var isThisPortalOpen = CheckIsPortalOpen ( openHours, serverTime, openDuration );
            var query = isThisPortalOpen ? serverTime.Hour + 1 : serverTime.Hour;

            var portalInfo = new PortalInfo ( )
            {
                PortalName    = portal.PortalName,
                IsPortalOpen  = CheckIsPortalOpen ( openHours, serverTime, openDuration ),
                NextOpenIn    = FormatFromTimeSpan(GetTimeUntilNextOpen( openHours, query, serverTime) ),
                RemainingTime = isThisPortalOpen ?
                                    FormatFromTimeSpan (TimeSpan.FromMinutes(openDuration.Minute - serverTime.Minute)) :
                                    "--;--;--"
            };

            return portalInfo;
        }

        private static bool CheckIsPortalOpen ( IEnumerable<int> openHours, DateTime currentTime, PortalIntervalTime portalTime )
        {
            return openHours.Contains(currentTime.Hour) && currentTime.Minute < portalTime.Minute;
        }

        private static string FormatFromTimeSpan ( TimeSpan t )
        {
            return $"{t:hh\\:mm\\:ss}";
        }

        private static int GetNextHour ( ICollection<int> openHours, int hour )
        {
            if ( hour < 0 || hour > 24 ) return 0;
            if ( openHours.Contains ( hour ) ) return hour;

            var newHour = hour;
            var found  = openHours.Contains ( hour) ;

            while ( !found )
            {
                newHour++;
                found = openHours.Contains ( newHour );

                if ( found )
                    break;
            }

            return newHour;
        }

        private static TimeSpan GetTimeUntilNextOpen ( ICollection<int> openHours, int hour, DateTime serverTime )
        {
            var nextHour = GetNextHour ( openHours, hour );
            DateTime nextHourDatetime;

            if ( nextHour == 24 )
            {
                var newDate = serverTime.AddDays ( 1 );
                DateTime.TryParse ( $"{newDate.Month}/{newDate.Day}/{newDate.Year} 12:00:00 AM", out nextHourDatetime );
            }
            else
                DateTime.TryParse ( $"{serverTime.Month}/{serverTime.Day}/{serverTime.Year} {nextHour}:00:00", out nextHourDatetime );


            var difference = ( nextHourDatetime - serverTime ).TotalSeconds;

            return TimeSpan.FromSeconds( difference );
        }

        public List<PortalInfo> GetPortalInfo ( )
        {
            var portalsInformation = new List<PortalInfo> ( );

            foreach ( var portal in _portals )
            {
                var singlePortalInfo = FormatPortalInfo ( portal );

                if ( !portalsInformation.Contains ( singlePortalInfo ) )
                    portalsInformation.Add ( singlePortalInfo );
            }
            return portalsInformation;
        }
    }

    public class PortalsOnDraw
    {
        private readonly Point _initialLocation = new Point (106, 500);
        private readonly Size _portalPanelSize  = new Size (370, 29);
        private readonly Color _panelColor      = ColorTranslator.FromHtml ( "#131521" );
        private readonly Font _defaultFont      = new Font ("Montserrat", 7, FontStyle.Regular);

        private const short PanelOffset    = 40;

        private static readonly Color TableHeadingColor     = ColorTranslator.FromHtml ("#666c92");
        private static readonly Color TableHeadingBackColor = ColorTranslator.FromHtml ( "#131521" );
        private static readonly Font  TableHeadingFont      = new Font ("Montserrat", 7, FontStyle.Regular);


        public  readonly Label[] TableHeadings         = new Label[4]
        {
            new Label()
            {
                Name      = "TableHeading1",
                Text      = "#",
                ForeColor = TableHeadingColor,
                BackColor = TableHeadingBackColor,
                Font      = TableHeadingFont,
                Location  = new Point (106, 474 ),
                AutoSize  = true
            },
            new Label()
            {
                Name      = "TableHeading2",
                Text      = "Status",
                ForeColor = TableHeadingColor,
                BackColor = TableHeadingBackColor,
                Font      = TableHeadingFont,
                Location  = new Point (230, 474 ),
                AutoSize  = true
            },
            new Label()
            {
                Name      = "TableHeading3",
                Text      = "Remaining",
                ForeColor = TableHeadingColor,
                BackColor = TableHeadingBackColor,
                Font      = TableHeadingFont,
                Location  = new Point (306, 474 ),
                AutoSize  = true
            },
            new Label()
            {
                Name      = "TableHeading4",
                Text      = "Next",
                ForeColor = TableHeadingColor,
                BackColor = TableHeadingBackColor,
                Font      = TableHeadingFont,
                Location  = new Point (406, 474 ),
                AutoSize  = true
            },
        };
        private readonly Label[] _portalsHeadings      = new Label[Globals.MaximumPortals];
        private readonly Label[] _portalsIsItOpen      = new Label[Globals.MaximumPortals];
        private readonly Label[] _portalsRemainingTime = new Label[Globals.MaximumPortals];
        private readonly Label[] _portalsNextTime      = new Label[Globals.MaximumPortals];

        public Panel[] PortalPanels = new Panel[]
        {
            new Panel(),
            new Panel(),
            new Panel()
        };

        public PortalsOnDraw ( )
        {
            InitAllPanels ( );
            InitAllLabels ( );
            UpdatePortalData ( );
            RenderPortals ( );
        }

        private void InitAllPanels ( )
        {
            for ( var i = 0; i < Globals.MaximumPortals; i++ )
            {
                var location = new Point( _initialLocation.X, _initialLocation.Y + i * PanelOffset );

                PortalPanels[i] = new Panel ( )
                {
                    Name = $"PortalPanel{ i }",
                    BackColor = _panelColor,
                    Location = location,
                    Size = _portalPanelSize,
                };
            }
        }

        private void InitAllLabels ( )
        {
            for ( var i = 0; i < Globals.MaximumPortals; i++ )
            {
                _portalsHeadings[i] = new Label ( )
                {
                    Name = $"PortalHeading{ i }",
                    Text = "--",
                    ForeColor = Color.White,
                    Location = new Point(0, 5),
                    Font = _defaultFont,
                    AutoSize = true
                };

                _portalsIsItOpen[i] = new Label ( )
                {
                    Name = $"IsPortalOpen{ i }",
                    Text = "--",
                    ForeColor = Color.White,
                    Location = new Point(124, 5),
                    Font = _defaultFont,
                    AutoSize = true
                };

                _portalsRemainingTime[i] = new Label ( )
                {
                    Name = $"portalRemainingTime{ i }",
                    Text = "--:--:--",
                    ForeColor = Color.White,
                    Location = new Point(200, 5),
                    Font = _defaultFont,
                    AutoSize = true
                };

                _portalsNextTime[i] = new Label ( )
                {
                    Name = $"portalNextTime{ i }",
                    Text = "--;--;--",
                    ForeColor = Color.White,
                    Location = new Point(300, 5),
                    Font = _defaultFont,
                    AutoSize = true
                };
            }
        }

        private void UpdatePortalData ( )
        {
            var portalInfo = new Portals ( Utils.GetDefaultPortals ( ) ).GetPortalInfo( );
            if (portalInfo.Count == 0) return;
            
            for ( var i = 0; i < portalInfo.Count; i++ )
            {
                var singlePortalInfo = portalInfo.ElementAt ( i );

                _portalsHeadings[i].Text      = singlePortalInfo.PortalName;
                _portalsIsItOpen[i].Text      = singlePortalInfo.IsPortalOpen ? "Open" : "Closed";
                _portalsIsItOpen[i].ForeColor = singlePortalInfo.IsPortalOpen ? Color.Green : Color.Red;
;               _portalsRemainingTime[i].Text = singlePortalInfo.RemainingTime;
                _portalsNextTime[i].Text      = singlePortalInfo.NextOpenIn;
            }
        }

        private void RenderPortals ( )
        {
            for ( var i = 0; i < Globals.MaximumPortals; i++ )
            {
                PortalPanels[i].Controls.Add(_portalsHeadings[i]);
                PortalPanels[i].Controls.Add(_portalsIsItOpen[i]);
                PortalPanels[i].Controls.Add(_portalsRemainingTime[i]);
                PortalPanels[i].Controls.Add(_portalsNextTime[i]);
            }
        }
    }
}

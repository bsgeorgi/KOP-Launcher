using kop_launcher.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace kop_launcher
{
    class Portals
    {
        private readonly IEnumerable<Portal> _portals;
        private readonly List<PortalInfo> _portalInfo;

        public Portals ( IEnumerable<Portal> portals )
        {
            _portals = portals;
            _portalInfo = GetPortalInfo ( );
        }

        private List<PortalInfo> GetPortalInfo ( )
        {
            var portalsInformation = new List<PortalInfo> ( );
            var serverTime         = Utils.GetServerTime ( );

            foreach ( var portal in _portals )
            {
                var singlePortalInfo = new PortalInfo()
                {
                    PortalName    = portal.PortalName,
                    IsPortalOpen  = true,
                    RemainingTime = "00:32:12",
                    NextOpenIn    = "02:12:53" 
                };

                if ( !portalsInformation.Contains( singlePortalInfo ) )
                    portalsInformation.Add ( singlePortalInfo );
            }

            return portalsInformation;
        }

        public void UpdatePortalNames()
        {
            Utils.ShowMessageA( "Updating portal info!" );
            /*for ( var i = 0; i < _portalInfo.Count; i++ )
            {
                if (i == --Globals.MaximumPortals)
                    break;

                // TODO: Update main panel portals controls from here

            }*/
        }
    }

    public class PortalsOnDraw
    {
        private readonly Point _initialLocation = new Point(106, 500);
        private readonly Size _portalPanelSize  = new Size(370, 29);
        private readonly Color _panelColor      = ColorTranslator.FromHtml( "#131521" );
        private readonly Font _defaultFont      = new Font("Montserrat", 7, FontStyle.Regular);

        private const short PanelOffset    = 40;
        private const short LabelsOffset   = 100;

        private static readonly Color TableHeadingColor     = ColorTranslator.FromHtml("#666c92");
        private static readonly Color TableHeadingBackColor = ColorTranslator.FromHtml( "#131521" );
        private static readonly Font  TableHeadingFont      = new Font("Montserrat", 7, FontStyle.Regular);

        public Panel[] PortalPanels = new []
        {
            new Panel(),
            new Panel(),
            new Panel()
        };

        public readonly Label[] tableHeadings = new []
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
                Location  = new Point (206, 474 ),
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

        public PortalsOnDraw ( )
        {
            for ( var i = 0; i < Globals.MaximumPortals; i++ )
            {
                var location = new Point( _initialLocation.X, _initialLocation.Y + (i * PanelOffset) );

                PortalPanels[i] = new Panel()
                {
                    Name      = $"PortalPanel{ i }",
                    BackColor = _panelColor,
                    Location  = location,
                    Size      = _portalPanelSize,
                };

                var portalHeading = new Label()
                {
                    Name      = $"PortalHeading{ i }",
                    Text      = "--",
                    ForeColor = Color.White,
                    Location  = new Point (0, 5 ),
                    Font      = _defaultFont,
                    AutoSize = true
                };

                var isPortalOpen = new Label()
                {
                    Name      = $"IsPortalOpen{ i }",
                    Text      = "--",
                    ForeColor = Color.Green,
                    Location  = new Point(100, 5 ),
                    Font      = _defaultFont,
                    AutoSize = true
                };

                var portalRemainingTime = new Label()
                {
                    Name      = $"portalRemainingTime{ i }",
                    Text      = "--:--:--",
                    ForeColor = Color.White,
                    Location  = new Point(200, 5),
                    Font      = _defaultFont,
                    AutoSize = true
                };

                var portalNextTime = new Label()
                {
                    Name      = $"portalNextTime{ i }",
                    Text      = "--;--;--",
                    ForeColor = Color.White,
                    Location  = new Point(300, 5),
                    Font      = _defaultFont,
                    AutoSize = true
                };

                PortalPanels[i].Controls.Add( portalHeading );
                PortalPanels[i].Controls.Add( isPortalOpen );
                PortalPanels[i].Controls.Add( portalRemainingTime );
                PortalPanels[i].Controls.Add( portalNextTime );
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace kop_launcher
{
    class Portals
    {
    }

    public class PortalsOnDraw
    {
        private readonly Point _initialLocation = new Point(106, 500);
        private readonly Size _portalPanelSize  = new Size(370, 29);
        private readonly Color _panelColor      = ColorTranslator.FromHtml( "#131521" );
        private readonly Font _defaultFont      = new Font("Montserrat", 7, FontStyle.Regular);

        private const short MaximumPortals = 3;
        private const short PanelOffset    = 40;
        private const short LabelsOffset   = 100;

        private static readonly Color TableHeadingColor     = ColorTranslator.FromHtml("#666c92");
        private static readonly Color TableHeadingBackColor = ColorTranslator.FromHtml( "#131521" );
        private static readonly Font  TableHeadingFont      = new Font("Montserrat", 7, FontStyle.Regular);

        public Panel[] PortalPanels = new Panel [MaximumPortals]
        {
            new Panel(),
            new Panel(),
            new Panel()
        };

        public readonly Label[] tableHeadings = new Label[4]
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
            for ( var i = 0; i < MaximumPortals; i++ )
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
                    Text      = $"Portal { i }",
                    ForeColor = Color.White,
                    Location  = new Point (0, 5 ),
                    Font      = _defaultFont,
                    AutoSize = true
                };

                var isPortalOpen = new Label()
                {
                    Name      = $"IsPortalOpen{ i }",
                    Text      = "Open",
                    ForeColor = Color.Green,
                    Location  = new Point(100, 5 ),
                    Font      = _defaultFont,
                    AutoSize = true
                };

                var portalRemainingTime = new Label()
                {
                    Name      = $"portalRemainingTime{ i }",
                    Text      = "00:34:58",
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

using System;
using kop_launcher.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace kop_launcher
{
	public class PortalsOnDraw : IDisposable
	{
		private const int MAX_PORTALS = 3;

		private readonly Point _initialLocation = new Point ( 106, 500 );
		private readonly Size  _portalPanelSize = new Size ( 370, 29 );
		private readonly Color _panelColor      = ColorTranslator.FromHtml ( "#131521" );
		private readonly Font  _defaultFont     = new Font ( "Montserrat", 7, FontStyle.Regular );

		private const short PanelOffset = 40;

		private static readonly Color TableHeadingColor     = ColorTranslator.FromHtml ( "#666c92" );
		private static readonly Color TableHeadingBackColor = ColorTranslator.FromHtml ( "#131521" );
		private static readonly Font  TableHeadingFont      = new Font ( "Montserrat", 7, FontStyle.Regular );


		public readonly Label[] TableHeadings =
		{
			new Label
			{
				Name      = "TableHeading1",
				Text      = "#",
				ForeColor = TableHeadingColor,
				BackColor = TableHeadingBackColor,
				Font      = TableHeadingFont,
				Location  = new Point ( 106, 474 ),
				AutoSize  = true
			},
			new Label
			{
				Name      = "TableHeading2",
				Text      = "Status",
				ForeColor = TableHeadingColor,
				BackColor = TableHeadingBackColor,
				Font      = TableHeadingFont,
				Location  = new Point ( 230, 474 ),
				AutoSize  = true
			},
			new Label
			{
				Name      = "TableHeading3",
				Text      = "Remaining",
				ForeColor = TableHeadingColor,
				BackColor = TableHeadingBackColor,
				Font      = TableHeadingFont,
				Location  = new Point ( 306, 474 ),
				AutoSize  = true
			},
			new Label
			{
				Name      = "TableHeading4",
				Text      = "Next",
				ForeColor = TableHeadingColor,
				BackColor = TableHeadingBackColor,
				Font      = TableHeadingFont,
				Location  = new Point ( 406, 474 ),
				AutoSize  = true
			},
		};

		private readonly Label[] _portalsHeadings      = new Label[Globals.MaximumPortals];
		private readonly Label[] _portalsIsItOpen      = new Label[Globals.MaximumPortals];
		private readonly Label[] _portalsRemainingTime = new Label[Globals.MaximumPortals];
		private readonly Label[] _portalsNextTime      = new Label[Globals.MaximumPortals];

		public readonly Panel[] PortalPanels =
		{
			new Panel ( ),
			new Panel ( ),
			new Panel ( )
		};

		private List<Portal> _portals;
		private IDisposable  _sub;

		public PortalsOnDraw ( )
		{
			InitAllPanels ( );
			InitAllLabels ( );
			_portals = Utils.GetDefaultPortals ( ).ToList ( );
			//UpdatePortalData ( );
			RenderPortals ( );

			_sub = Observable.Interval ( TimeSpan.FromSeconds ( 1 ) )
							 .ObserveOn ( Globals.UiDispatcher )
							 //.SubscribeOn ( Dispatcher.CurrentDispatcher )
							 .Subscribe ( x => UpdatePortalData ( ) );
		}

		private void InitAllPanels ( )
		{
			for ( var i = 0; i < Globals.MaximumPortals; i++ )
			{
				var location = new Point ( _initialLocation.X, _initialLocation.Y + i * PanelOffset );

				PortalPanels[i] = new Panel
				{
					Name      = $"PortalPanel{i}",
					BackColor = _panelColor,
					Location  = location,
					Size      = _portalPanelSize,
				};
			}
		}

		private void InitAllLabels ( )
		{
			for ( var i = 0; i < Globals.MaximumPortals; i++ )
			{
				_portalsHeadings[i] = new Label
				{
					Name      = $"PortalHeading{i}",
					Text      = "--",
					ForeColor = Color.White,
					Location  = new Point ( 0, 5 ),
					Font      = _defaultFont,
					AutoSize  = true
				};

				_portalsIsItOpen[i] = new Label
				{
					Name      = $"IsPortalOpen{i}",
					Text      = "--",
					ForeColor = Color.White,
					Location  = new Point ( 124, 5 ),
					Font      = _defaultFont,
					AutoSize  = true
				};

				_portalsRemainingTime[i] = new Label
				{
					Name      = $"portalRemainingTime{i}",
					Text      = "--:--:--",
					ForeColor = Color.White,
					Location  = new Point ( 200, 5 ),
					Font      = _defaultFont,
					AutoSize  = true
				};

				_portalsNextTime[i] = new Label
				{
					Name      = $"portalNextTime{i}",
					Text      = "--;--;--",
					ForeColor = Color.White,
					Location  = new Point ( 300, 5 ),
					Font      = _defaultFont,
					AutoSize  = true
				};
			}
		}

		private void UpdatePortalData ( )
		{
			var serverTime = Utils.GetServerTime ( );
			var portalInfo = SortPortals ( serverTime )
							 .Take ( MAX_PORTALS )
							 .Select ( x => x.ToPortalInfo ( serverTime ) )
							 .ToList ( );

			for ( var i = 0; i < portalInfo.Count; i++ )
			{
				var singlePortalInfo = portalInfo.ElementAt ( i );

				_portalsHeadings[i].Text      = singlePortalInfo.PortalName;
				_portalsIsItOpen[i].Text      = singlePortalInfo.IsPortalOpen ? "Open" : "Closed";
				_portalsIsItOpen[i].ForeColor = singlePortalInfo.IsPortalOpen ? Color.Green : Color.Red;
				_portalsRemainingTime[i].Text = singlePortalInfo.RemainingTime;
				_portalsNextTime[i].Text      = singlePortalInfo.NextOpenIn;
			}
		}

		private List<Portal> SortPortals ( DateTime ServerDateTime )
		{
			foreach ( var portal in _portals )
				portal.OpeningInfo.CheckTime ( ServerDateTime );

			var open   = _portals.Where ( x => x.OpeningInfo.IsOpen );
			var closed = _portals.Where ( x => !x.OpeningInfo.IsOpen );

			open   = open.OrderBy ( x => x.OpeningInfo.GetRemainingTime ( ServerDateTime ) );
			closed = closed.OrderBy ( x => x.OpeningInfo.GetTimeUntilNextOpen ( ServerDateTime ) );

			var all = open.ToList ( );
			all.AddRange ( closed );

			return all;
		}

		private void RenderPortals ( )
		{
			for ( var i = 0; i < Globals.MaximumPortals; i++ )
			{
				PortalPanels[i].Controls.Add ( _portalsHeadings[i] );
				PortalPanels[i].Controls.Add ( _portalsIsItOpen[i] );
				PortalPanels[i].Controls.Add ( _portalsRemainingTime[i] );
				PortalPanels[i].Controls.Add ( _portalsNextTime[i] );
			}
		}

		public void Dispose ( )
		{
			_sub.Dispose ( );
		}
	}
}
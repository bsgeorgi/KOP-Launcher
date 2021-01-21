using System;

namespace kop_launcher.Models
{
	public class Portal
	{
		public string PortalName { get; set; }

		public PortalOpeningInfo OpeningInfo { get; set; }

		public PortalInfo ToPortalInfo ( DateTime ServerDateTime )
		{
			OpeningInfo.CheckTime ( ServerDateTime );
			var nextOpen  = OpeningInfo.GetTimeUntilNextOpen ( ServerDateTime );
			var remaining = OpeningInfo.GetRemainingTime ( ServerDateTime );
			var info = new PortalInfo
			{
				PortalName   = PortalName,
				IsPortalOpen = OpeningInfo.IsOpen,
				NextOpenIn   = $"{nextOpen:hh\\:mm\\:ss}",
				RemainingTime = remaining == TimeSpan.MaxValue ? "--;--;--" : $"{remaining:hh\\:mm\\:ss}"
			};

			return info;
		}
	}
}
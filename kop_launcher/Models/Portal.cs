using System;

namespace kop_launcher.Models
{
	public class Portal
	{
		public string PortalName { get; set; }

		public PortalOpeningInfo OpeningInfo { get; set; }

		public PortalInfo ToPortalInfo ( DateTime serverDateTime )
		{
			OpeningInfo.CheckTime ( serverDateTime );
			var nextOpen  = OpeningInfo.GetTimeUntilNextOpen ( serverDateTime );
			var remaining = OpeningInfo.GetRemainingTime ( serverDateTime );
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
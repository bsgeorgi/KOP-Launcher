using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace kop_launcher.Models
{
	public class PortalOpeningInfo
	{
		public TimeSpan InitialTime { get; set; }
		public TimeSpan Interval    { get; set; }
		public TimeSpan Duration    { get; set; }
		public bool     IsOpen      { get; private set; }

		public IObservable<bool> State => _state.AsObservable ( );

		private readonly Subject<bool>                         _state;
		private readonly List<(TimeSpan open, TimeSpan close)> _openingTimes;

		public PortalOpeningInfo ( TimeSpan initialTime, TimeSpan interval, TimeSpan duration )
		{
			this.InitialTime = initialTime;
			this.Interval    = interval;
			this.Duration    = duration;

			_state        = new Subject<bool> ( );
			_openingTimes = new List<(TimeSpan, TimeSpan)> ( );

			var time        = initialTime;
			var closingTime = time + duration;
			while ( closingTime.Days == 0 ) // TODO check loop termination logic
			{
				_openingTimes.Add ( ( time, closingTime ) );

				time        += interval;
				closingTime = time + duration;
			}
		}

		public void CheckTime ( DateTime serverDateTime )
		{
			var time = serverDateTime.TimeOfDay;
			if ( time < InitialTime )
				IsOpen = false;

			IsOpen = _openingTimes.Any ( x => x.open <= time && time <= x.close );

			_state.OnNext ( IsOpen );
		}

		public TimeSpan GetTimeUntilNextOpen ( DateTime serverDateTime )
		{
			if ( _openingTimes.Count == 0 )
				return TimeSpan.MaxValue;

			var time = serverDateTime.TimeOfDay;
			if ( _openingTimes.Last ( ).open <= time )
				return InitialTime + TimeSpan.FromDays ( 1 ) - time;

			return _openingTimes.First ( x => x.open >= time ).open - time;
		}

		public TimeSpan GetRemainingTime ( DateTime serverDateTime )
		{
			if ( !IsOpen )
				return TimeSpan.MaxValue;

			var time = serverDateTime.TimeOfDay;
			var pair = _openingTimes.FirstOrDefault ( x => x.open <= time && time <= x.close );
			if ( pair == default )
				return TimeSpan.MaxValue;
			return pair.close - time;
		}
	}
}
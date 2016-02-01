using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Linq;
using System.Reflection;
using Merq;
using Xamarin.Ide.Telemetry.Data.Model;

namespace Xamarin.Ide.Telemetry
{
	[Export (typeof (IAutoLoad))]
	public class TelemetryEventSubscriber : IAutoLoad
	{
		readonly IEventStream events;
		readonly ITelemetryProvider telemetry;

		[ImportingConstructor]
		public TelemetryEventSubscriber (IEventStream events, ITelemetryProvider telemetry)
		{
			this.events = events;
			this.telemetry = telemetry;

			SubscribeTelemetryEvents ();
		}

		void SubscribeTelemetryEvents()
		{
			events
				.Of<object>()
				.Where(ev => ev.IsBrowsable())
				.Subscribe (x => {
					var ev = x as Event;

					if(ev == null) {
						var eventName = x.GetName();
						var properties = x.GetProperties();
						var metrics = x.GetMetrics();

						telemetry.TrackEvent (eventName, properties, metrics);
					} else {
						telemetry.TrackEvent (ev.Name, ev.Properties, ev.Metrics);
					}
				});

			events
				.Of<TelemetryError> ()
				.Subscribe (err => {
					telemetry.TrackError (err);
				});
		}
	}
}

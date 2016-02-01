using System.Collections.Generic;
using System.ComponentModel.Composition;
using Xamarin.Ide.Telemetry;

namespace Xamarin.Ide
{
	[Export (typeof (ITelemetryProvider))]
	class CompositeTelemetryProvider : ITelemetryProvider
	{
		readonly IEnumerable<ITelemetryProvider> providers;

		[ImportingConstructor]
		public CompositeTelemetryProvider ([ImportMany ("TelemetryProvider", typeof (ITelemetryProvider))] IEnumerable<ITelemetryProvider> providers)
		{
			this.providers = providers;
		}

		public void TrackEvent (string eventName, IDictionary<string, string> properties, IDictionary<string, double> metrics)
		{
			foreach (var provider in providers) {
				provider.TrackEvent (eventName, properties, metrics);
			}
		}

		public void TrackError (TelemetryError error)
		{
			foreach (var provider in providers) {
				provider.TrackError (error);
			}
		}
	}
}

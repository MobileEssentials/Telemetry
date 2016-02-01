using System.Collections.Generic;

namespace Xamarin.Ide.Telemetry
{
	public interface ITelemetryProvider
	{
		void TrackEvent (string eventName, IDictionary<string, string> properties, IDictionary<string, double> metrics);

		void TrackError (TelemetryError error);
	}
}

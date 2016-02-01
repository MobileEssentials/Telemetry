using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Xamarin.Ide.Telemetry.XamarinInsights
{
	[Export ("TelemetryProvider", typeof (ITelemetryProvider))]
	public class XamarinInsightsTelemetryProvider : ITelemetryProvider
	{
		public void TrackEvent (string eventName, IDictionary<string, string> properties, IDictionary<string, double> metrics)
		{
		}

		public void TrackError (TelemetryError error)
		{
		}
	}
}

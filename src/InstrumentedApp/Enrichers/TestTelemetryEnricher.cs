using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Xamarin.Ide.Telemetry.Enrichers
{
	[Export (typeof (ITelemetryEnricher))]
	public class TestTelemetryEnricher : ITelemetryEnricher
	{
		public void Enrich (IDictionary<string, string> properties, IDictionary<string, double> metrics)
		{
			properties.Add ("TestTelemetryValue", Guid.NewGuid ().ToString ());
		}
	}
}

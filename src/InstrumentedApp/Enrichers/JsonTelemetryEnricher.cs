using System.Collections.Generic;
using System.ComponentModel.Composition;
using Xamarin.Ide.Telemetry.Data.Generators;

namespace Xamarin.Ide.Telemetry.Enrichers
{
	[Export (typeof (ITelemetryEnricher))]
	public class JsonTelemetryEnricher : ITelemetryEnricher
	{
		readonly IContextGenerator contextGenerator;

		[ImportingConstructor]
		public JsonTelemetryEnricher (IContextGenerator contextGenerator)
		{
			this.contextGenerator = contextGenerator;
		}

		public void Enrich (IDictionary<string, string> properties, IDictionary<string, double> metrics)
		{
			var context = contextGenerator.ReadEventProperties();

			foreach (var contextProperty in context) {
				properties.Add (contextProperty.Key, contextProperty.Value);
			}
		}
	}
}

using System.Collections.Generic;

namespace Xamarin.Ide.Telemetry
{
	public interface ITelemetryEnricher
	{
		void Enrich (IDictionary<string, string> properties, IDictionary<string, double> metrics);
	}
}

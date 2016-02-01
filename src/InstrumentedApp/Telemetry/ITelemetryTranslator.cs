using System.Collections.Generic;

namespace Xamarin.Ide.Telemetry
{
	public interface ITelemetryTranslator
	{
		IDictionary<string, string> Translate (IDictionary<string, string> properties);
	}
}

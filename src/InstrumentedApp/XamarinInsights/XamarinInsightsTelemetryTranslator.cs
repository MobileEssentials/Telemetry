using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Xamarin.Ide.Telemetry.XamarinInsights
{
	[Export ("XamarinInsightsTranslator", typeof (ITelemetryTranslator))]
	public class XamarinInsightsTelemetryTranslator : ITelemetryTranslator
	{
		public IDictionary<string, string> Translate (IDictionary<string, string> properties)
		{
			return new Dictionary<string, string> ();
		}
	}
}

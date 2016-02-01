using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace Xamarin.Ide.Telemetry.AppInsights
{
	[Export ("AppInsightsTranslator", typeof (ITelemetryTranslator))]
	public class AppInsightsTelemetryTranslator : ITelemetryTranslator
	{
		readonly TelemetryClient client;

		[ImportingConstructor]
		public AppInsightsTelemetryTranslator (TelemetryClient client)
		{
			this.client = client;
		}

		public IDictionary<string, string> Translate (IDictionary<string, string> properties)
		{
			var contextActions = ContextActions.Get();
			var result = new Dictionary<string, string>();

			foreach (var property in properties) {
				Action<string, TelemetryContext> defaultAction = (value, context) => {
					result.Add (property.Key, value);
				};
				var telemetryAction = contextActions.ContainsKey(property.Key) ?
					contextActions[property.Key] :
					defaultAction;

				telemetryAction (property.Value, client.Context);
			}

			return result;
		}
	}
}

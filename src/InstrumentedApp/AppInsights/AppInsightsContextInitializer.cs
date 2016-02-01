using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace Xamarin.Ide.Telemetry.AppInsights
{
	[Export ("AppInsightsInitializer", typeof (IContextInitializer))]
	public class AppInsightsContextInitializer : IContextInitializer
	{
		readonly TelemetryClient client;

		[ImportingConstructor]
		public AppInsightsContextInitializer (TelemetryClient client)
		{
			this.client = client;
		}

		public void Inititalize (IDictionary<string, string> context)
		{
			var contextActions = ContextActions.Get();

			foreach (var property in context) {
				Action<string, TelemetryContext> defaultAction = (value, ctx) => {
					ctx.Properties.Add (property.Key, value);
				};
				var contextAction = contextActions.ContainsKey(property.Key) ?
					contextActions[property.Key] :
					defaultAction;

				contextAction (property.Value, client.Context);
			}
		}
	}
}

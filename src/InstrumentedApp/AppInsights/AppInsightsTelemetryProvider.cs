using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace Xamarin.Ide.Telemetry.AppInsights
{
	[Export ("TelemetryProvider", typeof (ITelemetryProvider))]
	public class AppInsightsTelemetryProvider : ITelemetryProvider
	{
		readonly TelemetryClient client;
		readonly IEnumerable<IContextEnricher> contextEnrichers;
		readonly IEnumerable<ITelemetryEnricher> telemetryEnrichers;
		readonly IContextInitializer contextInitializer;
		readonly ITelemetryTranslator telemetryTranslator;

		[ImportingConstructor]
		public AppInsightsTelemetryProvider (TelemetryClient client,
			[ImportMany (typeof (IContextEnricher))] IEnumerable<IContextEnricher> contextEnrichers,
			[ImportMany (typeof (ITelemetryEnricher))] IEnumerable<ITelemetryEnricher> telemetryEnrichers,
			[Import("AppInsightsInitializer", typeof(IContextInitializer))] IContextInitializer contextInitializer,
			[Import ("AppInsightsTranslator", typeof (ITelemetryTranslator))] ITelemetryTranslator telemetryTranslator)
		{
			this.client = client;
			this.contextEnrichers = contextEnrichers;
			this.telemetryEnrichers = telemetryEnrichers;
			this.contextInitializer = contextInitializer;
			this.telemetryTranslator = telemetryTranslator;

			Initialize ();
		}

		public void TrackEvent (string eventName, IDictionary<string, string> properties, IDictionary<string, double> metrics)
		{
			Enrich (properties, metrics);

			var telemetry = new EventTelemetry (eventName);

			foreach (var property in telemetryTranslator.Translate (properties)) {
				telemetry.Properties.Add (property.Key, property.Value);
			}

			foreach (var metric in metrics) {
				telemetry.Metrics.Add (metric.Key, metric.Value);
			}

			client.TrackEvent (telemetry);
		}

		public void TrackError (TelemetryError error)
		{
			var properties = new Dictionary<string, string>();
			var metrics = new Dictionary<string, double>();

			Enrich (properties, metrics);

			var exception = error.Exception;
			var telemetry = new ExceptionTelemetry (exception);

			foreach (var property in telemetryTranslator.Translate (properties)) {
				telemetry.Properties.Add (property.Key, property.Value);
			}

			foreach (DictionaryEntry dataItem in exception.Data) {
				telemetry.Properties.Add ((string)dataItem.Key, (string)dataItem.Value);
			}

			client.TrackException (telemetry);
		}

		void Initialize()
		{
			var context = new Dictionary<string, string>();

			foreach (var contextEnricher in contextEnrichers) {
				contextEnricher.Enrich (context);
			}

			contextInitializer.Inititalize (context);
		}

		void Enrich(IDictionary<string, string> properties, IDictionary<string, double> metrics)
		{
			foreach (var telemetryEnricher in telemetryEnrichers) {
				telemetryEnricher.Enrich (properties, metrics);
			}

		}
	}
}

using System.ComponentModel.Composition;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace Xamarin.Ide.Telemetry.AppInsights
{
	[PartCreationPolicy (CreationPolicy.Shared)]
	public class TelemetryClientProvider
	{
		[ImportingConstructor]
		public TelemetryClientProvider (ITelemetrySettings settings)
		{
			var configuration = TelemetryConfiguration.CreateDefault();

			configuration.TelemetryChannel.DeveloperMode = settings.IsDeveloperMode;
			configuration.InstrumentationKey = settings.ApiKey;
			configuration.DisableTelemetry = !settings.IsEnabled;

			TelemetryClient = new TelemetryClient (configuration);
		}

		[Export]
		public TelemetryClient TelemetryClient { get; }
	}
}

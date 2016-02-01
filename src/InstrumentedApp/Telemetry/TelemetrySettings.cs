using System.ComponentModel.Composition;
using System.Configuration;

namespace Xamarin.Ide.Telemetry
{
	[Export (typeof (ITelemetrySettings))]
	public class TelemetrySettings : ITelemetrySettings
	{
		public TelemetrySettings ()
		{
			ApiKey = ConfigurationManager.AppSettings["AppInsightsApiKey"];
			IsEnabled = true;
			IsDeveloperMode = true;
		}

		public string ApiKey { get; set; }

		public bool IsEnabled { get; set; }

		public bool IsDeveloperMode { get; set; }
	}
}

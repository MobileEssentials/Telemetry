namespace Xamarin.Ide.Telemetry
{
	public interface ITelemetrySettings
	{
		string ApiKey { get; }

		bool IsEnabled { get; }

		bool IsDeveloperMode { get; }
	}
}

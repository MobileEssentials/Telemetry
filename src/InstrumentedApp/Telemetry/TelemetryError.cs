using System;

namespace Xamarin.Ide.Telemetry
{
	public class TelemetryError
	{
		public TelemetryError (Exception ex)
		{
			Exception = ex;
		}

		public Exception Exception { get; private set; }
	}
}

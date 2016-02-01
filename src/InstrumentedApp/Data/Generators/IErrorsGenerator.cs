using System.Collections.Generic;

namespace Xamarin.Ide.Telemetry.Data.Generators
{
	public interface IErrorsGenerator
	{
		IEnumerable<TelemetryError> Generate ();
	}
}

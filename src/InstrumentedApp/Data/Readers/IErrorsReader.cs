using System.Collections.Generic;
using Xamarin.Ide.Telemetry.Data.Model;

namespace Xamarin.Ide.Telemetry.Data.Readers
{
	public interface IErrorsReader
	{
		IEnumerable<ErrorMetadata> ReadErrors ();
	}
}

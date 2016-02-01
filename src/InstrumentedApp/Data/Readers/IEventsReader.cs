using System.Collections.Generic;
using Xamarin.Ide.Telemetry.Data.Model;

namespace Xamarin.Ide.Telemetry.Data.Readers
{
	public interface IEventsReader
	{
		IEnumerable<EventMetadata> ReadEvents ();
	}
}

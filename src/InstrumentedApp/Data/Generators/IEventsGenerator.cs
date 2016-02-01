using System.Collections.Generic;
using Xamarin.Ide.Telemetry.Data.Model;

namespace Xamarin.Ide.Telemetry.Data.Generators
{
	public interface IEventsGenerator
	{
		IEnumerable<Event> Generate ();
	}
}

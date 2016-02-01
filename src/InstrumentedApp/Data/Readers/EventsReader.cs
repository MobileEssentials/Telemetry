using System.Collections.Generic;
using System.ComponentModel.Composition;
using Xamarin.Ide.Telemetry.Data.Model;

namespace Xamarin.Ide.Telemetry.Data.Readers
{
	[Export (typeof (IEventsReader))]
	public class EventsReader : DataReader, IEventsReader
	{
		public IEnumerable<EventMetadata> ReadEvents()
		{
			return Read<IEnumerable<EventMetadata>> (TelemetryConstants.Data.EventsFile);
		}
	}
}

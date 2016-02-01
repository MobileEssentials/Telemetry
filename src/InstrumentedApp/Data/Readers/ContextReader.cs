using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Xamarin.Ide.Telemetry.Data.Readers
{
	[Export (typeof (IContextReader))]
	public class ContextReader : DataReader, IContextReader
	{
		public JObject ReadContextProperties ()
		{
			var contextValues = Read<Dictionary<string, JObject>>(TelemetryConstants.Data.ContextFile);

			return contextValues.First (v => v.Key == "ContextProperties").Value;
		}

		public JObject ReadEventProperties ()
		{
			var contextValues = Read<Dictionary<string, JObject>>(TelemetryConstants.Data.ContextFile);

			return contextValues.First (v => v.Key == "EventProperties").Value;
		}
	}
}

using System.Collections.Generic;

namespace Xamarin.Ide.Telemetry.Data.Model
{
	public class Event
	{
		public Event ()
		{
			Properties = new Dictionary<string, string> ();
			Metrics = new Dictionary<string, double> ();
		}

		public string Name { get; set; }

		public IDictionary<string, string> Properties { get; set; }

		public IDictionary<string, double> Metrics { get; set; }
	}
}

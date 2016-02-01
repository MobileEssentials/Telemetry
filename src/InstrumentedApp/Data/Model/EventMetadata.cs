using System.Collections.Generic;

namespace Xamarin.Ide.Telemetry.Data.Model
{
	public class EventMetadata
	{
		public string EventName { get; set; }

		public int Count { get; set; }

		public Metadata Metadata { get; set; }
	}

	public class Range
	{
		public int MinValue { get; set; }

		public int MaxValue { get; set; }
	}

	public class Property
	{
		public string Name { get; set; }

		public string Type { get; set; }

		public Range Range { get; set; }

		public string Value { get; set; }
	}

	public class Metric
	{
		public string Name { get; set; }

		public Range Range { get; set; }

		public double Value { get; set; }
	}

	public class Metadata
	{
		public Metadata ()
		{
			Properties = new List<Property> ();
			Metrics = new List<Metric> ();
		}

		public List<Property> Properties { get; set; }

		public List<Metric> Metrics { get; set; }
	}
}

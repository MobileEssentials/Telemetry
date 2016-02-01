using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Xamarin.Ide.Telemetry.Data.Model;
using Xamarin.Ide.Telemetry.Data.Readers;

namespace Xamarin.Ide.Telemetry.Data.Generators
{
	[Export (typeof (IEventsGenerator))]
	public class EventsGenerator : IEventsGenerator
	{
		readonly Random random = new Random(Guid.NewGuid().GetHashCode());
		readonly IEventsReader reader;

		[ImportingConstructor]
		public EventsGenerator (IEventsReader reader)
		{
			this.reader = reader;
		}

		public IEnumerable<Event> Generate ()
		{
			var events = new List<Event>();
			var metadata = reader.ReadEvents();

			foreach(var metadataItem in metadata) {
				var metadataEvents = GetEvents (metadataItem);

				events.AddRange (metadataEvents);
			}

			return events;
		}

		IEnumerable<Event> GetEvents(EventMetadata metadata)
		{
			var events = new List<Event>();

			for(var i = 1; i <= metadata.Count; i++) {
				events.Add (GetEvent (metadata));
			}

			return events;
		}

		Event GetEvent(EventMetadata metadata)
		{
			var ev = new Event
			{
				Name = metadata.EventName
			};
			var properties = GetProperties(metadata);
			var metrics = GetMetrics(metadata);

			foreach(var property in properties) {
				ev.Properties.Add (property);
			}

			foreach (var metric in metrics) {
				ev.Metrics.Add (metric);
			}

			return ev;
		}

		IDictionary<string, string> GetProperties(EventMetadata metadata)
		{
			var result = new Dictionary<string, string>();
			var properties = metadata.Metadata?.Properties;

			foreach (var property in properties) {
				var name = property.Name;
				var value = property.Value;

				var type = Type.GetType(property.Type, throwOnError: false, ignoreCase: true);

				if (string.IsNullOrEmpty (value) && type == null) {
					continue;
				}

				if (string.IsNullOrEmpty(value)) {
					value = GetValue (type, property.Range);
				}

				result.Add (name, value);
			}

			return result;
		}

		IDictionary<string, double> GetMetrics(EventMetadata metadata)
		{
			var result = new Dictionary<string, double>();
			var metrics = metadata.Metadata?.Metrics;

			foreach(var metric in metrics) {
				var name = metric.Name;
				var value = metric.Value;

				if(value < 1) {
					value = metric.Range == null ?
					random.NextDouble () :
					random.Next (metric.Range.MinValue, metric.Range.MaxValue);
				}

				result.Add (name, value);
			}

			return result;
		}

		string GetValue(Type type, Range range = null)
		{
			var value = string.Empty;

			if(type == typeof(int) || type == typeof(long) || type == typeof(double)) {
				value = range == null ?
					random.Next ().ToString() :
					random.Next (range.MinValue, range.MaxValue).ToString();
			} else if(type == typeof(Guid)) {
				value = Guid.NewGuid ().ToString ();
			} else if(type == typeof(bool)) {
				value = (random.Next () % 2 == 0).ToString();
			} else if(type == typeof(DateTime)) {
				value = DateTime.UtcNow.AddDays (random.Next (minValue: -30, maxValue: 0)).ToString();
			} else if(type == typeof(string)) {
				value = Guid.NewGuid ().ToString ().Substring (0, 8);
			}

			return value;
		}
	}
}

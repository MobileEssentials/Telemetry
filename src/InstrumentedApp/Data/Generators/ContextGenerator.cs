using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Newtonsoft.Json.Linq;
using Xamarin.Ide.Telemetry.Data.Readers;

namespace Xamarin.Ide.Telemetry.Data.Generators
{
	[Export (typeof (IContextGenerator))]
	public class ContextGenerator : IContextGenerator
	{
		readonly IContextReader reader;

		[ImportingConstructor]
		public ContextGenerator (IContextReader reader)
		{
			this.reader = reader;
		}

		public IDictionary<string, string> ReadContextProperties ()
		{
			var contextObject = reader.ReadContextProperties();

			return ParseProperties (contextObject);
		}

		public IDictionary<string, string> ReadEventProperties ()
		{
			var contextObject = reader.ReadEventProperties();

			return ParseProperties (contextObject);
		}

		IDictionary<string, string> ParseProperties (JObject obj)
		{
			var random = new Random();
			var properties = new Dictionary<string, string>();

			foreach (var element in obj) {
				var value = default(string);

				if (element.Value.Type == JTokenType.Object) {
					continue;
				} else if (element.Value.Type == JTokenType.Array) {
					var values = element.Value.ToObject<IList<string>>();

					for (var i = 1; i <= random.Next (1, values.Count); i++) {
						value = values[random.Next (0, values.Count - 1)];
						properties[value] = value;
					}
				} else {
					value = element.Value.ToString ();

					if (value.Contains ("|")) {
						var options = value.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

						value = options[random.Next (0, options.Count () - 1)];
					} else if (value.Contains ("..")) {
						var range = value.Split(new string[] { ".." }, StringSplitOptions.RemoveEmptyEntries);
						var minValue = default(int);
						var maxValue = default(int);

						if (range.Count () == 2 &&
							int.TryParse (range[0], out minValue) &&
							int.TryParse (range[1], out maxValue)) {
							value = random.Next (minValue, maxValue).ToString ();
						}
					}

					properties[element.Key] = value.Trim ();
				}
			}

			return properties;
		}
	}
}

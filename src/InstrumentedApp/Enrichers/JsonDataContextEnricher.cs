using System.Collections.Generic;
using System.ComponentModel.Composition;
using Xamarin.Ide.Telemetry.Data.Generators;

namespace Xamarin.Ide.Telemetry.Enrichers
{
	[Export (typeof (IContextEnricher))]
	public class JsonDataContextEnricher : IContextEnricher
	{
		readonly IContextGenerator contextGenerator;

		[ImportingConstructor]
		public JsonDataContextEnricher (IContextGenerator contextGenerator)
		{
			this.contextGenerator = contextGenerator;
		}

		public void Enrich (IDictionary<string, string> properties)
		{
			var context = contextGenerator.ReadContextProperties();

			foreach(var contextProperty in context) {
				properties.Add (contextProperty.Key, contextProperty.Value);
			}
		}
	}
}

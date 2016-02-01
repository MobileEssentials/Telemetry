using System.Collections.Generic;

namespace Xamarin.Ide.Telemetry
{
	public interface IContextEnricher
	{
		void Enrich (IDictionary<string, string> properties);
	}
}

using System.Collections.Generic;

namespace Xamarin.Ide.Telemetry.Data.Generators
{
	public interface IContextGenerator
	{
		IDictionary<string, string> ReadContextProperties ();

		IDictionary<string, string> ReadEventProperties ();
	}
}

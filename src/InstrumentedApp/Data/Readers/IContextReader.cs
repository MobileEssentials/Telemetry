using Newtonsoft.Json.Linq;

namespace Xamarin.Ide.Telemetry.Data.Readers
{
	public interface IContextReader
	{
		JObject ReadContextProperties ();

		JObject ReadEventProperties ();
	}
}

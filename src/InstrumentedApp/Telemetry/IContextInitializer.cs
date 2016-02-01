using System.Collections.Generic;

namespace Xamarin.Ide.Telemetry
{
	public interface IContextInitializer
	{
		void Inititalize (IDictionary<string, string> context);
	}
}

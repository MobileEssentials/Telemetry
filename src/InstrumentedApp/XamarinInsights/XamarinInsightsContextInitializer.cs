using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Xamarin.Ide.Telemetry.XamarinInsights
{
	[Export ("XamarinInsightsInitializer", typeof (IContextInitializer))]
	public class XamarinInsightsContextInitializer : IContextInitializer
	{
		public void Inititalize (IDictionary<string, string> context)
		{
		}
	}
}

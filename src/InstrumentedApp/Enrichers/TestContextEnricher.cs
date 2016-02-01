using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Xamarin.Ide.Telemetry.Enrichers
{
	[Export (typeof (IContextEnricher))]
	public class TestContextEnricher : IContextEnricher
	{
		public void Enrich (IDictionary<string, string> properties)
		{
			properties.Add (TelemetryConstants.Context.SessionId, Guid.NewGuid ().ToString ());
			properties.Add ("TestContextValue", Guid.NewGuid ().ToString ());
		}
	}
}

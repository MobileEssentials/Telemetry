using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Xamarin.Ide.Telemetry.Enrichers
{
	[Export (typeof (IContextEnricher))]
	public class SessionContextEnricher : IContextEnricher
	{
		public void Enrich (IDictionary<string, string> properties)
		{
			properties.Add (TelemetryConstants.Context.User.SessionId, Guid.NewGuid ().ToString ());
		}
	}
}

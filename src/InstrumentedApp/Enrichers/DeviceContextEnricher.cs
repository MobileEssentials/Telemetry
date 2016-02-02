using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Xamarin.Ide.Telemetry.Enrichers
{
	[Export (typeof (IContextEnricher))]
	public class DeviceContextEnricher : IContextEnricher
	{
		public void Enrich (IDictionary<string, string> properties)
		{
			properties.Add (TelemetryConstants.Context.Device.DeviceId, Guid.NewGuid ().ToString ());
			properties.Add (TelemetryConstants.Context.Device.DeviceModel, "Bar Model");
			properties.Add (TelemetryConstants.Context.Device.OperatingSystem, Environment.OSVersion.ToString());

			var ipAddress = Dns.GetHostAddresses(Dns.GetHostName())
				.FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork)?.ToString();

			properties.Add (TelemetryConstants.Context.IpAddress, ipAddress ?? IPAddress.Any.ToString());
		}
	}
}

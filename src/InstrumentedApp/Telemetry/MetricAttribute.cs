using System;

namespace Xamarin.Ide.Telemetry
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class MetricAttribute : Attribute
	{
	}
}

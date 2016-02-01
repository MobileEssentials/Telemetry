using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Xamarin.Ide.Telemetry
{
	public static class TrackObject
	{
		public static string GetName (this object value) => value
			.GetType ()
			.GetCustomAttributes<DisplayNameAttribute> (inherit: true)
			.Select (x => x.DisplayName)
			.FirstOrDefault () ?? value.GetType ().Name;

		public static IDictionary<string, string> GetProperties (this object value) => value
			.GetType ()
			.GetProperties ()
			.Where (prop => prop.IsBrowsable())
			.Where (prop => !prop.GetCustomAttributes<MetricAttribute> (inherit: true).Any ())
			.ToDictionary (
				prop => prop.Name,
				prop => prop.GetValue (value)?.ToString ());

		public static IDictionary<string, double> GetMetrics (this object value) => value
			.GetType ()
			.GetProperties ()
			.Where (prop => prop.IsBrowsable ())
			.Where (p => p.GetCustomAttributes<MetricAttribute> (inherit: true).Any ())
			.Where (p => p.PropertyType == typeof (double))
			.ToDictionary (
				p => p.FullName (),
				p => (double)p.GetValue (value));
	}
}

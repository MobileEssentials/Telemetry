using System.ComponentModel;
using System.Linq;

namespace System.Reflection
{
	public static class PropertyInfoExtensions
	{
		public static string FullName (this PropertyInfo property)
		{
			return string.Format ("{0}.{1}", property.DeclaringType.Name, property.Name);
		}

		public static bool IsBrowsable (this PropertyInfo property)
		{
			return property
				.GetCustomAttributes<BrowsableAttribute> (inherit: true)
				// Project a nullable bool so the default will be null
				.Select (attr => (bool?)attr.Browsable)
				// So that we can easily make true the default value
				.FirstOrDefault () ?? true;
		}
	}
}

namespace System
{
	using Reflection;

	public static class ObjectExtensions
	{
		public static bool IsBrowsable (this object obj)
		{
			return obj
				.GetType ()
				.GetCustomAttributes<BrowsableAttribute> (inherit: true)
				// Project a nullable bool so the default will be null
				.Select (attr => (bool?)attr.Browsable)
				// So that we can easily make true the default value
				.FirstOrDefault () ?? true;
		}
	}
}


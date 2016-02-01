using System.Collections.Generic;

namespace Xamarin.Ide.Telemetry.Data.Model
{
	public class ErrorMetadata
	{
		public ErrorMetadata ()
		{
			Data = new Dictionary<string, string> ();
		}

		public string Type { get; set; }

		public string Message { get; set; }

		public Dictionary<string, string> Data { get; set; }
	}
}

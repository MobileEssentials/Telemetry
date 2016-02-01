using System.IO;
using Newtonsoft.Json;

namespace Xamarin.Ide.Telemetry.Data.Readers
{
	public class DataReader
	{
		public T Read<T> (string fileName)
		{
			var result = default(T);

			using (var stream = File.OpenText (fileName)) {
				using (var reader = new JsonTextReader (stream)) {
					var serializer = new JsonSerializer();

					result = serializer.Deserialize<T> (reader);
				}
			}

			return result;
		}
	}
}

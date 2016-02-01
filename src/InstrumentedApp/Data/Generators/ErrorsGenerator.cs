using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Xamarin.Ide.Telemetry.Data.Readers;

namespace Xamarin.Ide.Telemetry.Data.Generators
{
	[Export (typeof (IErrorsGenerator))]
	public class ErrorsGenerator : IErrorsGenerator
	{
		readonly IErrorsReader reader;

		[ImportingConstructor]
		public ErrorsGenerator (IErrorsReader reader)
		{
			this.reader = reader;
		}

		public IEnumerable<TelemetryError> Generate ()
		{
			var errors = new List<TelemetryError>();
			var metadata = reader.ReadErrors();

			foreach (var metadataItem in metadata) {
				var typeName = string.IsNullOrEmpty(metadataItem.Type) ? "System.Exception" : metadataItem.Type;
				var type = Type.GetType(typeName, throwOnError: false, ignoreCase: true);

				if(type == null || !typeof(Exception).IsAssignableFrom(type)) {
					continue;
				}

				var exception = (Exception)Activator.CreateInstance(type, metadataItem.Message);

				foreach(var dataItem in metadataItem.Data) {
					exception.Data.Add (dataItem.Key, dataItem.Value);
				}

				errors.Add (new TelemetryError (exception));
			}

			return errors;
		}
	}
}

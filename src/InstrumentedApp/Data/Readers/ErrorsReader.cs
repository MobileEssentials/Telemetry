using System.Collections.Generic;
using System.ComponentModel.Composition;
using Xamarin.Ide.Telemetry.Data.Model;

namespace Xamarin.Ide.Telemetry.Data.Readers
{
	[Export (typeof (IErrorsReader))]
	public class ErrorsReader : DataReader, IErrorsReader
	{
		public IEnumerable<ErrorMetadata> ReadErrors()
		{
			return Read<IEnumerable<ErrorMetadata>> (TelemetryConstants.Data.ErrorsFile);
		}
	}
}

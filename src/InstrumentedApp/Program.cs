using System;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Merq;
using Microsoft.ApplicationInsights;
using Newtonsoft.Json;
using Xamarin.Ide.Telemetry.Data.Generators;

namespace Xamarin.Ide
{
	class Program
	{
		static readonly Random random = new Random();

		static void Main (string[] args)
		{
			#region Deprecated

			//var telemetry = new TelemetryClient ();
			//telemetry.Context.InstrumentationKey = "f200ff9e-3a4a-47a4-8288-3c4a485c173b";
			//telemetry.TrackTrace ("App Started");
			//telemetry.Flush ();
			//telemetry.TrackEvent ("AppStarted");
			//telemetry.TrackEvent ("AppFinished", 
			//	metrics: new Dictionary<string, double> { { "Elapsed", 2000 } });
			//telemetry.Flush ();
			//telemetry.TrackException (new InvalidOperationException ("Boo!"));
			//telemetry.Flush ();
			//telemetry.TrackMetric ("AppRunning", 2000);
			//telemetry.Flush ();

			#endregion

			var container = new CompositionContainer(new AssemblyCatalog(typeof(Program).Assembly));

			TraceEvents (container);

			// Components that need to be started up-front, like event subscribers

			container.GetExportedValues<IAutoLoad> ().ToArray ();

			var stream = container.GetExportedValue<IEventStream>();

			var eventsGenerator = container.GetExportedValue<IEventsGenerator>();
			var errorsGenerator = container.GetExportedValue<IErrorsGenerator>();

			var events = eventsGenerator.Generate();

			foreach(var ev in events) {
				stream.Push (ev);
			}

			var errors = errorsGenerator.Generate();

			foreach (var error in errors) {
				stream.Push (error);
			}

			container.GetExportedValue<TelemetryClient> ().Flush ();

			Thread.Sleep (1000);
		}

		[Conditional("TRACE")]
		static void TraceEvents(CompositionContainer container)
		{
			var events = container.GetExportedValue<IEventStream>();
			events.Of<object> ().Subscribe (e => Console.WriteLine (JsonConvert.SerializeObject(e)));
		}
	}
}

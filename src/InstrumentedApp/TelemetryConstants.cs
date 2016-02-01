namespace Xamarin.Ide
{
	public static class TelemetryConstants
	{
		public static readonly DataConstants Data = new DataConstants();

		public static readonly ContextConstants Context = new ContextConstants();
	}

	public class DataConstants
	{
		public readonly string ContextFile = @"Data\context.json";

		public readonly string ErrorsFile = @"Data\errors.json";

		public readonly string EventsFile = @"Data\events.json";
	}

	public class ContextConstants
	{
		public readonly string UserId = "UserId";

		public readonly string AccountId = "AccountId";

		public readonly string SessionId = "SessionId";

		public readonly string MachineName = "MachineName";
	}
}

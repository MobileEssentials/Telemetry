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
		public readonly UserConstants User = new UserConstants();

		public readonly DeviceConstants Device = new DeviceConstants();

		public readonly string MachineName = "MachineName";

		public readonly string Version = "Version";

		public readonly string IpAddress = "IpAddress";
	}

	public class UserConstants
	{
		public readonly string UserId = "UserId";

		public readonly string AccountId = "AccountId";

		public readonly string SessionId = "SessionId";
	}

	public class DeviceConstants
	{
		public readonly string DeviceId = "DeviceId";

		public readonly string DeviceModel = "DeviceModel";

		public readonly string OperatingSystem = "OperatingSystem";
	}
}

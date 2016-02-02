using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.ApplicationInsights.DataContracts;

namespace Xamarin.Ide.Telemetry.AppInsights
{
	public sealed class ContextActions : Dictionary<string, Action<string, TelemetryContext>>
	{
		static readonly Lazy<IDictionary<string, Action<string, TelemetryContext>>> instance;

		static ContextActions()
		{
			instance = new Lazy<IDictionary<string, Action<string, TelemetryContext>>> (() => {
				var contextActions = new Dictionary<string, Action<string, TelemetryContext>>();

				contextActions.Add (TelemetryConstants.Context.User.SessionId, (sessionId, context) => {
					context.Session.Id = sessionId;
					context.Properties[TelemetryConstants.Context.User.SessionId] = sessionId;
				});

				contextActions.Add (TelemetryConstants.Context.User.AccountId, (accountId, context) => {
					context.User.AccountId = accountId;
					context.Properties[TelemetryConstants.Context.User.AccountId] = accountId;
				});

				contextActions.Add (TelemetryConstants.Context.User.UserId, (userId, context) => {
					context.User.Id = userId;
					context.Properties[TelemetryConstants.Context.User.UserId] = userId;
				});

				contextActions.Add (TelemetryConstants.Context.Version, (version, context) => {
					context.Component.Version = version;
				});

				contextActions.Add (TelemetryConstants.Context.Device.DeviceId, (deviceId, context) => {
					context.Device.Id = deviceId;
				});

				contextActions.Add (TelemetryConstants.Context.Device.DeviceModel, (deviceModel, context) => {
					context.Device.Model = deviceModel;
				});

				contextActions.Add (TelemetryConstants.Context.Device.OperatingSystem, (operatingSystem, context) => {
					context.Device.OperatingSystem = operatingSystem;
				});

				contextActions.Add (TelemetryConstants.Context.IpAddress, (ip, context) => {
					context.Location.Ip = ip;
				});

				return contextActions;
			});
		}

		public static IDictionary<string, Action<string, TelemetryContext>> Get ()
		{
			return instance.Value;
		}

		ContextActions ()
		{
		}

		ContextActions (IDictionary<string, Action<string, TelemetryContext>> dictionary) : base (dictionary)
		{
		}

		ContextActions (IEqualityComparer<string> comparer) : base (comparer)
		{
		}

		ContextActions (int capacity) : base (capacity)
		{
		}

		ContextActions (IDictionary<string, Action<string, TelemetryContext>> dictionary, IEqualityComparer<string> comparer) : base (dictionary, comparer)
		{
		}

		ContextActions (int capacity, IEqualityComparer<string> comparer) : base (capacity, comparer)
		{
		}

		ContextActions (SerializationInfo info, StreamingContext context) : base (info, context)
		{
		}
	}
}

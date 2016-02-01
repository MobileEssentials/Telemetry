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

				contextActions.Add (TelemetryConstants.Context.SessionId, (sessionId, context) => {
					context.Session.Id = sessionId;
					context.Properties[TelemetryConstants.Context.SessionId] = sessionId;
				});

				contextActions.Add (TelemetryConstants.Context.AccountId, (accountId, context) => {
					context.User.AccountId = accountId;
					context.Properties[TelemetryConstants.Context.AccountId] = accountId;
				});

				contextActions.Add (TelemetryConstants.Context.UserId, (userId, context) => {
					context.User.Id = userId;
					context.Properties[TelemetryConstants.Context.UserId] = userId;
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

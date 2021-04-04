using System;

namespace Someday.SDK.APIClients.Common
{
	public abstract class RequestBase<T> where T : RequestBase<T>
	{
		protected virtual string endPoint { get; }
		protected string query { get; private set; }

		protected string BuildURL()
		{
			string url = endPoint;
			if(!string.IsNullOrEmpty(query)) { url += $"?{query}"; }
			return Uri.EscapeUriString(url);
		}

		protected T SetField(string name, string value)
		{
			if(!string.IsNullOrEmpty(query)) { query += "&"; }
			query += $"{name}={value}";
			return (T)this;
		}
	}
}

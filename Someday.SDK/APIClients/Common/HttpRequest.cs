﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Someday.SDK.APIClients.Common
{
	public abstract class HttpRequest<T> where T : HttpRequest<T>
	{
		protected virtual string endPoint { get; }
		protected string query { get; private set; }

		protected T SetField(string name, string value)
		{
			if(!string.IsNullOrEmpty(query)) { query += "&"; }
			query += $"{name}={value}";
			return (T)this;
		}

		protected async Task<string> GetAsync()
		{
			HttpResponseMessage response = await HttpClientFactory.Get().GetAsync(BuildURL());
			return await response.Content.ReadAsStringAsync();
		}

		protected string BuildURL()
		{
			string url = endPoint;
			if(!string.IsNullOrEmpty(query)) { url += $"?{query}"; }
			return Uri.EscapeUriString(url);
		}
	}
}
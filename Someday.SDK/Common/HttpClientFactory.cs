using System.Net.Http;
using System.Collections.Generic;

namespace Someday.SDK
{
	internal static class HttpClientFactory
	{
		private static readonly string defaultHttpClientKey = "0";
		private static Dictionary<string, HttpClient> httpClients = new Dictionary<string, HttpClient>();

		static HttpClientFactory()
		{
			Set(defaultHttpClientKey, new HttpClient());
		}

		public static HttpClient Get()
		{
			return httpClients[defaultHttpClientKey];
		}

		public static bool TryGet(string key, out HttpClient client)
		{
			return httpClients.TryGetValue(key, out client);
		}

		public static HttpClient Set(string key, HttpClient client)
		{
			if(TryGet(key, out HttpClient existingClient)) { return existingClient; }
			return httpClients[key] = client;
		}
	}
}

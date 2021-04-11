using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Someday.SDK.APIClients.Common
{
	public abstract class HttpRequest<T> where T : HttpRequest<T>
	{
		protected abstract string EndPoint { get; }

		protected string Query { get; private set; } = string.Empty;
		protected HttpClient Client { get; init; }

		public HttpRequest()
		{
			Client = HttpClientFactory.Get();
		}

		public HttpRequest(HttpClient client)
		{
			Client = client;
		}

		protected T SetField(string name, string value)
		{
			if(!string.IsNullOrEmpty(Query)) { Query += "&"; }
			Query += $"{name}={value}";
			return (T)this;
		}

		protected async Task<string> GetAsync()
		{
			HttpResponseMessage response = await Client.GetAsync(BuildURL());
			return await response.Content.ReadAsStringAsync();
		}

		protected string BuildURL()
		{
			string url = EndPoint;
			if(!string.IsNullOrEmpty(Query)) { url += $"?{Query}"; }
			return Uri.EscapeUriString(url);
		}
	}
}

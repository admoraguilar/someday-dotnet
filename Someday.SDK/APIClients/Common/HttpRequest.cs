using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Someday.SDK.APIClients.Common
{
	public abstract class HttpRequest<T> where T : HttpRequest<T>
	{
		protected abstract string EndPoint { get; }

		private QueryBuilder queryBuilder { get; } = new("&");
		private HttpClient client { get; init; }

		public HttpRequest() => client = HttpClientFactory.Get();

		public HttpRequest(HttpClient client) => this.client = client;

		protected T SetQueryField(string name, object value) =>
			DoAction(() => queryBuilder.SetField(name, value));

		protected T AddQueryField(string name, object value) =>
			DoAction(() => queryBuilder.AddField(name, value));

		protected T RemoveQueryField(string name) =>
			DoAction(() => queryBuilder.RemoveField(name));

		protected async Task<string> GetAsync()
		{
			HttpResponseMessage response = await client.GetAsync(BuildURL());
			return await response.Content.ReadAsStringAsync();
		}

		protected string BuildURL()
		{
			string url = EndPoint;

			string query = queryBuilder.Build();
			if(!string.IsNullOrEmpty(query)) { url += $"?{query}"; }
			
			return Uri.EscapeUriString(url);
		}

		private T DoAction(Action action)
		{
			action();
			return (T)this;
		}
	}
}

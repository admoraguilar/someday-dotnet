using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Common;

namespace Someday.SDK.APIClients.Unsplash
{
	public class SearchPhotosRequest : HttpRequest<SearchPhotosRequest>
	{
		protected override string EndPoint => "https://api.unsplash.com/search/photos";

		public SearchPhotosRequest SetClientId(string value) =>
			SetQueryField("client_id", value);

		public SearchPhotosRequest SetQuery(string value) =>
			SetQueryField("query", value);

		public SearchPhotosRequest SetPage(int value) =>
			SetQueryField("page", value.ToString());

		public SearchPhotosRequest SetPerPage(int value) =>
			SetQueryField("per_page", value);

		public SearchPhotosRequest SetOrderBy(string value) =>
			SetQueryField("order_by", value);

		public SearchPhotosRequest SetCollections(params string[] values) =>
			SetQueryField("collections", string.Join(",", values));

		public SearchPhotosRequest SetContentFilter(string value) =>
			SetQueryField("content_filter", value);

		public SearchPhotosRequest SetColor(string value) =>
			SetQueryField("color", value);

		public SearchPhotosRequest SetOrientation(string value) =>
			SetQueryField("orientation", value);

		public SearchPhotosRequest SetLang(string value) =>
			SetQueryField("lang", value);

		public async Task<IEnumerable<Photo>> SendAsync()
		{
			string content = await GetAsync();
			string results = JObject.Parse(content)["results"]!.ToString();
			return PhotoJson.DeserializeArray(results);
		}
	}
}

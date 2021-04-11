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
			SetField("client_id", value);

		public SearchPhotosRequest SetQuery(string value) =>
			SetField("query", value);

		public SearchPhotosRequest SetPage(int value) =>
			SetField("page", value.ToString());

		public SearchPhotosRequest SetPerPage(int value) =>
			SetField("per_page", value.ToString());

		public SearchPhotosRequest SetOrderBy(string value) =>
			SetField("order_by", value);

		public SearchPhotosRequest SetCollections(params string[] values)
		{
			if(values.Length == 1) { return SetField("collections", values[0]); }
			return SetField("collections", string.Join(",", values));
		}

		public SearchPhotosRequest SetContentFilter(string value) =>
			SetField("content_filter", value);

		public SearchPhotosRequest SetColor(string value) =>
			SetField("color", value);

		public SearchPhotosRequest SetOrientation(string value) =>
			SetField("orientation", value);

		public SearchPhotosRequest SetLang(string value) =>
			SetField("lang", value);

		public async Task<IEnumerable<Photo>> SendAsync()
		{
			string content = await GetAsync();
			string results = JObject.Parse(content)["results"]!.ToObject<string>()!;
			return PhotoJson.DeserializeArray(results);
		}
	}
}

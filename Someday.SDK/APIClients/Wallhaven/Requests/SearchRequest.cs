using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Common;

namespace Someday.SDK.APIClients.Wallhaven
{
	public class SearchRequest : HttpRequest<SearchRequest>
	{
		protected override string EndPoint => "https://wallhaven.cc/api/v1/search";

		public SearchRequest SetQ(string value) =>
			SetQueryField("q", value);

		public SearchRequest SetCategories(params string[] values)
		{
			string catStr = string.Empty;
			AppendStringFlagIf(ref catStr, values.Contains(Category.General));
			AppendStringFlagIf(ref catStr, values.Contains(Category.Anime));
			AppendStringFlagIf(ref catStr, values.Contains(Category.People));
			return SetQueryField("categories", catStr);
		}

		public SearchRequest SetPurity(params string[] values)
		{
			string purStr = string.Empty;
			AppendStringFlagIf(ref purStr, values.Contains(Purity.SFW));
			AppendStringFlagIf(ref purStr, values.Contains(Purity.Sketchy));
			AppendStringFlagIf(ref purStr, values.Contains(Purity.NSFW));
			return SetQueryField("purity", purStr);
		}

		public SearchRequest SetSorting(string value) =>
			SetQueryField("sorting", value);

		public SearchRequest SetOrder(string value) =>
			SetQueryField("order", value);

		public SearchRequest SetTopRange(string value) =>
			SetQueryField("topRange", value);

		public SearchRequest SetAtLeast(Dimension value) =>
			SetQueryField("atleast", $"{value.Width}x{value.Height}");

		public SearchRequest SetResolutions(Dimension[] dimensions)
		{
			string dimStr = string.Empty;
			foreach(Dimension dimension in dimensions) {
				dimStr += $"{dimension.Width}x{dimension.Height},";
			}
			dimStr = dimStr.Substring(0, dimStr.Length - 1);
			return SetQueryField("resolutions", dimStr);
		}

		public SearchRequest SetRatios(Dimension value) =>
			SetQueryField("ratios", $"{value.Width}x{value.Height}");

		public SearchRequest SetColor(string value) =>
			SetQueryField("colors", value);

		public SearchRequest SetPage(int value) =>
			SetQueryField("page", value);

		public SearchRequest SetSeed(string value) =>
			SetQueryField("seed", value);

		public async Task<IEnumerable<Image>> SendAsync()
		{
			string content = await GetAsync();
			string data = JObject.Parse(content)["data"]!.ToString();
			return ImageJson.DeserializeArray(data);
		}

		private string AppendStringFlagIf(ref string str, bool condition) => 
			str += condition ? "1" : "0";
	}
}

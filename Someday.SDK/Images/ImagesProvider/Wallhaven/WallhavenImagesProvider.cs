using System.Web;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Someday.SDK
{
	public class WallhavenImagesProvider : ImagesProvider
	{
		public override async Task<List<string>> GetRandomImagesAsync()
		{
			return await GetImagesAsync($"https://wallhaven.cc/api/v1/search?q=%22mountain%22&category=100&purity=100&atleast=1600x900&sorting=random&order=desc");
		}

		public override async Task<List<string>> SearchImagesAsync(SearchImagesQuery query)
		{
			return await GetImagesAsync($"https://wallhaven.cc/api/v1/search?q={query.Query}&categories=100&purity=100&atleast=1600x900&sorting=relevance&order=desc");
		}

		private async Task<List<string>> GetImagesAsync(string url)
		{
			string urlEncoded = HttpUtility.UrlEncode(url);

			HttpResponseMessage response = await HttpClientFactory.Get().GetAsync(urlEncoded);
			string content = await response.Content.ReadAsStringAsync();

			string dataJson = JObject.Parse(content)["data"].ToString();
			WallhavenImage[] images = JsonConvert.DeserializeObject<WallhavenImage[]>(dataJson);

			return images.Select(img => img.Path).ToList();
		}
	}
}

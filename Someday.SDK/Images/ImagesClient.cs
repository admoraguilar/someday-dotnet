using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Someday.SDK
{
	public class ImagesClient
	{
		public async Task<List<string>> GetImagesAsync()
		{
			WallhavenImagesProvider provider = new WallhavenImagesProvider();
			return await provider.SearchImagesAsync();
		}
	}

	public abstract class ImagesProvider
	{
		public abstract Task<List<string>> SearchImagesAsync();
	}

	public class WallhavenImagesProvider : ImagesProvider
	{
		public override async Task<List<string>> SearchImagesAsync()
		{
			string apiUrl = "https://wallhaven.cc/api/v1/search?q=anime+girl&categories=010&purity=100&atleast=1600x900&sorting=relevance&order=desc";
			HttpResponseMessage response = await HttpClientFactory.Get().GetAsync(apiUrl);
			string content = await response.Content.ReadAsStringAsync();

			string dataJson = JObject.Parse(content)["data"].ToString();
			WallhavenImage[] images = JsonConvert.DeserializeObject<WallhavenImage[]>(dataJson);

			return images.Select(img => img.Path).ToList();
		}
	}

	public class WallhavenImage
	{
		public string Id { get; private set; }
		public string Url { get; private set; }
		public string ShortUrl { get; private set; }
		public int Views { get; private set; }
		public int Favorites { get; private set; }
		public string Source { get; private set; }
		public string Purity { get; private set; }
		public string Category { get; private set; }
		public int DimensionX { get; private set; }
		public int DimensionY { get; private set; }
		public string Resolution { get; private set; }
		public string Ratio { get; private set; }
		public int FileSize { get; private set; }
		public string FileType { get; private set; }
		public DateTimeOffset CreatedAt { get; private set; }
		public string[] Colors { get; private set; }
		public string Path { get; private set; }
		public Dictionary<string, string> Thumbs { get; private set; }

		public WallhavenImage(
			string id, string url, int views, int favorites, string source,
			string purity, string category, int dimension_x, int dimension_y, string resolution,
			string ratio, int file_size, string file_type, DateTimeOffset created_at, string[] colors,
			string path, Dictionary<string, string> thumbs)
		{
			Id = id;
			Url = url;
			Views = views;
			Favorites = favorites;
			Source = source;
			Purity = purity;
			Category = category;
			DimensionX = dimension_x;
			DimensionY = dimension_y;
			Resolution = resolution;
			Ratio = ratio;
			FileSize = file_size;
			FileType = file_type;
			CreatedAt = created_at;
			Colors = colors;
			Path = path;
			Thumbs = thumbs;
		}
	}
}

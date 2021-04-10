using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Wallhaven
{
	public class Image
	{
		public string Id { get; set; }
		public string Url { get; set; }
		public string ShortUrl { get; set; }
		public int Views { get; set; }
		public int Favorites { get; set; }
		public string Source { get; set; }
		public string Purity { get; set; }
		public string Category { get; set; }
		public Dimension Resolution { get; set; }
		public string Ratio { get; set; }
		public int FileSize { get; set; }
		public string FileType { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
		public string[] Colors { get; set; }
		public string Path { get; set; }
		public Thumbs Thumbs { get; set; }
	}

	internal class ImageJson
	{
		public static List<Image> DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static Image Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new Image {
				Id = jObj["id"].ToObject<string>(),
				Url = jObj["url"].ToObject<string>(),
				ShortUrl = jObj["short_url"].ToObject<string>(),
				Views = jObj["views"].ToObject<int>(),
				Favorites = jObj["favorites"].ToObject<int>(),
				Source = jObj["source"].ToObject<string>(),
				Purity = jObj["purity"].ToObject<string>(),
				Category = jObj["category"].ToObject<string>(),
				Resolution = new Dimension(
					jObj["dimension_x"].ToObject<int>(),
					jObj["dimension_y"].ToObject<int>()),
				Ratio = jObj["ratio"].ToObject<string>(),
				FileSize = jObj["file_size"].ToObject<int>(),
				FileType = jObj["file_type"].ToObject<string>(),
				CreatedAt = jObj["created_at"].ToObject<DateTime>(),
				Colors = JArray.FromObject(jObj["colors"]).ToObject<string[]>(),
				Path = jObj["path"].ToObject<string>(),
				Thumbs = jObj["thumbs"].ToObject<Thumbs>(),
			};
		}

		public static string Serialize(Image image)
		{
			JObject jObj = new JObject {
				{ "id", image.Id },
				{ "url", image.Url },
				{ "short_url", image.ShortUrl },
				{ "views", image.Views },
				{ "favorites", image.Favorites },
				{ "source", image.Source },
				{ "purity", image.Purity },
				{ "category", image.Category },
				{ "dimension_x", image.Resolution.Width },
				{ "dimension_y", image.Resolution.Height },
				{ "resolution", $"{image.Resolution.Width}x{image.Resolution.Height}" },
				{ "ratio", image.Ratio },
				{ "file_size", image.FileSize },
				{ "file_type", image.FileType },
				{ "created_at", image.CreatedAt },
				{ "colors", JArray.FromObject(image.Colors) },
				{ "path", image.Path },
				{ "thumbs", ThumbsJson.Serialize(image.Thumbs) }
			};
			return jObj.ToString();
		}
	}
}

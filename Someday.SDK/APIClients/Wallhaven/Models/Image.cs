using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Wallhaven
{
	public record Image
	{
		public string Id { get; init; } = string.Empty;
		public string Url { get; init; } = string.Empty;
		public string ShortUrl { get; init; } = string.Empty;
		public int Views { get; init; } = 0;
		public int Favorites { get; init; } = 0;
		public string Source { get; init; } = string.Empty;
		public string Purity { get; init; } = string.Empty;
		public string Category { get; init; } = string.Empty;
		public Dimension Resolution { get; init; } = new(0, 0);
		public string Ratio { get; init; } = string.Empty;
		public int FileSize { get; init; } = 0;
		public string FileType { get; init; } = string.Empty;
		public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.MinValue;
		public string[] Colors { get; init; } = Array.Empty<string>();
		public string Path { get; init; } = string.Empty;
		public Thumbs Thumbs { get; init; } = new();
	}

	internal class ImageJson
	{
		public static List<Image> DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static Image Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new Image {
				Id = jObj["id"]!.ToObject<string>()!,
				Url = jObj["url"]!.ToObject<string>()!,
				ShortUrl = jObj["short_url"]!.ToObject<string>()!,
				Views = jObj["views"]!.ToObject<int>(),
				Favorites = jObj["favorites"]!.ToObject<int>(),
				Source = jObj["source"]!.ToObject<string>()!,
				Purity = jObj["purity"]!.ToObject<string>()!,
				Category = jObj["category"]!.ToObject<string>()!,
				Resolution = new Dimension(
					jObj["dimension_x"]!.ToObject<int>(),
					jObj["dimension_y"]!.ToObject<int>()),
				Ratio = jObj["ratio"]!.ToObject<string>()!,
				FileSize = jObj["file_size"]!.ToObject<int>()!,
				FileType = jObj["file_type"]!.ToObject<string>()!,
				CreatedAt = jObj["created_at"]!.ToObject<DateTime>(),
				Colors = JArray.FromObject(jObj["colors"]!).ToObject<string[]>()!,
				Path = jObj["path"]!.ToObject<string>()!,
				Thumbs = ThumbsJson.Deserialize(jObj["thumbs"]!.ToObject<string>()!),
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

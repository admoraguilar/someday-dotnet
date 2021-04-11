using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Unsplash
{
	public record Photo
	{
		public string Id { get; init; } = string.Empty;
		public DateTime CreatedAt { get; init; } = DateTime.MinValue;
		public int Width { get; init; } = 0;
		public int Height { get; init; } = 0;
		public string Color { get; init; } = string.Empty;
		public string BlurHash { get; init; } = string.Empty;
		public int Likes { get; init; } = 0;
		public bool LikedByUser { get; init; } = false;
		public string Description { get; init; } = string.Empty;
		public string[] CurrentUserCollections { get; init; } = Array.Empty<string>();
		public PhotoUrls Urls { get; init; } = new();
		public PhotoLinks Links { get; init; } = new();
	}

	internal class PhotoJson
	{
		public static Photo[] DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static Photo Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new Photo {
				Id = jObj["id"]!.ToObject<string>()!,
				CreatedAt = jObj["created_at"]!.ToObject<DateTime>(),
				Width = jObj["width"]!.ToObject<int>(),
				Height = jObj["height"]!.ToObject<int>(),
				Color = jObj["color"]!.ToObject<string>()!,
				BlurHash = jObj["blur_hash"]!.ToObject<string>()!,
				Likes = jObj["likes"]!.ToObject<int>(),
				LikedByUser = jObj["liked_by_user"]!.ToObject<bool>(),
				Description = jObj["description"]!.ToObject<string>()!,
				CurrentUserCollections = JArray.FromObject(jObj["current_user_collections"]!).ToObject<string[]>()!,
				Urls = PhotoUrlsJson.Deserialize(jObj["urls"]!.ToString()),
				Links = PhotoLinksJson.Deserialize(jObj["links"]!.ToString()),
			};
		}
	}
}

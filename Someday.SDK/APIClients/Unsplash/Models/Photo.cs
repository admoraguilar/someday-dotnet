using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Unsplash
{
	public class Photo
	{
		public string Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public string Color { get; set; }
		public string BlurHash { get; set; }
		public int Likes { get; set; }
		public bool LikedByUser { get; set; }
		public string Description { get; set; }
		public string[] CurrentUserCollections { get; set; }
		public PhotoUrls Urls { get; set; }
		public PhotoLinks Links { get; set; }
	}

	internal class PhotoJson
	{
		public static List<Photo> DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static Photo Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new Photo {
				Id = jObj["id"].ToObject<string>(),
				CreatedAt = jObj["created_at"].ToObject<DateTime>(),
				Width = jObj["width"].ToObject<int>(),
				Height = jObj["height"].ToObject<int>(),
				Color = jObj["color"].ToObject<string>(),
				BlurHash = jObj["blur_hash"].ToObject<string>(),
				Likes = jObj["likes"].ToObject<int>(),
				LikedByUser = jObj["liked_by_user"].ToObject<bool>(),
				Description = jObj["description"].ToObject<string>(),
				CurrentUserCollections = JArray.FromObject(jObj["current_user_collections"]).ToObject<string[]>(),
				Urls = PhotoUrlsJson.Deserialize(jObj["urls"].ToString()),
				Links = PhotoLinksJson.Deserialize(jObj["links"].ToString()),
			};
		}
	}
}

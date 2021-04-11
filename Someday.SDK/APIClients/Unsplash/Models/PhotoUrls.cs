using Newtonsoft.Json.Linq;

namespace Someday.SDK.APIClients.Unsplash
{
	public record PhotoUrls
	{
		public string Raw { get; init; } = string.Empty;
		public string Full { get; init; } = string.Empty;
		public string Regular { get; init; } = string.Empty;
		public string Small { get; init; } = string.Empty;
		public string Thumb { get; init; } = string.Empty;
	}

	internal class PhotoUrlsJson
	{
		public static PhotoUrls Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new PhotoUrls {
				Raw = jObj["raw"]!.ToObject<string>()!,
				Full = jObj["full"]!.ToObject<string>()!,
				Regular = jObj["regular"]!.ToObject<string>()!,
				Small = jObj["small"]!.ToObject<string>()!,
				Thumb = jObj["thumb"]!.ToObject<string>()!,
			};
		}
	}
}

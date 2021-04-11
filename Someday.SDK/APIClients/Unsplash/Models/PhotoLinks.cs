using Newtonsoft.Json.Linq;

namespace Someday.SDK.APIClients.Unsplash
{
	public record PhotoLinks
	{
		public string Self { get; init; } = string.Empty;
		public string Html { get; init; } = string.Empty;
		public string Download { get; init; } = string.Empty;
	}

	internal class PhotoLinksJson
	{
		public static PhotoLinks Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new PhotoLinks {
				Self = jObj["self"]!.ToObject<string>()!,
				Html = jObj["html"]!.ToObject<string>()!,
				Download = jObj["download"]!.ToObject<string>()!
			};
		}
	}
}

using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Wallhaven
{
	public record Thumbs
	{
		public string Large { get; init; } = string.Empty;
		public string Original { get; init; } = string.Empty;
		public string Small { get; init; } = string.Empty;
	}

	internal class ThumbsJson
	{
		public static Thumbs[] DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static Thumbs Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new Thumbs {
				Large = jObj["large"]!.ToObject<string>()!,
				Original = jObj["original"]!.ToObject<string>()!,
				Small = jObj["small"]!.ToObject<string>()!
			};
		}

		public static string Serialize(Thumbs thumbs)
		{
			JObject jObj = new JObject {
				{ "large", thumbs.Large },
				{ "original", thumbs.Original },
				{ "small", thumbs.Small }
			};
			return jObj.ToString();
		}
	}
}

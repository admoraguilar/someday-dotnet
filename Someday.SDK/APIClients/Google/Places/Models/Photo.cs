using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Google.Places
{
	public record Photo
	{
		public int Width { get; init; } = 0;
		public int Height { get; init; } = 0;
		public string PhotoReference { get; init; } = string.Empty;
		public string[] HtmlAttributions { get; init; } = Array.Empty<string>();
	}

	internal class PhotoJson
	{
		public static List<Photo> DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static Photo Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new Photo {
				Width = jObj["width"]!.ToObject<int>(),
				Height = jObj["height"]!.ToObject<int>(),
				PhotoReference = jObj["photo_reference"]!.ToObject<string>()!,
				HtmlAttributions = JArray.FromObject(jObj["html_attributions"]!)!.ToObject<string[]>()!
			};
		}
	}
}

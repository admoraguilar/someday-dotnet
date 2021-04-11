using System;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public record OpenHours
	{
		public Category[] Categories { get; init; } = Array.Empty<Category>();
		public string[] Text { get; init; } = Array.Empty<string>();
		public bool IsOpen { get; init; } = false;
		public OpenHoursStructured[] Structured { get; init; } = Array.Empty<OpenHoursStructured>();
	}

	public class OpenHoursJson
	{
		public static OpenHours[] DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static OpenHours Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new OpenHours {
				Categories = CategoryJson.DeserializeArray(jObj["categories"]!.ToString()),
				Text = JArray.FromObject(jObj["text"]!).ToObject<string[]>()!,
				IsOpen = jObj["isOpen"]!.ToObject<bool>()!,
				Structured = OpenHoursStructuredJson.DeserializeArray(jObj["structured"]!.ToString())
			};
		}
	}
}

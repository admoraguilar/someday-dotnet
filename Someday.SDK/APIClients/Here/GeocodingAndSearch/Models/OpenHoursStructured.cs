using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public record OpenHoursStructured
	{
		public string Start { get; init; } = string.Empty;
		public string Duration { get; init; } = string.Empty;
		public string Recurrence { get; init; } = string.Empty;
	}

	public class OpenHoursStructuredJson
	{
		public static OpenHoursStructured[] DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static OpenHoursStructured Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new OpenHoursStructured {
				Start = jObj["start"]!.ToObject<string>()!,
				Duration = jObj["duration"]!.ToObject<string>()!,
				Recurrence = jObj["recurrence"]!.ToObject<string>()!
			};
		}
	}
}

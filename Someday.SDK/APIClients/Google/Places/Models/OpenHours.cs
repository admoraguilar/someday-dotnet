using System;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Google.Places
{
	public record OpenHours
	{
		public bool OpenNow { get; init; } = false;
		public string[] WeekdayText { get; init; } = Array.Empty<string>();
	}

	internal class OpenHoursInfoJson
	{
		public static OpenHours[] DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static OpenHours Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new OpenHours {
				OpenNow = jObj["open_now"]!.ToObject<bool>(),
				WeekdayText = JArray.FromObject(jObj["weekday_text"]!)!.ToObject<string[]>()!
			};
		}
	}
}

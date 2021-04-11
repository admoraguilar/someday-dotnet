using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Google.Places
{
	public record OpenHoursInfo
	{
		public bool OpenNow { get; init; } = false;
		public string[] WeekdayText { get; init; } = Array.Empty<string>();
	}

	internal class OpenHoursInfoJson
	{
		public static List<OpenHoursInfo> DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static OpenHoursInfo Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new OpenHoursInfo {
				OpenNow = jObj["open_now"]!.ToObject<bool>(),
				WeekdayText = JArray.FromObject(jObj["weekday_text"]!)!.ToObject<string[]>()!
			};
		}
	}
}

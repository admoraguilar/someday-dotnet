using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public record ContactInfo
	{
		public string Value { get; init; } = string.Empty;
		public Category[]? Categories { get; init; }
	}

	public class ContactInfoJson
	{
		public static ContactInfo[] DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static ContactInfo Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new ContactInfo {
				Value = jObj["value"]!.ToObject<string>()!,
				Categories = CategoryJson.DeserializeArray(jObj["categories"]!.ToString()),
			};
		}
	}
}

using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public record Contact
	{
		public ContactInfo[]? Phone { get; init; }
		public ContactInfo[]? WWW { get; init; }
		public ContactInfo[]? Email { get; init; }
	}

	public class ContactJson
	{
		public static Contact[] DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static Contact Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new Contact {
				Phone = jObj.ContainsKey("phone") ? ContactInfoJson.DeserializeArray(jObj["phone"]!.ToString()) : null,
				WWW = jObj.ContainsKey("www") ? ContactInfoJson.DeserializeArray(jObj["www"]!.ToString()) : null,
				Email = jObj.ContainsKey("email") ? ContactInfoJson.DeserializeArray(jObj["email"]!.ToString()) : null
			};
		}
	}
}

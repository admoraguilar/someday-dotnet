using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public record Category
	{
		public string Id { get; init; } = string.Empty;
		public string? Name { get; init; } = string.Empty;
		public bool? Primary { get; init; } = false;
	}

	public class CategoryJson
	{
		public static Category[] DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static Category Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new Category {
				Id = jObj["id"]!.ToObject<string>()!,
				Name = jObj["name"]?.ToObject<string>()!,
				Primary = jObj["primary"]?.ToObject<bool>(),
			};
		}
	}
}

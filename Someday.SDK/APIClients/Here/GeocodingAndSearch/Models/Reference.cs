using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public record Reference
	{
		public ReferenceSupplier Supplier { get; init; } = new();
		public string Id { get; init; } = string.Empty;
	}

	public class ReferenceJson
	{
		public static Reference[] DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static Reference Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new Reference {
				Supplier = ReferenceSupplierJson.Deserialize(jObj["supplier"]!.ToString()),
				Id = jObj["id"]!.ToObject<string>()!
			};
		}
	}
}

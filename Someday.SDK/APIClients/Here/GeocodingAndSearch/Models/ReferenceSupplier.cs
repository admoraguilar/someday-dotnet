using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public record ReferenceSupplier
	{
		public string Id { get; init; } = string.Empty;
	}

	public class ReferenceSupplierJson
	{
		public static ReferenceSupplier[] DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static ReferenceSupplier Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new ReferenceSupplier {
				Id = jObj["id"]!.ToObject<string>()!
			};
		}
	}
}

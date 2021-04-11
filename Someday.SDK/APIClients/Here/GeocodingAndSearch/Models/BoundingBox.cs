using Newtonsoft.Json.Linq;

namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public record BoundingBox
	{
		public decimal West { get; init; } = 0;
		public decimal South { get; init; } = 0;
		public decimal East { get; init; } = 0;
		public decimal North { get; init; } = 0;
	}

	public class BoundingBoxJson
	{
		public static BoundingBox Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new BoundingBox {
				West = jObj["west"]!.ToObject<decimal>(),
				South = jObj["south"]!.ToObject<decimal>(),
				East = jObj["east"]!.ToObject<decimal>(),
				North = jObj["north"]!.ToObject<decimal>(),
			};
		}
	}
}

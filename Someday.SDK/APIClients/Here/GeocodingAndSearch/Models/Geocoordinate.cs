using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public record Geocoordinate
	{
		public decimal Latitude { get; init; } = 0;
		public decimal Longtitude { get; init; } = 0;

		public override string ToString() => $"{Latitude},{Longtitude}";
	}

	public class GeocoordinateJson
	{
		public static Geocoordinate[] DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static Geocoordinate Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new Geocoordinate {
				Latitude = jObj["lat"]!.ToObject<decimal>(),
				Longtitude = jObj["lng"]!.ToObject<decimal>()
			};
		}
	}
}

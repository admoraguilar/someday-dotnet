using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Google.Places
{
	public record Geoviewport
	{
		public Geocoordinate NorthEast { get; init; } = new();
		public Geocoordinate SouthWest { get; init; } = new();
	}

	internal class GeoviewportJson
	{
		public static Geoviewport[] DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static Geoviewport Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new Geoviewport {
				NorthEast = GeocoordinateJson.Deserialize(jObj["northeast"]!.ToString()),
				SouthWest = GeocoordinateJson.Deserialize(jObj["southwest"]!.ToString())
			};
		}
	}
}

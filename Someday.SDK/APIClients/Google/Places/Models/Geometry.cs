using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Google.Places
{
	public record Geometry
	{
		public Geocoordinate Location { get; init; } = new();
		public Geoviewport Viewport { get; init; } = new();
	}

	internal class GeometryJson
	{
		public static Geometry[] DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static Geometry Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new Geometry {
				Location = GeocoordinateJson.Deserialize(jObj["location"]!.ToString()),
				Viewport = GeoviewportJson.Deserialize(jObj["viewport"]!.ToString()),
			};
		}
	}
}

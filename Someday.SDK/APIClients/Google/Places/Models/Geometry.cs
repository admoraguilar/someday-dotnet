using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Google.Places
{
	public record Geometry
	{
		public GeoCoordinate Location { get; init; } = new();
		public GeoViewport Viewport { get; init; } = new();
	}

	internal class GeometryJson
	{
		public static List<Geometry> DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static Geometry Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new Geometry {
				Location = GeoCoordinateJson.Deserialize(jObj["location"]!.ToObject<string>()!),
				Viewport = GeoViewportJson.Deserialize(jObj["viewport"]!.ToObject<string>()!),
			};
		}
	}
}

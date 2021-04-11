using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Google.Places
{
	public record GeoViewport
	{
		public GeoCoordinate NorthEast { get; init; } = new();
		public GeoCoordinate SouthWest { get; init; } = new();
	}

	internal class GeoViewportJson
	{
		public static List<GeoViewport> DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static GeoViewport Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new GeoViewport {
				NorthEast = GeoCoordinateJson.Deserialize(jObj["northeast"]!.ToObject<string>()!),
				SouthWest = GeoCoordinateJson.Deserialize(jObj["southwest"]!.ToObject<string>()!)
			};
		}
	}
}

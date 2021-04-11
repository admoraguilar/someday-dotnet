using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Google.Places
{
	public record GeoCoordinate
	{
		public double Latitude { get; init; } = 0;
		public double Longtitude { get; init; } = 0;
	}

	internal class GeoCoordinateJson
	{
		public static List<GeoCoordinate> DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static GeoCoordinate Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new GeoCoordinate {
				Latitude = jObj["lat"]!.ToObject<double>(),
				Longtitude = jObj["lng"]!.ToObject<double>()
			};
		}
	}
}

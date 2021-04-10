using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Google.Places
{
	public class GeographicCoordinate
	{
		public double Latitude { get; set; }
		public double Longtitude { get; set; }
	}

	internal class GeographicCoordinateJson
	{
		public static List<GeographicCoordinate> DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static GeographicCoordinate Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new GeographicCoordinate {
				Latitude = jObj["lat"].ToObject<double>(),
				Longtitude = jObj["lng"].ToObject<double>()
			};
		}
	}
}

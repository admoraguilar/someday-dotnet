using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Google.Places
{
	public class GeographicViewport
	{
		public GeographicCoordinate NorthEast { get; set; }
		public GeographicCoordinate SouthWest { get; set; }
	}

	internal class GeographicViewportJson
	{
		public static List<GeographicViewport> DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static GeographicViewport Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new GeographicViewport {
				NorthEast = GeographicCoordinateJson.Deserialize(jObj["northeast"].ToString()),
				SouthWest = GeographicCoordinateJson.Deserialize(jObj["southwest"].ToString())
			};
		}
	}
}

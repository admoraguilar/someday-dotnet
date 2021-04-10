using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Google.Places
{
	public class Geometry
	{
		public GeographicCoordinate Location { get; set; }
		public GeographicViewport Viewport { get; set; }
	}

	internal class GeometryJson
	{
		public static List<Geometry> DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static Geometry Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new Geometry {
				Location = GeographicCoordinateJson.Deserialize(jObj["location"].ToString()),
				Viewport = GeographicViewportJson.Deserialize(jObj["viewport"].ToString()),
			};
		}
	}
}

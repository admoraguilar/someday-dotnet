using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Google.Places
{
	public class Place
	{
		public string Name { get; set; }
		public string FormattedAddress { get; set; }
		public float Rating { get; set; }
		public OpenHoursInfo OpeningHours { get; set; }
		public List<Photo> Photos { get; set; }
		public Geometry Geometry { get; set; }
	}

	internal class PlaceJson
	{
		public static List<Place> DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static Place Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			Place place = new Place {
				Name = jObj["name"].ToObject<string>(),
				FormattedAddress = jObj["formatted_address"].ToObject<string>(),
				Rating = jObj["rating"].ToObject<float>(),
				OpeningHours = OpenHoursInfoJson.Deserialize(jObj["opening_hours"].ToString()),
				Photos = PhotoJson.DeserializeArray(jObj["photos"].ToString()),
				Geometry = GeometryJson.Deserialize(jObj["geometry"].ToString())
			};
			return place;
		}
	}
}

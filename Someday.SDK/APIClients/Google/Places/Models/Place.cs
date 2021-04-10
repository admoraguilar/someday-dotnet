using System.Collections.Generic;

namespace Someday.SDK.APIClients.Google.Places
{
	public class Place
	{
		public string Name { get; set; }
		public string FormattedAddress { get; set; }
		public float Rating { get; set; }
		public OpenHoursInfo OpeningHours { get; set; }
		public Photo[] Photos { get; set; }
		public Geometry Geometry { get; set; }
	}

	internal class PlaceJson
	{
		public static Place Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			Place place = new Place {
				Name = jObj["name"].ToObject<string>(),
				FormattedAddress = jObj["formatted_address"].ToObject<string>(),
				Rating = jObj["rating"].ToObject<float>(),

			};
			return place;
		}
	}
}

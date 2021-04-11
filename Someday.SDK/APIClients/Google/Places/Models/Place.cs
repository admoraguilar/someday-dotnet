using System;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Google.Places
{
	public record Place
	{
		public string Name { get; init; } = string.Empty;
		public string FormattedAddress { get; init; } = string.Empty;
		public float Rating { get; init; } = 0f;
		public OpenHours OpeningHours { get; init; } = new();
		public Photo[] Photos { get; init; } = Array.Empty<Photo>();
		public Geometry Geometry { get; init; } = new();
	}

	internal class PlaceJson
	{
		public static Place[] DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static Place Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			Place place = new Place {
				Name = jObj["name"]!.ToObject<string>()!,
				FormattedAddress = jObj["formatted_address"]!.ToObject<string>()!,
				Rating = jObj["rating"]!.ToObject<float>(),
				OpeningHours = OpenHoursInfoJson.Deserialize(jObj["opening_hours"]!.ToString()),
				Photos = PhotoJson.DeserializeArray(jObj["photos"]!.ToString()),
				Geometry = GeometryJson.Deserialize(jObj["geometry"]!.ToString())
			};
			return place;
		}
	}
}

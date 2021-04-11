using Newtonsoft.Json.Linq;

namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public record Place : GeocodeAndSearchResult
	{
		public AddressInfo AddressInfo { get; init; } = new();
		public Geocoordinate Position { get; init; } = new();
		public Geocoordinate[]? Access { get; init; }
		public Category[]? Categories { get; init; }
		public Category[]? FoodTypes { get; init; }
		public Contact[]? Contacts { get; init; }
		public OpenHours[]? OpeningHours { get; init; }
		public Reference[]? References { get; init; }
	}

	public class PlaceJson
	{
		public static Place Deserialize(string json)
		{
			GeocodeAndSearchResult baseResult = GeocodeAndSearchResultJson.DeserializeDirect(json);

			JObject jObj = JObject.Parse(json);
			return new Place {
				Title = baseResult.Title,
				Id = baseResult.Id,
				ResultType = baseResult.ResultType,
				AddressInfo = AddressInfoJson.Deserialize(jObj["address"]!.ToString()),
				Position = GeocoordinateJson.Deserialize(jObj["position"]!.ToString()),
				Access = jObj.ContainsKey("access") ? GeocoordinateJson.DeserializeArray(jObj["access"]!.ToString()) : null,
				Categories = jObj.ContainsKey("categories") ? CategoryJson.DeserializeArray(jObj["categories"]!.ToString()) : null,
				FoodTypes = jObj.ContainsKey("foodTypes") ? CategoryJson.DeserializeArray(jObj["foodTypes"]!.ToString()) : null,
				Contacts = jObj.ContainsKey("contacts") ? ContactJson.DeserializeArray(jObj["contacts"]!.ToString()) : null,
				OpeningHours = jObj.ContainsKey("openingHours") ? OpenHoursJson.DeserializeArray(jObj["openingHours"]!.ToString()) : null,
				References = jObj.ContainsKey("references") ? ReferenceJson.DeserializeArray(jObj["references"]!.ToString()) : null,
			};
		}
	}
}

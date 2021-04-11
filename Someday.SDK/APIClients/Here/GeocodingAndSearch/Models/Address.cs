using Newtonsoft.Json.Linq;

namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public record Address : GeocodeAndSearchResult
	{
		public string? LocalityType { get; init; }
		public string? AdministrativeAreaType { get; init; }
		public string? AddressBlockType { get; init; }
		public string? HouseNumberType { get; init; }

		public AddressInfo AddressInfo { get; init; } = new();
		public Geocoordinate Position { get; init; } = new();
		public BoundingBox MapView { get; init; } = new();

		public Geocoordinate[]? Access { get; init; }
	}

	public class AddressJson
	{
		public static Address Deserialize(string json)
		{
			GeocodeAndSearchResult baseResult = GeocodeAndSearchResultJson.DeserializeDirect(json);

			JObject jObj = JObject.Parse(json);
			return new Address {
				Title = baseResult.Title,
				Id = baseResult.Id,
				ResultType = baseResult.ResultType,
				LocalityType = jObj["localityType"]!.ToObject<string>(),
				AdministrativeAreaType = jObj["administrativeAreaType"]!.ToObject<string>(),
				AddressBlockType = jObj["addressBlockType"]!.ToObject<string>(),
				HouseNumberType = jObj["houseNumberType"]!.ToObject<string>(),
				AddressInfo = AddressInfoJson.Deserialize(jObj["address"]!.ToString()),
				Position = GeocoordinateJson.Deserialize(jObj["position"]!.ToString()),
				MapView = BoundingBoxJson.Deserialize(jObj["mapView"]!.ToString()),
				Access = GeocoordinateJson.DeserializeArray(jObj["access"]!.ToString()),
			};
		}
	}
}

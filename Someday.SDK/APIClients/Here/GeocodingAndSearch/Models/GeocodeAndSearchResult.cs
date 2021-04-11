using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public record GeocodeAndSearchResult
	{
		public string Title { get; init; } = string.Empty;
		public string Id { get; init; } = string.Empty;
		public string ResultType { get; init; } = string.Empty;
	}

	internal class GeocodeAndSearchResultJson
	{
		public static GeocodeAndSearchResult[] DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static GeocodeAndSearchResult Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);

			string resultType = jObj["resultType"]!.ToObject<string>()!;
			return resultType switch {
				"place" => PlaceJson.Deserialize(jObj.ToString()),
				"locality" or "street" or
				"houseNumber" or "administrativeArea" or "addressBlock" or
				"intersection" or "postalCodePoint" => AddressJson.Deserialize(jObj.ToString()),
				_ => DeserializeDirect(json),
			};
		}

		public static GeocodeAndSearchResult DeserializeDirect(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new GeocodeAndSearchResult {
				Title = jObj["title"]!.ToObject<string>()!,
				Id = jObj["id"]!.ToObject<string>()!,
				ResultType = jObj["resultType"]!.ToObject<string>()!
			};
		}
	}
}

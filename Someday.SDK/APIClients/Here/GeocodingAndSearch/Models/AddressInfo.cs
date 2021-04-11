using Newtonsoft.Json.Linq;

namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public record AddressInfo
	{
		public string Label { get; init; } = string.Empty;
		public string? CountryCode { get; init; }
		public string? CountryName { get; init; }
		public string? StateCode { get; init; }
		public string? State { get; init; }
		public string? CountyCode { get; init; }
		public string? County { get; init; }
		public string? City { get; init; }
		public string? PostalCode { get; init; }
		public string? District { get; init; }
		public string? Subdistrict { get; init; }
		public string? Block { get; init; }
		public string? Subblock { get; init; }
		public string? Street { get; init; }
		public string? HouseNumber { get; init; }
	}

	public class AddressInfoJson
	{
		public static AddressInfo Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new AddressInfo {
				Label = jObj["label"]!.ToObject<string>()!,
				CountryCode = jObj["countryCode"]!.ToObject<string>()!,
				CountryName = jObj["countryName"]!.ToObject<string>()!,
				StateCode = jObj["stateCode"]!.ToObject<string>()!,
				State = jObj["state"]!.ToObject<string>()!,
				CountyCode = jObj["countyCode"]!.ToObject<string>()!,
				County = jObj["county"]!.ToObject<string>()!,
				City = jObj["city"]!.ToObject<string>()!,
				PostalCode = jObj["postalCode"]!.ToObject<string>()!,
				District = jObj["district"]!.ToObject<string>()!,
				Subdistrict = jObj["subdistrict"]!.ToObject<string>()!,
				Block = jObj["block"]!.ToObject<string>()!,
				Subblock = jObj["subblock"]!.ToObject<string>()!,
				Street = jObj["street"]!.ToObject<string>()!,
				HouseNumber = jObj["houseNumber"]!.ToObject<string>()!,
			};
		}
	}
}

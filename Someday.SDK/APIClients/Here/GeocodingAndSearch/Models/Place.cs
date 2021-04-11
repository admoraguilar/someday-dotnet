
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
}

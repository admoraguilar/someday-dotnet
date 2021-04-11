
namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public class AddressResult : GeocodingAndSearchResult
	{
		public Geocoordinate Position { get; set; }
		public Geocoordinate MapView { get; set; }
	}
}

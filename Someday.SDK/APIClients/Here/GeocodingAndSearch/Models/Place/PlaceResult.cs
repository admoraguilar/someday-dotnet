
namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public class PlaceResult
	{
		public string Title { get; set; }
		public string Id { get; set; }
		public string ResultType { get; set; }
		public Geocoordinate Position { get; set; }
		public Geocoordinate MapView { get; set; }
	}
}

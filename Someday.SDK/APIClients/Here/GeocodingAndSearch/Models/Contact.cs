
namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public record Contact
	{
		public ContactInfo[]? Phone { get; init; }
		public ContactInfo[]? WWW { get; init; }
		public ContactInfo[]? Email { get; init; }
	}
}

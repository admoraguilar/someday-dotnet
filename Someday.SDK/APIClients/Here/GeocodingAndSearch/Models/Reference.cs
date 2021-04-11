
namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public record Reference
	{
		public ReferenceSupplier Supplier { get; init; } = new();
		public string Id { get; init; } = string.Empty;
	}
}

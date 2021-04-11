
namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public class CountryAddress : AddressInfo
	{
		public string CountryCode { get; set; }
		public string CountryName { get; set; }
	}

	public class StateAddress : CountryAddress
	{
		public string StateCode { get; set; }
		public string State { get; set; }
	}

	public class CountyAddress : StateAddress
	{
		public string County { get; set; }
	}

	public class CityAddress : CountryAddress
	{
		public string City { get; set; }
		public string PostalCode { get; set; }
	}

	public class PostalCodeAddress : CityAddress
	{
		public string CountyCode { get; set; }
	}

	public class DistrictAddress : CityAddress
	{
		public string District { get; set; }
	}
}

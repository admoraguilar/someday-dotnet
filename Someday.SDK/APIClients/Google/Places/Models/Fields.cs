namespace Someday.SDK.APIClients.Google.Places
{
	/// <summary>
	/// Place Data Fields: https://developers.google.com/maps/documentation/places/web-service/place-data-fields
	/// </summary>
	public class Fields
	{
		public class Basic
		{
			public const string AddressComponent = "address_component";
			public const string Address = "adr_address";
			public const string BusinessStatus = "business_status";
			public const string FormattedAddress = "formatted_address";
			public const string Geometry = "geometry";
			public const string Icon = "icon";
			public const string Name = "name";
			public const string Photos = "photos";
			public const string PlaceId = "place_id";
			public const string PlusCode = "plus_code";
			public const string Types = "types";
			public const string Url = "url";
			public const string UtcOffset = "utc_offset";
			public const string Vicinity = "vicinity";
		}

		public class Contact
		{
			public const string PhoneNumber = "formatted_phone_number";
			public const string InternationalPhoneNumber = "international_phone_number";
			public const string OpeningHours = "opening_hours";
			public const string Website = "website";
		}

		public class Atmosphere
		{
			public const string PriceLevel = "price_level";
			public const string Rating = "rating";
			public const string Reviews = "reviews";
			public const string UserRatingsTotal = "user_ratings_total";
		}
	}
}

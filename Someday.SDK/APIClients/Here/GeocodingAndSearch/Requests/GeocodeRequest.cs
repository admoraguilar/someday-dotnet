using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Common;

namespace Someday.SDK.APIClients.Here.GeocodingAndSearch
{
	public class QualifiedQueryBuilder
	{
		private QueryBuilder queryBuilder { get; } = new(";");

		public QualifiedQueryBuilder SetCountry(string value) =>
			DoAction(() => queryBuilder.SetField("country", value));

		public QualifiedQueryBuilder SetState(string value) =>
			DoAction(() => queryBuilder.SetField("state", value));

		public QualifiedQueryBuilder SetCounty(string value) =>
			DoAction(() => queryBuilder.SetField("county", value));

		public QualifiedQueryBuilder SetCity(string value) =>
			DoAction(() => queryBuilder.SetField("city", value));

		public QualifiedQueryBuilder SetDistrict(string value) =>
			DoAction(() => queryBuilder.SetField("district", value));

		public QualifiedQueryBuilder SetStreet(string value) =>
			DoAction(() => queryBuilder.SetField("street", value));

		public QualifiedQueryBuilder SetHouseNumber(int value) =>
			DoAction(() => queryBuilder.SetField("houseNumber", value));

		public QualifiedQueryBuilder SetPostalCode(int value) =>
			DoAction(() => queryBuilder.SetField("postalCode", value));

		public string Build() => queryBuilder.Build();

		public override string ToString() => Build();

		private QualifiedQueryBuilder DoAction(Action action)
		{
			action();
			return this;
		}	
	}

	public class GeocodeRequest : HttpRequest<GeocodeRequest>
	{
		protected override string EndPoint => "https://geocode.search.hereapi.com/v1/geocode";

		public GeocodeRequest SetApiKey(string value) =>
			SetQueryField("apiKey", value);

		public GeocodeRequest SetAt(Geocoordinate value) =>
			SetQueryField("at", value.ToString());

		public GeocodeRequest SetIn(params string[] countryCode) =>
			SetQueryField("in", $"countryCode:{string.Join(",", countryCode).ToUpper()}");

		public GeocodeRequest SetLimit(int value) =>
			SetQueryField("limit", Math.Clamp(value, 0, 100).ToString());

		public GeocodeRequest SetQ(string value) =>
			SetQueryField("q", value);

		public GeocodeRequest SetQQ(QualifiedQueryBuilder value) =>
			SetQueryField("qq", value);

		public GeocodeRequest SetLang(string value) =>
			SetQueryField("lang", value);

		public GeocodeRequest SetShow(params string[] value) =>
			SetQueryField("show", value);

		public async Task<GeocodeAndSearchResult[]> SendAsync()
		{
			string content = await GetAsync();
			string items = JObject.Parse(content)["items"]!.ToString();
			return GeocodeAndSearchResultJson.DeserializeArray(items);
		}
	}
}

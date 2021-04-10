using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Someday.SDK.APIClients.Common;


namespace Someday.SDK.APIClients.Google.Places
{
	public class FindPlaceRequest : HttpRequest<FindPlaceRequest>
	{
		protected override string endPoint => "https://maps.googleapis.com/maps/api/place/findplacefromtext/json";

		public FindPlaceRequest SetApiKey(string value) =>
			SetField("key", value);

		public FindPlaceRequest SetInput(string value) =>
			SetField("input", value);

		public FindPlaceRequest SetInputType(string value) =>
			SetField("inputtype", value);

		public FindPlaceRequest SetLanguage(string value) =>
			SetField("language", value);

		public FindPlaceRequest SetFields(params string[] values) =>
			SetField("fields", string.Join(",", values));

		public FindPlaceRequest SetLocationBias(string value) =>
			SetField("locationbias", value);

		public async Task<string> SendAsync()
		{
			string responseString = await GetAsync();
			return responseString;
		}
	}
}

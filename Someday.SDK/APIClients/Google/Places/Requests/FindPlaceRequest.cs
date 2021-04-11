using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Common;

namespace Someday.SDK.APIClients.Google.Places
{
	public class FindPlaceRequest : HttpRequest<FindPlaceRequest>
	{
		protected override string EndPoint => "https://maps.googleapis.com/maps/api/place/findplacefromtext/json";

		public FindPlaceRequest SetApiKey(string value) =>
			SetQueryField("key", value);

		public FindPlaceRequest SetInput(string value) =>
			SetQueryField("input", value);

		public FindPlaceRequest SetInputType(string value) =>
			SetQueryField("inputtype", value);

		public FindPlaceRequest SetLanguage(string value) =>
			SetQueryField("language", value);

		public FindPlaceRequest SetFields(params string[] values) =>
			SetQueryField("fields", string.Join(",", values));

		public FindPlaceRequest SetLocationBias(string value) =>
			SetQueryField("locationbias", value);

		public async Task<Place[]> SendAsync()
		{
			string content = await GetAsync();
			string candidates = JObject.Parse(content)["candidates"]!.ToString();
			return PlaceJson.DeserializeArray(candidates);
		}
	}
}

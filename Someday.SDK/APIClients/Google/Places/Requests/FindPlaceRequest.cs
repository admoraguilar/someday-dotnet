using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Common;

namespace Someday.SDK.APIClients.Google.Places
{
	public class FindPlaceRequest : HttpRequest<FindPlaceRequest>
	{
		protected override string EndPoint => "https://maps.googleapis.com/maps/api/place/findplacefromtext/json";

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

		public async Task<List<Place>> SendAsync()
		{
			string content = await GetAsync();
			string candidates = JObject.Parse(content)["candidates"]!.ToObject<string>()!;
			return PlaceJson.DeserializeArray(candidates);
		}
	}
}

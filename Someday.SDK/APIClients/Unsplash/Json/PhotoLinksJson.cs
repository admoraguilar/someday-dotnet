using Newtonsoft.Json.Linq;

namespace Someday.SDK.APIClients.Unsplash.Json
{
	internal class PhotoLinksJson
	{
		public static PhotoLinks Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			PhotoLinks photoLinks = new PhotoLinks {
				Self = jObj["self"].ToObject<string>(),
				Html = jObj["html"].ToObject<string>(),
				Download = jObj["download"].ToObject<string>()
			};
			return photoLinks;
		}
	}
}

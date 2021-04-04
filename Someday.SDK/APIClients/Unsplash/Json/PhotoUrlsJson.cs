using Newtonsoft.Json.Linq;

namespace Someday.SDK.APIClients.Unsplash.Json
{
	internal class PhotoUrlsJson
	{
		public static PhotoUrls Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			PhotoUrls photoUrls = new PhotoUrls {
				Raw = jObj["raw"].ToObject<string>(),
				Full = jObj["full"].ToObject<string>(),
				Regular = jObj["regular"].ToObject<string>(),
				Small = jObj["small"].ToObject<string>(),
				Thumb = jObj["thumb"].ToObject<string>(),
			};
			return photoUrls;
		} 
	}
}

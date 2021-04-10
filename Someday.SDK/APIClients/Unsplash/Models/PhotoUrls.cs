using Newtonsoft.Json.Linq;

namespace Someday.SDK.APIClients.Unsplash
{
	public class PhotoUrls
	{
		public string Raw { get; set; }
		public string Full { get; set; }
		public string Regular { get; set; }
		public string Small { get; set; }
		public string Thumb { get; set; }
	}

	internal class PhotoUrlsJson
	{
		public static PhotoUrls Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new PhotoUrls {
				Raw = jObj["raw"].ToObject<string>(),
				Full = jObj["full"].ToObject<string>(),
				Regular = jObj["regular"].ToObject<string>(),
				Small = jObj["small"].ToObject<string>(),
				Thumb = jObj["thumb"].ToObject<string>(),
			};
		}
	}
}

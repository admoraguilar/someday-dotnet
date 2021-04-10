using Newtonsoft.Json.Linq;

namespace Someday.SDK.APIClients.Unsplash
{
	public class PhotoLinks
	{
		public string Self { get; set; }
		public string Html { get; set; }
		public string Download { get; set; }
	}

	internal class PhotoLinksJson
	{
		public static PhotoLinks Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new PhotoLinks {
				Self = jObj["self"].ToObject<string>(),
				Html = jObj["html"].ToObject<string>(),
				Download = jObj["download"].ToObject<string>()
			};
		}
	}
}

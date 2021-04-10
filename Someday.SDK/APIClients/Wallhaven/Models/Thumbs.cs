using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Someday.SDK.APIClients.Json;

namespace Someday.SDK.APIClients.Wallhaven
{
	public class Thumbs
	{
		public string Large { get; set; }
		public string Original { get; set; }
		public string Small { get; set; }
	}

	internal class ThumbsJson
	{
		public static List<Thumbs> DeserializeArray(string json) =>
			JsonUtilities.DeserializeArray(json, Deserialize);

		public static Thumbs Deserialize(string json)
		{
			JObject jObj = JObject.Parse(json);
			return new Thumbs {
				Large = (string)jObj["large"],
				Original = (string)jObj["original"],
				Small = (string)jObj["small"]
			};
		}

		public static string Serialize(Thumbs thumbs)
		{
			JObject jObj = new JObject {
				{ "large", thumbs.Large },
				{ "original", thumbs.Original },
				{ "small", thumbs.Small }
			};
			return jObj.ToString();
		}
	}
}

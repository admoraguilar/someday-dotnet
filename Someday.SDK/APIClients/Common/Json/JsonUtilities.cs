using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Someday.SDK.APIClients.Json
{
	internal class JsonUtilities
	{
		public static List<T> DeserializeArray<T>(string json, Func<string, T> deserializer)
		{
			JArray jArr = JArray.Parse(json);
			List<T> objs = new List<T>();
			foreach(JObject jObj in jArr) {
				objs.Add(deserializer(jObj.ToString()));
			}
			return objs;
		}
	}
}

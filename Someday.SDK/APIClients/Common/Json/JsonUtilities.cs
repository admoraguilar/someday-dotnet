using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Someday.SDK.APIClients.Json
{
	internal class JsonUtilities
	{
		public static T[] DeserializeArray<T>(string json, Func<string, T> deserializer) =>
			DeserializeArray(json, (JObject jObj) => deserializer(jObj.ToString()));

		public static T[] DeserializeArray<T>(string json, Func<JObject, T> deserializer)
		{
			JArray jArr = JArray.Parse(json);
			List<T> objs = new List<T>();
			foreach(JObject jObj in jArr) { objs.Add(deserializer(jObj)); }
			return objs.ToArray();
		}
	}
}

using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Someday.SDK
{
	public class SomedayClientConfig : IReadOnlyDictionary<string, string>
	{
		private Dictionary<string, string> configs = new Dictionary<string, string>();

		public string this[string key] => 
			((IReadOnlyDictionary<string, string>)configs)[key];

		public IEnumerable<string> Keys => 
			((IReadOnlyDictionary<string, string>)configs).Keys;

		public IEnumerable<string> Values => 
			((IReadOnlyDictionary<string, string>)configs).Values;

		public int Count => 
			((IReadOnlyCollection<KeyValuePair<string, string>>)configs).Count;

		public bool ContainsKey(string key) =>
			((IReadOnlyDictionary<string, string>)configs).ContainsKey(key);

		public IEnumerator<KeyValuePair<string, string>> GetEnumerator() =>
			((IEnumerable<KeyValuePair<string, string>>)configs).GetEnumerator();

		public bool TryGetValue(string key, out string value) =>
			((IReadOnlyDictionary<string, string>)configs).TryGetValue(key, out value);

		public void LoadConfigFromProcessRelativePath(string relativePath)
		{
			string appPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
			string text = File.ReadAllText($"{appPath}/{relativePath}");
			configs = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
		}

		IEnumerator IEnumerable.GetEnumerator() =>
			((IEnumerable)configs).GetEnumerator();
	}
}

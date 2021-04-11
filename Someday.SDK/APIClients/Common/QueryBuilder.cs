using System;
using System.Linq;
using System.Collections.Generic;

namespace Someday.SDK.APIClients.Common
{
	public class QueryBuilder
	{
		public string Separator { get; init; } = "&";

		private Dictionary<string, object> queryDict = new();

		public QueryBuilder(string separator) => Separator = separator;

		public QueryBuilder SetField(string name, object value) =>
			DoAction(() => queryDict[name] = value);

		public QueryBuilder AddField(string name, object value) =>
			DoAction(() => queryDict.Add(name, value));

		public QueryBuilder RemoveField(string name) =>
			DoAction(() => queryDict.Remove(name));

		public string Build() => string.Join(Separator, queryDict.Select(kvp => $"{kvp.Key}={kvp.Value}"));
	
		private QueryBuilder DoAction(Action action)
		{
			action();
			return this;
		}
	}
}

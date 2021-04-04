
namespace Someday.SDK.APIClients.Wallhaven
{
	public class WallhavenClient
	{
		private string apiKey;

		public WallhavenClient(string apiKey)
		{
			this.apiKey = apiKey;
		}

		public SearchRequest Search() => new SearchRequest();
	}
}

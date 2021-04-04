
namespace Someday.SDK.APIClients.Unsplash
{
	public class UnsplashClient
	{
		private string apiKey;

		public UnsplashClient(string apiKey)
		{
			this.apiKey = apiKey;
		}

		public SearchPhotosRequest SearchPhotos() => new SearchPhotosRequest().SetClientId(apiKey);
	}
}

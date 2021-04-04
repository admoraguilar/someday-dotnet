using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnsplashAPI = Someday.SDK.APIClients.Unsplash;
using WallhavenAPI = Someday.SDK.APIClients.Wallhaven;

namespace Someday.SDK
{
	public class ImagesClient
	{
		private UnsplashAPI.UnsplashClient unsplash;
		private WallhavenAPI.WallhavenClient wallhaven;

		public ImagesClient(IReadOnlyDictionary<string, string> configs)
		{
			if(configs.TryGetValue("unsplash-api-key", out string unsplashApiKey)) {
				unsplash = new UnsplashAPI.UnsplashClient(unsplashApiKey);
			}

			if(configs.TryGetValue("wallhaven-api-key", out string wallhavenApiKey)) {
				wallhaven = new WallhavenAPI.WallhavenClient(wallhavenApiKey);
			}
		}

		public async Task<List<string>> GetRandomImagesAsync()
		{
			List<string> results = new List<string>();

			if(wallhaven != null) {
				WallhavenAPI.SearchRequest wallhavenSearchRequest = wallhaven.Search()
					.SetQ("anime girl")
					.SetCategories(WallhavenAPI.Category.General, WallhavenAPI.Category.Anime, WallhavenAPI.Category.People)
					.SetPurity(WallhavenAPI.Purity.SFW, WallhavenAPI.Purity.Sketchy, WallhavenAPI.Purity.NSFW)
					.SetAtLeast(new WallhavenAPI.Dimension(1600, 900))
					.SetSorting(WallhavenAPI.Sorting.Relevance)
					.SetOrder(WallhavenAPI.Order.Descending);

				results.AddRange((await wallhavenSearchRequest.SendAsync()).Select(image => image.Path));
			}

			return results;
		}

		public async Task<List<string>> SearchImagesAsync(SearchImagesQuery query)
		{
			List<string> results = new List<string>();

			if(unsplash != null) {
				UnsplashAPI.SearchPhotosRequest unsplashSearchPhotoRequest = unsplash.SearchPhotos()
					.SetQuery(query.Query)
					.SetOrientation(UnsplashAPI.Orientation.Landscape)
					.SetOrderBy(UnsplashAPI.OrderBy.Relevant)
					.SetPerPage(30);

				results.AddRange((await unsplashSearchPhotoRequest.SendAsync()).Select(photo => photo.Urls.Full));
			}

			if(wallhaven != null) {
				WallhavenAPI.SearchRequest wallhavenSearchRequest = wallhaven.Search()
					.SetQ(query.Query)
					.SetCategories(WallhavenAPI.Category.General, WallhavenAPI.Category.Anime, WallhavenAPI.Category.People)
					.SetPurity(WallhavenAPI.Purity.SFW, WallhavenAPI.Purity.Sketchy, WallhavenAPI.Purity.NSFW)
					.SetAtLeast(new WallhavenAPI.Dimension(1600, 900))
					.SetSorting(WallhavenAPI.Sorting.Relevance)
					.SetOrder(WallhavenAPI.Order.Descending);

				results.AddRange((await wallhavenSearchRequest.SendAsync()).Select(image => image.Path));
			}

			return results;
		}
	}
}

using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Unsplash = Someday.SDK.APIClients.Unsplash;
using Wallhaven = Someday.SDK.APIClients.Wallhaven;

namespace Someday.SDK
{
	public class ImagesClient
	{
		public async Task<List<string>> GetRandomImagesAsync()
		{
			List<string> results = new List<string>();

			Wallhaven.SearchRequest wallhavenSearchRequest = new Wallhaven.SearchRequest()
				.SetQ("anime girl")
				.SetCategories(Wallhaven.Category.General, Wallhaven.Category.Anime, Wallhaven.Category.People)
				.SetPurity(Wallhaven.Purity.SFW, Wallhaven.Purity.Sketchy, Wallhaven.Purity.NSFW)
				.SetAtLeast(new Wallhaven.Dimension(1600, 900))
				.SetSorting(Wallhaven.Sorting.Relevance)
				.SetOrder(Wallhaven.Order.Descending);

			results.AddRange((await wallhavenSearchRequest.SendAsync()).Select(image => image.Path));

			return results;
		}

		public async Task<List<string>> SearchImagesAsync(SearchImagesQuery query)
		{
			List<string> results = new List<string>();

			Unsplash.SearchPhotosRequest unsplashSearchPhotoRequest = new Unsplash.SearchPhotosRequest()
				.SetClientId("")
				.SetQuery(query.Query)
				.SetOrientation(Unsplash.Orientation.Landscape)
				.SetOrderBy(Unsplash.OrderBy.Relevant)
				.SetPerPage(30);

			Wallhaven.SearchRequest wallhavenSearchRequest = new Wallhaven.SearchRequest()
				.SetQ(query.Query)
				.SetCategories(Wallhaven.Category.General, Wallhaven.Category.Anime, Wallhaven.Category.People)
				.SetPurity(Wallhaven.Purity.SFW, Wallhaven.Purity.Sketchy, Wallhaven.Purity.NSFW)
				.SetAtLeast(new Wallhaven.Dimension(1600, 900))
				.SetSorting(Wallhaven.Sorting.Relevance)
				.SetOrder(Wallhaven.Order.Descending);

			results.AddRange((await unsplashSearchPhotoRequest.SendAsync()).Select(photo => photo.Urls.Full));
			results.AddRange((await wallhavenSearchRequest.SendAsync()).Select(image => image.Path));

			return results;
		}
	}
}

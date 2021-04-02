using System.Threading.Tasks;
using System.Collections.Generic;

namespace Someday.SDK
{
	public class ImagesClient
	{
		public async Task<List<string>> GetRandomImagesAsync()
		{
			WallhavenImagesProvider provider = new WallhavenImagesProvider();
			return await provider.GetRandomImagesAsync();
		}

		public async Task<List<string>> SearchImagesAsync(SearchImagesQuery query)
		{
			WallhavenImagesProvider provider = new WallhavenImagesProvider();
			return await provider.SearchImagesAsync(query);
		}
	}
}

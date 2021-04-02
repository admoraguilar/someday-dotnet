using System.Threading.Tasks;
using System.Collections.Generic;

namespace Someday.SDK
{
	public abstract class ImagesProvider
	{
		public abstract Task<List<string>> GetRandomImagesAsync();
		public abstract Task<List<string>> SearchImagesAsync(SearchImagesQuery query);
	}
}

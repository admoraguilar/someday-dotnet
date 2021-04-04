using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Someday.SDK;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Someday.API.Controllers
{
	[ApiController]
	public class ImagesController : ControllerBase
	{
		[HttpGet]
		[Route("api/v1/images/random")]
		public async Task<IEnumerable<string>> Random()
		{
			ImagesClient imagesClient = new ImagesClient();
			return await imagesClient.GetRandomImagesAsync();
		}

		[HttpGet]
		[Route("api/v1/images/search")]
		public async Task<IEnumerable<string>> Search([FromQuery] SearchImagesQuery searchQuery)
		{
			ImagesClient imagesClient = new ImagesClient();
			return await imagesClient.SearchImagesAsync(searchQuery);
		}
	}
}

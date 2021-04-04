using System.Net.Http;
using System.Threading.Tasks;
using AspNetCore.Proxy;
using AspNetCore.Proxy.Options;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Someday.API.Controllers
{
	[ApiController]
	public class ProxyController : ControllerBase
	{
		[HttpGet]
		[Route("api/v1/proxy")]
		public Task GetProxy(string url)
		{
			HttpProxyOptions httpProxyOptions = HttpProxyOptionsBuilder.Instance
				.WithShouldAddForwardedHeaders(false)
				.WithBeforeSend((context, request) => {
					request.Headers.Remove("referer");

					return Task.CompletedTask;
				}).Build();

			return this.HttpProxyAsync(url);
		}

		[HttpGet]
		[Route("api/v1/proxy-2")]
		public async Task<IActionResult> GetImage(string url)
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.GetAsync(url);
			//return await response.Content.ReadAsByteArrayAsync();
			return File(await response.Content.ReadAsByteArrayAsync(), response.Content.Headers.ContentType.ToString());
		}
	}
}

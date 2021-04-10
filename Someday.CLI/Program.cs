using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Someday.SDK;
using Someday.SDK.APIClients.Google.Places;

namespace Someday.CLI
{
	public class Program
	{
		static async Task Test()
		{
			//ImagesClient imagesClient = new ImagesClient();
			//List<string> results = await imagesClient.SearchImagesAsync(new SearchImagesQuery {
			//	Query = "paris"
			//});
			//foreach(string result in results) {
			//	Console.WriteLine($"Images got: {result}");
			//}

			//SearchRequest request = new SearchRequest()
			//	.SetQ("anime girl")
			//	.SetCategories(Category.General, Category.Anime)
			//	.SetPurity(Purity.SFW, Purity.Sketchy)
			//	.SetAtLeast(new Dimension(1600, 900));

			//IEnumerable<Image> images = await request.SendAsync();
			//foreach(Image image in images) {
			//	Console.WriteLine($"Image: {image.Path}");
			//}

			//SearchPhotosRequest request = new SearchPhotosRequest()
			//	.SetClientId("api key")
			//	.SetQuery("paris")
			//	.SetPerPage(30);

			//IEnumerable<Photo> photos = await request.SendAsync();
			//foreach(Photo photo in photos) {
			//	Console.WriteLine($"Photo: {photo.Urls.Full}");
			//}
		}

		static async Task Main(string[] args)
		{
			SomedayClientConfig somedayClientConfig = new SomedayClientConfig();
			somedayClientConfig.LoadConfigFromProcessRelativePath("someday-config.json");

			SomedayClient somedayClient = new SomedayClient(somedayClientConfig);
			//List<string> images = await somedayClient.Images.SearchImagesAsync(new SearchImagesQuery() { Query = "anime" });
			//foreach(string image in images) { Console.WriteLine($"Images got: {image}"); }

			string somedayGApiKey = "AIzaSyDQ_VPbuWsRtNgGtPgHoTAaupraVvcd8Fk";
			List<Place> places = await new FindPlaceRequest()
				.SetApiKey(somedayGApiKey)
				.SetInput("paris")
				.SetInputType(InputType.TextQuery)
				.SetLanguage("en")
				.SetFields(
					Fields.Basic.FormattedAddress, Fields.Basic.Icon,
					Fields.Basic.Name, Fields.Basic.Photos,
					Fields.Basic.PlaceId, Fields.Basic.Types)
				.SendAsync();

			Console.WriteLine($"Got {places.Count} places.");
		}
	}
}

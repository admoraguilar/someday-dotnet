using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Someday.SDK;
using Someday.SDK.APIClients.Common;

using GooglePlaces = Someday.SDK.APIClients.Google.Places;
using HereGeocodingAndSearch = Someday.SDK.APIClients.Here.GeocodingAndSearch;
using System.Linq;

namespace Someday.CLI
{
	public class Program
	{
		static async Task TestImagesClient(SomedayClient somedayClient)
		{
			List<string> images = await somedayClient.Images.SearchImagesAsync(
				new SearchImagesQuery() { Query = "anime" });
			foreach(string image in images) { Console.WriteLine($"Images got: {image}"); }
		}

		static async Task TestGooglePlaces(SomedayClientConfig config)
		{
			string somedayGApiKey = config["google-cloud-api-key"];
			GooglePlaces.Place[] places = await new GooglePlaces.FindPlaceRequest()
				.SetApiKey(somedayGApiKey)
				.SetInput("paris")
				.SetInputType(GooglePlaces.InputType.TextQuery)
				.SetLanguage("en")
				.SetFields(
					GooglePlaces.Fields.Basic.FormattedAddress, GooglePlaces.Fields.Basic.Icon,
					GooglePlaces.Fields.Basic.Name, GooglePlaces.Fields.Basic.Photos,
					GooglePlaces.Fields.Basic.PlaceId, GooglePlaces.Fields.Basic.Types)
				.SendAsync();

			Console.WriteLine($"Got {places.Length} places.");
		}

		static async Task TestHere(SomedayClientConfig config)
		{
			string hereApiKey = config["here-api-key"];

			HereGeocodingAndSearch.GeocodeAndSearchResult[] results = 
				await new HereGeocodingAndSearch.GeocodeRequest()
				.SetApiKey(hereApiKey)
				.SetQ("Sta. Ana, Manila")
				.SendAsync();

			Console.WriteLine($"Results count: {results.Count()}");
		}

		static async Task Main(string[] args)
		{
			SomedayClientConfig somedayClientConfig = new SomedayClientConfig();
			somedayClientConfig.LoadConfigFromProcessRelativePath("someday-config.json");
			SomedayClient somedayClient = new SomedayClient(somedayClientConfig);

			await TestHere(somedayClientConfig);

			Console.ReadLine();
		}
	}
}

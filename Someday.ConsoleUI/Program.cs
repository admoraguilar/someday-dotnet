using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Someday.SDK;

namespace Someday.ConsoleUI
{
	public class Program
	{
		static async Task Main(string[] args)
		{
			ImagesClient imagesClient = new ImagesClient();
			List<string> results = await imagesClient.GetImagesAsync();
			foreach(string result in results) {
				Console.WriteLine($"Images got: {result}");
			}
		}
	}
}

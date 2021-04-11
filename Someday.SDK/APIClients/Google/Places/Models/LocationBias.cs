
namespace Someday.SDK.APIClients.Google.Places
{
	public class LocationBias
	{
		public const string IPBias = "ipbias";

		public static string PointBias(string lat, string lng) => 
			$"point:{lat},{lng}";

		public static string Circular(string lat, string lng) =>
			$"circle:radius@{lat},{lng}";

		public static string Rectangular(
			string south, string west,
			string north, string east) =>
			$"rectangle:{south},{west}|{north},{east}";
	}
}


namespace Someday.SDK.APIClients.Google.Places
{
	public class GeographicCoordinate
	{
		public double Latitude { get; set; }
		public double Longtitude { get; set; }

		public GeographicCoordinate(double latitude, double longtitude)
		{
			Latitude = latitude;
			Longtitude = longtitude;
		}
	}
}

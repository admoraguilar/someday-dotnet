
namespace Someday.SDK
{
	public class SomedayClient
	{
		public ImagesClient Images { get; private set; }
		
		public SomedayClient(SomedayClientConfig config)
		{
			Images = new ImagesClient(config);
		}
	}
}

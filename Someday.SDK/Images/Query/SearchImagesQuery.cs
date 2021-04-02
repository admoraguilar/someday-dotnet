
namespace Someday.SDK
{
	public class SearchImagesQuery
	{
		public string Query { get; set; }
		public int Page { get; set; }

		public SearchImagesQuery()
		{
			Page = 1;
		}
	}
}

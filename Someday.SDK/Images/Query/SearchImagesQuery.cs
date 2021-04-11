
namespace Someday.SDK
{
	public record SearchImagesQuery
	{
		public string Query { get; set; } = string.Empty;
		public int Page { get; set; } = 1;
	}
}

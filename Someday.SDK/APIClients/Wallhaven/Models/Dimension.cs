
namespace Someday.SDK.APIClients.Wallhaven
{
	public record Dimension
	{
		public int Width { get; init; } = 0;
		public int Height { get; init; } = 0;

		public Dimension(int width, int height) =>
			(Width, Height) = (width, height);
	}
}

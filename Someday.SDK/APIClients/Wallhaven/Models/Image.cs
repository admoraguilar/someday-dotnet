using System;

namespace Someday.SDK.APIClients.Wallhaven
{
	public class Image
	{
		public string Id { get; set; }
		public string Url { get; set; }
		public string ShortUrl { get; set; }
		public int Views { get; set; }
		public int Favorites { get; set; }
		public string Source { get; set; }
		public string Purity { get; set; }
		public string Category { get; set; }
		public Dimension Resolution { get; set; }
		public string Ratio { get; set; }
		public int FileSize { get; set; }
		public string FileType { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
		public string[] Colors { get; set; }
		public string Path { get; set; }
		public Thumbs Thumbs { get; set; }
	}
}

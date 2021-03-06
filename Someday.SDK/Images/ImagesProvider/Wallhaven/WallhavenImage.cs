using System;
using System.Collections.Generic;

namespace Someday.SDK
{
	public class WallhavenImage
	{
		public string Id { get; private set; }
		public string Url { get; private set; }
		public string ShortUrl { get; private set; }
		public int Views { get; private set; }
		public int Favorites { get; private set; }
		public string Source { get; private set; }
		public string Purity { get; private set; }
		public string Category { get; private set; }
		public int DimensionX { get; private set; }
		public int DimensionY { get; private set; }
		public string Resolution { get; private set; }
		public string Ratio { get; private set; }
		public int FileSize { get; private set; }
		public string FileType { get; private set; }
		public DateTimeOffset CreatedAt { get; private set; }
		public string[] Colors { get; private set; }
		public string Path { get; private set; }
		public Dictionary<string, string> Thumbs { get; private set; }

		public WallhavenImage(
			string id, string url, int views, int favorites, string source,
			string purity, string category, int dimension_x, int dimension_y, string resolution,
			string ratio, int file_size, string file_type, DateTimeOffset created_at, string[] colors,
			string path, Dictionary<string, string> thumbs)
		{
			Id = id;
			Url = url;
			Views = views;
			Favorites = favorites;
			Source = source;
			Purity = purity;
			Category = category;
			DimensionX = dimension_x;
			DimensionY = dimension_y;
			Resolution = resolution;
			Ratio = ratio;
			FileSize = file_size;
			FileType = file_type;
			CreatedAt = created_at;
			Colors = colors;
			Path = path;
			Thumbs = thumbs;
		}
	}
}

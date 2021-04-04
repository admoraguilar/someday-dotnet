using System;

namespace Someday.SDK.APIClients.Unsplash
{
	public class Photo
	{
		public string Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public string Color { get; set; }
		public string BlurHash { get; set; }
		public int Likes { get; set; }
		public bool LikedByUser { get; set; }
		public string Description { get; set; }
		public string[] CurrentUserCollections { get; set; }
		public PhotoUrls Urls { get; set; }
		public PhotoLinks Links { get; set; }
	}
}

namespace Hazelnut.Models
{
	public class PaperContainer : ProductBase
	{
		public string Size { get; set; }
		public string Price { get; set; }
		public string Weight { get; set; }
		public string Origin { get; set; }
		public string Producer { get; set; }
		public string Description { get; set; }
		public string? ImagePathSmall { get; set; }
		public string? ImagePathMedium { get; set; }
		public string? ImagePathLarge { get; set; }
	}
}

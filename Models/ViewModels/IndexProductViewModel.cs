namespace Hazelnut.Models.ViewModels
{
	public class IndexProductViewModel
	{
		public int ProductId { get; set; }
		public string Name { get; set; }
		public string? ImagePath { get; set; }
		public string? ImagePathSmall { get; set; }
		public string? ImagePathMedium { get; set; }
		public string? ImagePathLarge { get; set; }
		public string Price { get; set; }
		public required string ProductType { get; set; }
	}
}

using Microsoft.AspNetCore.Mvc;

namespace Hazelnut.Models.ViewModels
{
	public class ProductDetailsViewModel
	{
		public required ProductBase Product { get; set; }
		public List<ProductBase>? RelatedProducts { get; set; }
		public string? RelatedProductType { get; set; }
	}

}

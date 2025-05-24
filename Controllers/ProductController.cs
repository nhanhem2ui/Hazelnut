using Hazelnut.Database;
using Hazelnut.Models;
using Hazelnut.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hazelnut.Controllers
{
    [Route("/Product")]
    public class ProductController : Controller
    {
        private readonly AppDbContext appDbContext;
        public ProductController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

		public IActionResult Index(int productId, string productType)
		{
			ProductBase? productBase = null;
			List<ProductBase> relatedProducts = [];
			string relativeProductType = string.Empty;
			switch (productType)
			{
				case "ToiletPaper":
					productBase = appDbContext.ToiletPapers.FirstOrDefault(x => x.ProductId == productId);
					relatedProducts = appDbContext.ToiletPapers.Where(x => x.ProductId != productId).Cast<ProductBase>().ToList();
					relativeProductType = "ToiletPaper";
					break;
				case "SmallToiletPaper":
					productBase = appDbContext.SmallToiletPapers.FirstOrDefault(x => x.ProductId == productId);
					relatedProducts = appDbContext.SmallToiletPapers.Where(x => x.ProductId != productId).Cast<ProductBase>().ToList();
					relativeProductType = "SmallToiletPaper";
					break;
				case "Napkin":
					productBase = appDbContext.Napkins.FirstOrDefault(x => x.ProductId == productId);
					relatedProducts = appDbContext.Napkins.Where(x => x.ProductId != productId).Cast<ProductBase>().ToList();
					relativeProductType = "Napkin";
					break;
				case "Hankerchief":
					productBase = appDbContext.PaperHandkerchiefs.FirstOrDefault(x => x.ProductId == productId);
					relatedProducts = appDbContext.PaperHandkerchiefs.Where(x => x.ProductId != productId).Cast<ProductBase>().ToList();
					relativeProductType = "Hankerchief";
					break;
				case "PaperContainer":
					productBase = appDbContext.PaperContainers.FirstOrDefault(x => x.ProductId == productId);
					relatedProducts = appDbContext.PaperContainers.Where(x => x.ProductId != productId).Cast<ProductBase>().ToList();
					relativeProductType = "PaperContainer";
					break;
			}

			if (productBase == null)
			{
				return Forbid();
			}

			var viewModel = new ProductDetailsViewModel
			{
				Product = productBase,
				RelatedProducts = relatedProducts,
				RelatedProductType = relativeProductType
			};

			return View(viewModel);
		}

	}
}

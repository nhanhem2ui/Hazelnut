using Hazelnut.Database;
using Hazelnut.Models;
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
            switch (productType)
            {
                case "ToiletPaper":
                    productBase = appDbContext.ToiletPapers.FirstOrDefault(x => x.ProductId == productId);
                    break;
                case "SmallToiletPaper":
                    productBase = appDbContext.SmallToiletPapers.FirstOrDefault(x => x.ProductId == productId);
                    break;
                case "Napkin":
                    productBase = appDbContext.Napkins.FirstOrDefault(x => x.ProductId == productId);
                    break;
                case "Hankerchief":
                    productBase = appDbContext.PaperHandkerchiefs.FirstOrDefault(x => x.ProductId == productId);
                    break;
                case "PaperContainer":
                    productBase = appDbContext.PaperContainers.FirstOrDefault(x => x.ProductId == productId);
                    break;
            }

            if (productBase == null)
            {
                return Forbid();
            }
            return View(productBase);
        }
    }
}

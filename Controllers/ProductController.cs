using Hazelnut.Database;
using Hazelnut.Models;
using Hazelnut.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using System.Drawing.Printing;

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

		[HttpGet("AllOfOneType")]
		public IActionResult AllOfOneType(string productType, int page = 1, int pageSize = 9)
		{
			var productTypeVietnamese = string.Empty;
			IQueryable<ProductBase>? products = null;
			var totalProduct = 0;

			switch (productType)
			{
				case "ToiletPaper":
					productTypeVietnamese = "Giấy vệ sinh cuộn lớn";
					products = appDbContext.ToiletPapers;
					break;
				case "SmallToiletPaper":
					productTypeVietnamese = "Giấy vệ sinh cuộn nhỏ";
					products = appDbContext.SmallToiletPapers;
					break;
				case "Napkin":
					productTypeVietnamese = "Giấy ăn";
					products = appDbContext.Napkins;
					break;
				case "Hankerchief":
					productTypeVietnamese = "Giấy lau tay";
					products = appDbContext.PaperHandkerchiefs;
					break;
				case "PaperContainer":
					productTypeVietnamese = "Hộp đựng giấy cuộn lớn";
					products = appDbContext.PaperContainers;
					break;
			}

			if (products == null)
			{
				return Forbid();
			}

			totalProduct = products.Count(); // total before pagination
			var pagedProducts = products
				.Skip((page - 1) * pageSize)
				.Take(pageSize);

			var model = new AllOfOneTypeViewModel
			{
				ProductType = productType,
				ProductTypeVietnamese = productTypeVietnamese,
				TotalProduct = totalProduct,
				Products = pagedProducts,
				CurrentPage = page,
				PageSize = pageSize
			};

			return View(model);
		}

		[HttpGet("Search")]
		public IActionResult Search(string name, int page = 1, int pageSize = 9)
		{
			if (string.IsNullOrEmpty(name))
			{
				return Forbid();
			}

			var lowerName = name.ToLower();

			var toiletPaper = appDbContext.ToiletPapers.Where(x => x.Name.ToLower().Contains(lowerName));
			var smallToiletPaper = appDbContext.SmallToiletPapers.Where(x => x.Name.ToLower().Contains(lowerName));
			var napkin = appDbContext.Napkins.Where(x => x.Name.ToLower().Contains(lowerName));
			var hankerchief = appDbContext.PaperHandkerchiefs.Where(x => x.Name.ToLower().Contains(lowerName));
			var paperContainer = appDbContext.PaperContainers.Where(x => x.Name.ToLower().Contains(lowerName));

			var model = new SeachViewModel
			{
				ToiletPapers = toiletPaper,
				SmallToiletPapers = smallToiletPaper,
				Napkins = napkin,
				PaperHandkerchiefs = hankerchief,
				PaperContainers = paperContainer,
				TotalProduct = toiletPaper.Count() + smallToiletPaper.Count() + napkin.Count() + hankerchief.Count() + paperContainer.Count(),
				CurrentPage = page,
				PageSize = pageSize,
				Name = name,
			};

			return View(model);
		}

	}
}

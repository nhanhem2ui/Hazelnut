using Hazelnut.Database;
using Hazelnut.Models;
using Hazelnut.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hazelnut.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext appDbContext;
		public HomeController( AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		public IActionResult Index()
		{
			IQueryable<IndexProductViewModel> toiletPapers = appDbContext.ToiletPapers
		.Select(p => new IndexProductViewModel
		{
			ProductId = p.ProductId,
			Name = p.Name,
			ImagePath = p.ImagePath,
			Price = p.Price,
			ImagePathSmall = p.ImagePathSmall,
			ImagePathLarge = p.ImagePathLarge,
			ImagePathMedium = p.ImagePathMedium,
			ProductType = "ToiletPaper"
		});

			IQueryable<IndexProductViewModel> smallToiletPaper = appDbContext.SmallToiletPapers
		.Select(p => new IndexProductViewModel
		{
			ProductId = p.ProductId,
			Name = p.Name,
			ImagePath = p.ImagePath,
			Price = p.Price,
			ImagePathSmall = p.ImagePathSmall,
			ImagePathLarge = p.ImagePathLarge,
			ImagePathMedium = p.ImagePathMedium,
			ProductType = "SmallToiletPaper"
		});
			IQueryable<IndexProductViewModel> napkin = appDbContext.Napkins
	   .Select(p => new IndexProductViewModel
	   {
		   ProductId = p.ProductId,
		   Name = p.Name,
		   ImagePath = p.ImagePath,
		   Price = p.Price,
		   ImagePathSmall = p.ImagePathSmall,
		   ImagePathLarge = p.ImagePathLarge,
		   ImagePathMedium = p.ImagePathMedium,
		   ProductType = "Napkin"
	   });
			IQueryable<IndexProductViewModel> paperHankerchiefs = appDbContext.PaperHandkerchiefs
	   .Select(p => new IndexProductViewModel
	   {
		   ProductId = p.ProductId,
		   Name = p.Name,
		   ImagePath = p.ImagePath,
		   Price = p.Price,
		   ImagePathSmall = p.ImagePathSmall,
		   ImagePathLarge = p.ImagePathLarge,
		   ImagePathMedium = p.ImagePathMedium,
		   ProductType = "Hankerchief"
	   });
			IQueryable<IndexProductViewModel> paperContainer = appDbContext.PaperContainers
	   .Select(p => new IndexProductViewModel
	   {
		   ProductId = p.ProductId,
		   Name = p.Name,
		   ImagePath = p.ImagePath,
		   Price = p.Price,
		   ImagePathSmall = p.ImagePathSmall,
		   ImagePathLarge = p.ImagePathLarge,
		   ImagePathMedium = p.ImagePathMedium,
		   ProductType = "PaperContainer"
	   });

			var indexViewModel = new IndexViewModel
			{
				ToiletPapers = toiletPapers,
				SmallToiletPapers = smallToiletPaper,
				Napkins = napkin,
				PaperHandkerchiefs = paperHankerchiefs,
				PaperContainers = paperContainer,
			};

			return View(indexViewModel);
		}

		//public IActionResult Privacy()
		//{
		//	return View();
		//}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

using Hazelnut.Database;
using Microsoft.AspNetCore.Mvc;

namespace Hazelnut.Controllers
{
	public class ProductController : Controller
	{
		private readonly AppDbContext appDbContext;
		public ProductController(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		[HttpGet]
		public IActionResult Index([FromQuery] int productId, [FromQuery] string productType)
		{
			return View();
		}
	}
}

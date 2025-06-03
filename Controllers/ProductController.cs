using Hazelnut.Database;
using Hazelnut.Models;
using Hazelnut.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace Hazelnut.Controllers
{
	[Route("/Product")]
	public class ProductController : Controller
	{
		private readonly AppDbContext appDbContext;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public ProductController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
		{
			this.appDbContext = appDbContext;
			_webHostEnvironment = webHostEnvironment;
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
			try
			{
				var toiletPaper = appDbContext.ToiletPapers.Where(x => x.Name.Contains(lowerName, StringComparison.CurrentCultureIgnoreCase));
				var smallToiletPaper = appDbContext.SmallToiletPapers.Where(x => x.Name.Contains(lowerName, StringComparison.CurrentCultureIgnoreCase));
				var napkin = appDbContext.Napkins.Where(x => x.Name.Contains(lowerName, StringComparison.CurrentCultureIgnoreCase));
				var hankerchief = appDbContext.PaperHandkerchiefs.Where(x => x.Name.Contains(lowerName, StringComparison.CurrentCultureIgnoreCase));
				var paperContainer = appDbContext.PaperContainers.Where(x => x.Name.Contains(lowerName, StringComparison.CurrentCultureIgnoreCase));

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
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("Delete")]
		public IActionResult Delete(int productId, string productType)
		{
			try
			{
				switch (productType)
				{
					case "ToiletPaper":
						var toiletPaper = appDbContext.ToiletPapers.FirstOrDefault(x => x.ProductId == productId);
						if (toiletPaper != null)
						{
							appDbContext.ToiletPapers.Remove(toiletPaper);
							DeleteImageIfExists(toiletPaper.ImagePath);
							DeleteImageIfExists(toiletPaper.ImagePathSmall);
							DeleteImageIfExists(toiletPaper.ImagePathMedium);
							DeleteImageIfExists(toiletPaper.ImagePathLarge);
						}
						break;

					case "SmallToiletPaper":
						var smallToiletPaper = appDbContext.SmallToiletPapers.FirstOrDefault(x => x.ProductId == productId);
						if (smallToiletPaper != null)
						{
							appDbContext.SmallToiletPapers.Remove(smallToiletPaper);
							DeleteImageIfExists(smallToiletPaper.ImagePath);
							DeleteImageIfExists(smallToiletPaper.ImagePathSmall);
							DeleteImageIfExists(smallToiletPaper.ImagePathMedium);
							DeleteImageIfExists(smallToiletPaper.ImagePathLarge);
						}
						break;

					case "Napkin":
						var napkin = appDbContext.Napkins.FirstOrDefault(x => x.ProductId == productId);
						if (napkin != null)
						{
							appDbContext.Napkins.Remove(napkin);
							DeleteImageIfExists(napkin.ImagePath);
							DeleteImageIfExists(napkin.ImagePathSmall);
							DeleteImageIfExists(napkin.ImagePathMedium);
							DeleteImageIfExists(napkin.ImagePathLarge);
						}
						break;

					case "Hankerchief":
						var handkerchief = appDbContext.PaperHandkerchiefs.FirstOrDefault(x => x.ProductId == productId);
						if (handkerchief != null)
						{
							appDbContext.PaperHandkerchiefs.Remove(handkerchief);
							DeleteImageIfExists(handkerchief.ImagePath);
							DeleteImageIfExists(handkerchief.ImagePathSmall);
							DeleteImageIfExists(handkerchief.ImagePathMedium);
							DeleteImageIfExists(handkerchief.ImagePathLarge);
						}
						break;

					case "PaperContainer":
						var paperContainer = appDbContext.PaperContainers.FirstOrDefault(x => x.ProductId == productId);
						if (paperContainer != null)
						{
							appDbContext.PaperContainers.Remove(paperContainer);
							DeleteImageIfExists(paperContainer.ImagePath);
							DeleteImageIfExists(paperContainer.ImagePathSmall);
							DeleteImageIfExists(paperContainer.ImagePathMedium);
							DeleteImageIfExists(paperContainer.ImagePathLarge);
						}
						break;

					default:
						return BadRequest("Invalid product type.");
				}

				appDbContext.SaveChanges();
				return RedirectToAction("AllOfOneType", new { productType });
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		private void DeleteImageIfExists(string? imagePath)
		{
			if (string.IsNullOrEmpty(imagePath))
				return;

			var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath.TrimStart('/'));
			if (System.IO.File.Exists(fullPath))
			{
				System.IO.File.Delete(fullPath);
			}
		}

		[HttpGet("Edit")]
		public IActionResult Edit(int productId, string productType)
		{
			var model = new EditViewModel();
			switch (productType)
			{
				case "ToiletPaper":
					var toiletPaper = appDbContext.ToiletPapers.FirstOrDefault(p => p.ProductId == productId);
					if (toiletPaper == null)
					{
						return NotFound();
					}
					model.ProductId = toiletPaper.ProductId;
					model.Producer = toiletPaper.Producer;
					model.ProductType = productType;
					model.Size = toiletPaper.Size;
					model.ExistingImagePath = toiletPaper.ImagePath;
					model.ExistingImagePathMedium = toiletPaper.ImagePathMedium;
					model.ExistingImagePathSmall = toiletPaper.ImagePathSmall;
					model.ExistingImagePathLarge = toiletPaper.ImagePathLarge;
					model.Description = toiletPaper.Description;
					model.Origin = toiletPaper.Origin;
					model.Price = toiletPaper.Price;
					model.Weight = toiletPaper.Weight;
					model.Name = toiletPaper.Name;
					break;
				case "SmallToiletPaper":
					var smallToiletPaper = appDbContext.SmallToiletPapers.FirstOrDefault(p => p.ProductId == productId);
					if (smallToiletPaper == null)
					{
						return NotFound();
					}
					model.ProductId = smallToiletPaper.ProductId;
					model.Producer = smallToiletPaper.Producer;
					model.ProductType = productType;
					model.Size = smallToiletPaper.Size;
					model.ExistingImagePath = smallToiletPaper.ImagePath;
					model.ExistingImagePathMedium = smallToiletPaper.ImagePathMedium;
					model.ExistingImagePathSmall = smallToiletPaper.ImagePathSmall;
					model.ExistingImagePathLarge = smallToiletPaper.ImagePathLarge;
					model.Description = smallToiletPaper.Description;
					model.Origin = smallToiletPaper.Origin;
					model.Price = smallToiletPaper.Price;
					model.Weight = smallToiletPaper.Weight;
					model.Name = smallToiletPaper.Name;
					break;
				case "Napkin":
					var napkin = appDbContext.Napkins.FirstOrDefault(p => p.ProductId == productId);
					if (napkin == null)
					{
						return NotFound();
					}
					model.ProductId = napkin.ProductId;
					model.Producer = napkin.Producer;
					model.ProductType = productType;
					model.Size = napkin.Size;
					model.ExistingImagePath = napkin.ImagePath;
					model.ExistingImagePathMedium = napkin.ImagePathMedium;
					model.ExistingImagePathSmall = napkin.ImagePathSmall;
					model.ExistingImagePathLarge = napkin.ImagePathLarge;
					model.Description = napkin.Description;
					model.Origin = napkin.Origin;
					model.Price = napkin.Price;
					model.Weight = napkin.Weight;
					model.Name = napkin.Name;
					break;
				case "Hankerchief":
					var hankerchief = appDbContext.PaperHandkerchiefs.FirstOrDefault(p => p.ProductId == productId);
					if (hankerchief == null)
					{
						return NotFound();
					}
					model.ProductId = hankerchief.ProductId;
					model.Producer = hankerchief.Producer;
					model.ProductType = productType;
					model.Size = hankerchief.Size;
					model.ExistingImagePath = hankerchief.ImagePath;
					model.ExistingImagePathMedium = hankerchief.ImagePathMedium;
					model.ExistingImagePathSmall = hankerchief.ImagePathSmall;
					model.ExistingImagePathLarge = hankerchief.ImagePathLarge;
					model.Description = hankerchief.Description;
					model.Origin = hankerchief.Origin;
					model.Price = hankerchief.Price;
					model.Weight = hankerchief.Weight;
					model.Name = hankerchief.Name;
					break;
				case "PaperContainer":
					var paperContainer = appDbContext.PaperContainers.FirstOrDefault(p => p.ProductId == productId);
					if (paperContainer == null)
					{
						return NotFound();
					}
					model.ProductId = paperContainer.ProductId;
					model.Producer = paperContainer.Producer;
					model.ProductType = productType;
					model.Size = paperContainer.Size;
					model.ExistingImagePath = paperContainer.ImagePath;
					model.ExistingImagePathMedium = paperContainer.ImagePathMedium;
					model.ExistingImagePathSmall = paperContainer.ImagePathSmall;
					model.ExistingImagePathLarge = paperContainer.ImagePathLarge;
					model.Description = paperContainer.Description;
					model.Origin = paperContainer.Origin;
					model.Price = paperContainer.Price;
					model.Weight = paperContainer.Weight;
					model.Name = paperContainer.Name;
					break;
			}
			return View(model);
		}

		[HttpPost("Edit")]
		public async Task<IActionResult> EditAsync(EditViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				// Handle file uploads and get new paths
				string newMainPath = model.ExistingImagePath;
				string newSmallPath = model.ExistingImagePathSmall;
				string newMediumPath = model.ExistingImagePathMedium;
				string newLargePath = model.ExistingImagePathLarge;

				// Save new files if provided and delete old ones
				if (model.ImagePath != null)
				{
					DeleteImageIfExists(model.ExistingImagePath); // Delete old main image
					newMainPath = await SaveFileAsync(model.ImagePath);
				}

				if (model.ImagePathSmall != null)
				{
					DeleteImageIfExists(model.ExistingImagePathSmall); // Delete old small image
					newSmallPath = await SaveFileAsync(model.ImagePathSmall);
				}

				if (model.ImagePathMedium != null)
				{
					DeleteImageIfExists(model.ExistingImagePathMedium); // Delete old medium image
					newMediumPath = await SaveFileAsync(model.ImagePathMedium);
				}

				if (model.ImagePathLarge != null)
				{
					DeleteImageIfExists(model.ExistingImagePathLarge); // Delete old large image
					newLargePath = await SaveFileAsync(model.ImagePathLarge);
				}

				switch (model.ProductType)
				{
					case "ToiletPaper":
						var toiletPaper = appDbContext.ToiletPapers.FirstOrDefault(p => p.ProductId == model.ProductId);
						if (toiletPaper == null) return NotFound();

						toiletPaper.Producer = model.Producer;
						toiletPaper.Size = model.Size;
						toiletPaper.ImagePath = newMainPath;
						toiletPaper.ImagePathMedium = newMediumPath;
						toiletPaper.ImagePathSmall = newSmallPath;
						toiletPaper.ImagePathLarge = newLargePath;
						toiletPaper.Description = model.Description;
						toiletPaper.Origin = model.Origin;
						toiletPaper.Price = model.Price;
						toiletPaper.Weight = model.Weight;
						toiletPaper.Name = model.Name;
						break;

					case "SmallToiletPaper":
						var smallToiletPaper = appDbContext.SmallToiletPapers.FirstOrDefault(p => p.ProductId == model.ProductId);
						if (smallToiletPaper == null) return NotFound();

						smallToiletPaper.Producer = model.Producer;
						smallToiletPaper.Size = model.Size;
						smallToiletPaper.ImagePath = newMainPath;
						smallToiletPaper.ImagePathMedium = newMediumPath;
						smallToiletPaper.ImagePathSmall = newSmallPath;
						smallToiletPaper.ImagePathLarge = newLargePath;
						smallToiletPaper.Description = model.Description;
						smallToiletPaper.Origin = model.Origin;
						smallToiletPaper.Price = model.Price;
						smallToiletPaper.Weight = model.Weight;
						smallToiletPaper.Name = model.Name;
						break;

					case "Napkin":
						var napkin = appDbContext.Napkins.FirstOrDefault(p => p.ProductId == model.ProductId);
						if (napkin == null) return NotFound();

						napkin.Producer = model.Producer;
						napkin.Size = model.Size;
						napkin.ImagePath = newMainPath;
						napkin.ImagePathMedium = newMediumPath;
						napkin.ImagePathSmall = newSmallPath;
						napkin.ImagePathLarge = newLargePath;
						napkin.Description = model.Description;
						napkin.Origin = model.Origin;
						napkin.Price = model.Price;
						napkin.Weight = model.Weight;
						napkin.Name = model.Name;
						break;

					case "Hankerchief":
						var hankerchief = appDbContext.PaperHandkerchiefs.FirstOrDefault(p => p.ProductId == model.ProductId);
						if (hankerchief == null) return NotFound();

						hankerchief.Producer = model.Producer;
						hankerchief.Size = model.Size;
						hankerchief.ImagePath = newMainPath;
						hankerchief.ImagePathMedium = newMediumPath;
						hankerchief.ImagePathSmall = newSmallPath;
						hankerchief.ImagePathLarge = newLargePath;
						hankerchief.Description = model.Description;
						hankerchief.Origin = model.Origin;
						hankerchief.Price = model.Price;
						hankerchief.Weight = model.Weight;
						hankerchief.Name = model.Name;
						break;

					case "PaperContainer":
						var paperContainer = appDbContext.PaperContainers.FirstOrDefault(p => p.ProductId == model.ProductId);
						if (paperContainer == null) return NotFound();

						paperContainer.Producer = model.Producer;
						paperContainer.Size = model.Size;
						paperContainer.ImagePath = newMainPath;
						paperContainer.ImagePathMedium = newMediumPath;
						paperContainer.ImagePathSmall = newSmallPath;
						paperContainer.ImagePathLarge = newLargePath;
						paperContainer.Description = model.Description;
						paperContainer.Origin = model.Origin;
						paperContainer.Price = model.Price;
						paperContainer.Weight = model.Weight;
						paperContainer.Name = model.Name;
						break;

					default:
						return BadRequest("Invalid product type.");
				}

				appDbContext.SaveChanges();

				return RedirectToAction("AllOfOneType", "Product", new { productType = model.ProductType });
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}


		[HttpGet("Create")]
		public IActionResult Create()
		{
			CreateViewModel model = new();

			return View(model);
		}

		[HttpPost("Create")]
		public async Task<IActionResult> CreateAsync(CreateViewModel model)
		{
			string smallPath = string.Empty, mediumPath = string.Empty, largePath = string.Empty, mainPath = string.Empty;
			try
			{
				if (model.ImagePathSmall != null)
					smallPath = await SaveFileAsync(model.ImagePathSmall);

				if (model.ImagePathMedium != null)
					mediumPath = await SaveFileAsync(model.ImagePathMedium);

				if (model.ImagePathLarge != null)
					largePath = await SaveFileAsync(model.ImagePathLarge);

				if (model.ImagePath != null)
					mainPath = await SaveFileAsync(model.ImagePath);

				switch (model.ProductType)
				{
					case "ToiletPaper":
						var toiletPaper = new ToiletPaper
						{
							Name = model.Name,
							Description = model.Description,
							Origin = model.Origin,
							Price = model.Price,
							ImagePath = mainPath,
							ImagePathSmall = smallPath,
							ImagePathLarge = largePath,
							ImagePathMedium = mediumPath,
							Producer = model.Producer,
							Size = model.Size,
							Weight = model.Weight,
						};
						appDbContext.ToiletPapers.Add(toiletPaper);
						break;

					case "SmallToiletPaper":
						var smallToiletPaper = new SmallToiletPaper
						{
							Name = model.Name,
							Description = model.Description,
							Origin = model.Origin,
							Price = model.Price,
							ImagePath = mainPath,
							ImagePathSmall = smallPath,
							ImagePathLarge = largePath,
							ImagePathMedium = mediumPath,
							Producer = model.Producer,
							Size = model.Size,
							Weight = model.Weight,
						};
						appDbContext.SmallToiletPapers.Add(smallToiletPaper);
						break;

					case "Napkin":
						var napkin = new Napkin
						{
							Name = model.Name,
							Description = model.Description,
							Origin = model.Origin,
							Price = model.Price,
							ImagePath = mainPath,
							ImagePathSmall = smallPath,
							ImagePathLarge = largePath,
							ImagePathMedium = mediumPath,
							Producer = model.Producer,
							Size = model.Size,
							Weight = model.Weight,
						};
						appDbContext.Napkins.Add(napkin);
						break;

					case "Hankerchief":
						var hankerchief = new PaperHandkerchiefs
						{
							Name = model.Name,
							Description = model.Description,
							Origin = model.Origin,
							Price = model.Price,
							ImagePath = mainPath,
							ImagePathSmall = smallPath,
							ImagePathLarge = largePath,
							ImagePathMedium = mediumPath,
							Producer = model.Producer,
							Size = model.Size,
							Weight = model.Weight,
						};
						appDbContext.PaperHandkerchiefs.Add(hankerchief);
						break;

					case "PaperContainer":
						var paperContainer = new PaperContainer
						{
							Name = model.Name,
							Description = model.Description,
							Origin = model.Origin,
							Price = model.Price,
							ImagePath = mainPath,
							ImagePathSmall = smallPath,
							ImagePathLarge = largePath,
							ImagePathMedium = mediumPath,
							Producer = model.Producer,
							Size = model.Size,
							Weight = model.Weight,
						};
						appDbContext.PaperContainers.Add(paperContainer);
						break;

					default:
						return BadRequest("Invalid product type.");
				}
				appDbContext.SaveChanges();
				return RedirectToAction("Create");
			}
			catch (Exception ex)
			{
				// Optionally log the error
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
		private async Task<string> SaveFileAsync(IFormFile file)
		{
			var fileName = Path.GetFileName(file.FileName);
			var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
			using (var stream = new FileStream(uploadPath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}
			return "images/" + fileName;
		}
	}
}
namespace Hazelnut.Models.ViewModels
{
    public class CreateViewModel
    {
        public string Size { get; set; }
        public string Price { get; set; }
        public string Weight { get; set; }
        public string Origin { get; set; }
        public string Producer { get; set; }
        public string Description { get; set; }

        public IFormFile? ImagePathSmall { get; set; }
        public IFormFile? ImagePathMedium { get; set; }
        public IFormFile? ImagePathLarge { get; set; }

        public string Name { get; set; }
        public IFormFile? ImagePath { get; set; }

        public string ProductType { get; set; }
    }
}

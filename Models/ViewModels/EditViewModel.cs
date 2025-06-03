namespace Hazelnut.Models.ViewModels
{
    public class EditViewModel
    {
        // Product info
        public int ProductId { get; set; }
        public string Size { get; set; }
        public string Price { get; set; }
        public string Weight { get; set; }
        public string Origin { get; set; }
        public string Producer { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }

        // New image uploads
        public IFormFile? ImagePath { get; set; }
        public IFormFile? ImagePathSmall { get; set; }
        public IFormFile? ImagePathMedium { get; set; }
        public IFormFile? ImagePathLarge { get; set; }

        // Existing image paths to show current images
        public string? ExistingImagePath { get; set; }
        public string? ExistingImagePathSmall { get; set; }
        public string? ExistingImagePathMedium { get; set; }
        public string? ExistingImagePathLarge { get; set; }
    }
}

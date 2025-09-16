using System.Numerics;

namespace Hazelnut.Models.ViewModels
{
    public class AllOfOneTypeViewModel
    {
        public required string ProductType { get; set; }
        public required string ProductTypeVietnamese { get; set; }
        public required int TotalProduct { get; set; }
        public IQueryable<ProductBase> Products { get; set; }
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }
		public int TotalPages => (int)Math.Ceiling((double)TotalProduct / PageSize);
	}
}

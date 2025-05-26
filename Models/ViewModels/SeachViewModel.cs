namespace Hazelnut.Models.ViewModels
{
	public class SeachViewModel
	{
		public required IQueryable<ToiletPaper> ToiletPapers { get; set; }
		public required IQueryable<SmallToiletPaper> SmallToiletPapers { get; set; }
		public required IQueryable<Napkin> Napkins { get; set; }
		public required IQueryable<PaperHandkerchiefs> PaperHandkerchiefs { get; set; }
		public required IQueryable<PaperContainer> PaperContainers { get; set; }

		public required int TotalProduct = 0;
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }
		public string Name { get; set; }
		public int TotalPages => (int)Math.Ceiling((double)TotalProduct / PageSize);
	}
}

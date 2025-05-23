namespace Hazelnut.Models.ViewModels
{
    public class IndexViewModel
    {
        public required IQueryable<IndexProductViewModel> ToiletPapers { get; set; }
        public required IQueryable<IndexProductViewModel> SmallToiletPapers { get; set; }
        public required IQueryable<IndexProductViewModel> Napkins { get; set; }
        public required IQueryable<IndexProductViewModel> PaperHandkerchiefs { get; set; }
        public required IQueryable<IndexProductViewModel> PaperContainers { get; set; }
    }
}

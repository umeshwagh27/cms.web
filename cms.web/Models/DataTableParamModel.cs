namespace cms.web.Models
{
    public class DataTableParamModel
    {
        public string? search { get; set; } = string.Empty;
        public int pageSize { get; set; }
        public string? sortDir { get; set; } = string.Empty;
        public int pageNumber { get; set; }
        public string? sortCol { get; set; } = string.Empty;
        public int? totalPage { get; set; }
        public int totalRecords { get; set; }
        public List<CarViewModel> carViewModel { get; set; } = new List<CarViewModel>();
    }
}

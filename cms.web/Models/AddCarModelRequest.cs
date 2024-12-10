namespace cms.web.Models
{
    public class AddCarModelRequest
    {
        public string Brand { get; set; } = default!;
        public string ClassName { get; set; } = default!;
        public string Features { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public List<IFormFile> Images { get; set; }
    }
}

namespace cms.web.Models
{
    public class CarRequestResponse
    {
        public string Brand { get; set; } = default!;
        public string ModelName { get; set; } = default!;
        public string ModelCode { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string DateofManufacturing { get; set; } = default!;
        public string DateofManufacturingString { get; set; } = default!;
    }
}

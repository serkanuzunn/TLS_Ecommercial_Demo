using TLS_Ecommercial_Demo_Core.Dtos;

namespace TLS_Ecommercial_Demo_Entity.Entities.Dtos
{
    public class ProductDto : IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Unit { get; set; }
        public decimal Price { get; set; }
        public int Barcode { get; set; }
    }
}

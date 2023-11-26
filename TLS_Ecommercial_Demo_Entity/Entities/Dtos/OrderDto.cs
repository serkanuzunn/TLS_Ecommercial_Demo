using TLS_Ecommercial_Demo_Core.Dtos;

namespace TLS_Ecommercial_Demo_Entity.Entities.Dtos
{
    public class OrderDto : IDto
    {
        public int OrderId { get; set; }
        public int OrderNo { get; set; }
        public decimal TotalPrice { get; set; }
        public double Tax { get; set; }
        public int DeliveryAddressId { get; set; }
        public int InvoiceAddressId { get; set; }
        public int CustomerId { get; set; }
    }
}

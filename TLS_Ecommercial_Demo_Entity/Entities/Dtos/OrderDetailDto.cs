using TLS_Ecommercial_Demo_Core.Dtos;

namespace TLS_Ecommercial_Demo_Entity.Entities.Dtos
{
    public class OrderDetailDto : IDto
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}

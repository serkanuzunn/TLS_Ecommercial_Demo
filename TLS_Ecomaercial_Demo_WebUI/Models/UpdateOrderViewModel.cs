using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecomaercial_Demo_WebUI.Models
{
    public class UpdateOrderViewModel
    {
        public OrderDto Order { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
        public List<ProductDto> AllProducts { get; set; }
        public List<CustomerAddressDto> CustomerAddressDto { get; set; }


        public OrderDetailDto OrderDetail { get; set; } 

    }
}

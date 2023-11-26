using TLS_Ecommercial_Demo_Core.Dtos;

namespace TLS_Ecommercial_Demo_Entity.Entities.Dtos
{
    public class CustomerAddressDto : IDto
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public string AddressType { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
    }
}

using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecommercial_Demo_Business.Abstract
{
    public interface ICustomerAddressService
    {
        bool AddCustomerAddress(CustomerAddressDto customerAddressDto);
        bool UpdateCustomerAddress(CustomerAddressDto customerAddressDto);
        bool DeleteCustomerAddress(CustomerAddressDto customerAddressDto);
        CustomerAddressDto GetCustomerAddressById(int id);
        List<CustomerAddressDto> GetAllCustomerAddress();
        List<CustomerAddressDto> GetAllCustomerAddressById(int id);

    }
}

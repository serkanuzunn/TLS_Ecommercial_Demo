using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecommercial_Demo_Business.Abstract
{
    public interface ICustomerService
    {
        bool AddCustomer(CustomerDto customerDto);
        bool UpdateCustomer(CustomerDto customerDto);
        bool DeleteCustomer(CustomerDto customerDto);
        CustomerDto GetCustomerById(int id);
        List<CustomerDto> GetAllCustomer();
        
    }
}

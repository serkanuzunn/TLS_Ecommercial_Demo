using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLS_Ecommercial_Demo_Entity.Entities.Concretes;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecommercial_Demo_Business.Abstract
{
    public interface IOueryService
    {
        List<CustomerWithAddressDto> CustomerWithAddress(int id);
        List<OrderDetailsByProductAmountDto> OrderDetailsByProductAmount();
        List<CustomerDto> GetCustomersWithDifferentBillingAndShippingAddresses();
        int IstanbulOrder(string city);
        List<OrderDto> TLSOrders(string customerName);
    }
}

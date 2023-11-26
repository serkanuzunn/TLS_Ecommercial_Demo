using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLS_Ecommercial_Demo_Entity.Entities.Dtos
{
    public class OrderDetailsByProductAmountDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderDetailId { get; set; }
        public int Amount { get; set; }
        public int OrderNo { get; set; }
        public int OrderId { get; set; }
        public string AddressType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLS_Ecommercial_Demo_Core.Entities;

namespace TLS_Ecommercial_Demo_Entity.Entities.Concretes
{
    public class Customer : IEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public bool IsActive { get; set; }

        public List<CustomerAddress> CustomerAddresses { get; set; }
        public List<Order> Orders { get; set; }
    }
}

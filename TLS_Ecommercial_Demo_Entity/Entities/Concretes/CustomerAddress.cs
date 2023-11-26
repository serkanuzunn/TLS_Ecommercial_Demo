using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLS_Ecommercial_Demo_Core.Entities;

namespace TLS_Ecommercial_Demo_Entity.Entities.Concretes
{
    public class CustomerAddress : IEntity
    {
        [Key]
        public int AddressId { get; set; }
        public string AddressType { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
 
        public bool IsActive { get; set; }
    }
}

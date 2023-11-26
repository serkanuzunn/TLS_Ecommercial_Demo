using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLS_Ecommercial_Demo_Core.Dtos;

namespace TLS_Ecommercial_Demo_Entity.Entities.Dtos
{
    public class CustomerDto : IDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}

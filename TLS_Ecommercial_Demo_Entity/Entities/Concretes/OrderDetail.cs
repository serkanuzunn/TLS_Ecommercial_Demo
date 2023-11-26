using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLS_Ecommercial_Demo_Core.Entities;

namespace TLS_Ecommercial_Demo_Entity.Entities.Concretes
{
    public class OrderDetail : IEntity
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public bool IsActive { get; set; }

    }
}

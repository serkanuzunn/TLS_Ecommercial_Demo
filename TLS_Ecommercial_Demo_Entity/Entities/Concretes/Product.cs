using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TLS_Ecommercial_Demo_Core.Entities;

namespace TLS_Ecommercial_Demo_Entity.Entities.Concretes
{
    public class Product : IEntity
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Unit { get; set; }
        public decimal Price { get; set; }
        public int Barcode { get; set; }
        public List<OrderDetail> OrderDetail { get; set; } 

        public bool IsActive { get; set; }
    }
}

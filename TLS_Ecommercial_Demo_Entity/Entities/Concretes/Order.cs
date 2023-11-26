using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLS_Ecommercial_Demo_Core.Entities;

namespace TLS_Ecommercial_Demo_Entity.Entities.Concretes
{
    public class Order : IEntity
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNo { get; set; }
        public decimal TotalPrice { get; set; }
        public double Tax { get; set; }
        public int DeliveryAddressId { get; set; }
        public int InvoiceAddressId { get;set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
        public bool IsActive { get; set; }
    }
}

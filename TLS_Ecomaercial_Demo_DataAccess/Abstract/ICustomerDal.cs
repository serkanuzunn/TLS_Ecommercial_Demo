using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLS_Ecommercial_Demo_Core.DataAccess;
using TLS_Ecommercial_Demo_Entity.Entities.Concretes;

namespace TLS_Ecomaercial_Demo_DataAccess.Abstract
{
    public interface ICustomerDal : IRepositoryBase<Customer>
    {
    }
}

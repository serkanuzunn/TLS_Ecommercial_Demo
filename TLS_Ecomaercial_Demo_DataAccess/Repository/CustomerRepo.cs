using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLS_Ecomaercial_Demo_DataAccess.Abstract;
using TLS_Ecomaercial_Demo_DataAccess.Concrete;
using TLS_Ecommercial_Demo_Core.EntityFremawork;
using TLS_Ecommercial_Demo_Entity.Entities.Concretes;

namespace TLS_Ecomaercial_Demo_DataAccess.Repository
{
    public class CustomerRepo : RepositoryBase<Customer>, ICustomerDal
    {
        public CustomerRepo(Context context) : base(context)
        {

        }
    
    }
}

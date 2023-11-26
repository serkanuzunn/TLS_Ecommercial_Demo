using TLS_Ecomaercial_Demo_DataAccess.Abstract;
using TLS_Ecomaercial_Demo_DataAccess.Concrete;
using TLS_Ecommercial_Demo_Core.EntityFremawork;
using TLS_Ecommercial_Demo_Entity.Entities.Concretes;

namespace TLS_Ecomaercial_Demo_DataAccess.Repository
{
    public class CustomerAddressRepo : RepositoryBase<CustomerAddress>, ICustomerAddressDal
    {
        public CustomerAddressRepo(Context context) : base(context)
        {

        }

    }
}

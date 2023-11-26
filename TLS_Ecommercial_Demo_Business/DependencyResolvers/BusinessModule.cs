using Autofac;
using TLS_Ecomaercial_Demo_DataAccess.Abstract;
using TLS_Ecomaercial_Demo_DataAccess.Repository;
using TLS_Ecommercial_Demo_Business.Abstract;
using TLS_Ecommercial_Demo_Business.Concrete;

namespace TLS_Ecommercial_Demo_Business.DependencyResolvers
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerRepo>().As<ICustomerDal>();
            builder.RegisterType<OrderRepo>().As<IOrderDal>();
            builder.RegisterType<OrderDetailRepo>().As<IOrderDetailDal>();
            builder.RegisterType<ProductRepo>().As<IProductDal>();
            builder.RegisterType<CustomerAddressRepo>().As<ICustomerAddressDal>();

            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<CustomerAddressManager>().As<ICustomerAddressService>();
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>();
            builder.RegisterType<QueryManager>().As<IOueryService>();
            base.Load(builder);
        }
    }
}

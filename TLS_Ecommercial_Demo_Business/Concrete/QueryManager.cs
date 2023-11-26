using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLS_Ecomaercial_Demo_DataAccess.Abstract;
using TLS_Ecommercial_Demo_Business.Abstract;
using TLS_Ecommercial_Demo_Entity.Entities.Concretes;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecommercial_Demo_Business.Concrete
{
    public class QueryManager : IOueryService
    {
        private readonly IMapper _mapper;
        private readonly IOrderDetailDal _orderDetailDal;
        private readonly IOrderDal _orderDal;
        private readonly ICustomerDal _customerDal;
        private readonly ICustomerAddressDal _customerAddressDal;


        public QueryManager(IOrderDetailDal orderDetailDal, IOrderDal orderDal, ICustomerDal customerDal, ICustomerAddressDal customerAddressDal, IMapper mapper)
        {
            _orderDetailDal = orderDetailDal;
            _orderDal = orderDal;
            _customerDal = customerDal;
            _customerAddressDal = customerAddressDal;
            _mapper = mapper;
        }


        public List<CustomerWithAddressDto> CustomerWithAddress(int productId)
        {
            // Verilen ürün ID'sine ait sipariş detaylarını al
            List<OrderDetail> orderDetails = _orderDetailDal.GetAll(x => x.ProductId == productId);

            // Bu sipariş detaylarına ait siparişleri al
            List<Order> orders = _orderDal.GetAll(x => orderDetails.Select(od => od.OrderId).Contains(x.OrderId));

            // Bu siparişlere ait müşterileri al
            List<Customer> customers = _customerDal.GetAll(x => orders.Select(o => o.CustomerId).Contains(x.CustomerId));

            // Bu müşterilere ait adres bilgilerini al
            List<CustomerAddress> customerAddresses = _customerAddressDal.GetAll(x => customers.Select(c => c.CustomerId).Contains(x.CustomerId));

            // CustomerWithAddressDto listesini oluştur
            List<CustomerWithAddressDto> customerWithAddressDtos = customerAddresses
                .Join(customers,
                    ca => ca.CustomerId,
                    c => c.CustomerId,
                    (ca, c) => new { CustomerAddress = ca, Customer = c })
                .Select(x => new CustomerWithAddressDto
                {
                    CustomerId = x.Customer.CustomerId,
                    CustomerName = x.Customer.CustomerName,
                    Address = x.CustomerAddress.Address,
                    City = x.CustomerAddress.City,
                    Country = x.CustomerAddress.Country,
                    Town = x.CustomerAddress.Town
                })
                .ToList();

            return customerWithAddressDtos;
        }

        public List<OrderDetailsByProductAmountDto> OrderDetailsByProductAmount()
        {
            // Get order details with amount greater than 1
            List<OrderDetail> orderDetails = _orderDetailDal.GetAll(x => x.Amount > 1);

            // Extract distinct order IDs from the filtered order details
            List<int> distinctOrderIds = orderDetails.Select(od => od.OrderId).Distinct().ToList();

            // Get orders corresponding to the distinct order IDs
            List<Order> orders = _orderDal.GetAll(x => distinctOrderIds.Contains(x.OrderId));

            // Get customers corresponding to the orders
            List<Customer> customers = _customerDal.GetAll(x => orders.Select(o => o.CustomerId).Contains(x.CustomerId));

            // Create the result list
            List<OrderDetailsByProductAmountDto> orderAmount = new List<OrderDetailsByProductAmountDto>();

            // Iterate through customers
            foreach (var customer in customers)
            {
                // Get orders for the current customer
                var customerOrders = orders.Where(o => o.CustomerId == customer.CustomerId);

                // Iterate through orders
                foreach (var order in customerOrders)
                {
                    // Get order details for the current order
                    var orderDetailsForOrder = orderDetails.Where(od => od.OrderId == order.OrderId);

                    // Iterate through order details
                    foreach (var orderDetail in orderDetailsForOrder)
                    {
                        // Create and add OrderDetailsByProductAmountDto
                        orderAmount.Add(new OrderDetailsByProductAmountDto()
                        {
                            Amount = orderDetail.Amount,
                            CustomerId = customer.CustomerId,
                            CustomerName = customer.CustomerName,
                            OrderDetailId = orderDetail.OrderDetailId,
                            OrderId = orderDetail.OrderId,
                            OrderNo = order.OrderNo,
                            TotalPrice = order.TotalPrice
                        });
                    }
                }
            }

            return orderAmount;
        }


        public List<CustomerDto> GetCustomersWithDifferentBillingAndShippingAddresses()
        {
            List<Order> orders = _orderDal.GetAll();
            List<Order> ordersno = new List<Order>();
           
            foreach (var order in orders)
            {
                if (order.DeliveryAddressId != order.InvoiceAddressId)
                {
                    ordersno.Add(order);
                }
            }
            List<Customer> customers = new List<Customer>();
            foreach (var order in ordersno)
            {
                Customer customer = _customerDal.Get(x=>x.CustomerId==order.CustomerId);
                if (!customers.Contains(customer))
                {
                    customers.Add(customer);
                }
            }
            List<CustomerDto> customerDtos = new List<CustomerDto>();
            foreach (Customer customer in customers)
            {
                CustomerDto customerDto = _mapper.Map<CustomerDto>(customer);
                customerDtos.Add(customerDto);
            }
            return customerDtos;
            
        }

        public int IstanbulOrder(string city)
        {
            int citycount = 0;
            List<Order> orders = _orderDal.GetAll();
            List<CustomerAddress> customerAddresses = new List<CustomerAddress>();
            CustomerAddress customerAddress = new CustomerAddress();
            foreach (var order in orders)
            {
                customerAddress = _customerAddressDal.Get(x => x.AddressId == order.DeliveryAddressId);
                customerAddresses.Add(customerAddress);
            }
            foreach (var item in customerAddresses)
            {
                if (item != null && item.City != null && item.City.ToLower() == city.ToLower())
                {
                    citycount += 1;
                }
            }
            return citycount;

        }

        public List<OrderDto> TLSOrders(string customerName)
        {
            Customer customer = _customerDal.Get(x=>x.CustomerName.ToLower()==customerName.ToLower());
            List<Order> orders = _orderDal.GetAll(x=>x.CustomerId==customer.CustomerId);
            List<OrderDto> orderDtos = new List<OrderDto>();
            foreach (Order order in orders)
            {
                OrderDto orderDto = _mapper.Map<OrderDto>(order);
                orderDtos.Add(orderDto);
            }
            return orderDtos;

        }
    }
}

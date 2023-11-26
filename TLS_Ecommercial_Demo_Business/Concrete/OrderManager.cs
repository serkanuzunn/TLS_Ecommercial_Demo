using AutoMapper;
using TLS_Ecomaercial_Demo_DataAccess.Abstract;
using TLS_Ecommercial_Demo_Business.Abstract;
using TLS_Ecommercial_Demo_Entity.Entities.Concretes;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecommercial_Demo_Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly IMapper _mapper;

        public OrderManager(IOrderDal orderDal, IMapper mapper)
        {
            _orderDal = orderDal;
            _mapper = mapper;
        }

        public bool AddOrder(OrderDto orderDto)
        {
            Order order = DtoConvert(orderDto);
            order.OrderDate = DateTime.UtcNow;
            int reponse = _orderDal.Add(order);
            return reponse == 0 ? false : true;
        }

        public bool DeleteOrder(OrderDto orderDto)
        {
            Order order = DtoConvert(orderDto);
            int reponse = _orderDal.Delete(order);
            return reponse == 0 ? false : true;
        }

        public List<OrderDto> GetAllOrder()
        {
            List<Order> orders = _orderDal.GetAll();
            List<OrderDto> orderDtos = new List<OrderDto>();
            foreach (Order order in orders)
            {
                OrderDto orderDto = _mapper.Map<OrderDto>(order);
                orderDtos.Add(orderDto);
            }
            return orderDtos;
        }

        public OrderDto GetOrderById(int id)
        {
            Order order = _orderDal.Get(x => x.OrderId == id);
            return _mapper.Map<OrderDto>(order);
        }

        public bool UpdateOrder(OrderDto orderDto)
        {
            Order order = DtoConvert(orderDto);
            int reponse = _orderDal.Update(order);
            return reponse == 0 ? false : true;
        }

        public Order DtoConvert(OrderDto orderDto)
        {
            return _mapper.Map<Order>(orderDto);
        }
    
    }

}

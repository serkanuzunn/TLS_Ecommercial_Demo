using AutoMapper;
using TLS_Ecomaercial_Demo_DataAccess.Abstract;
using TLS_Ecommercial_Demo_Business.Abstract;
using TLS_Ecommercial_Demo_Entity.Entities.Concretes;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecommercial_Demo_Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDal _orderDal;
        private readonly IProductDal _productDal;
        private readonly IOrderDetailDal _orderDetailDal;
        private readonly IMapper _mapper;

        public OrderDetailManager(IOrderDetailDal orderDetailDal, IMapper mapper, IProductDal productDal, IOrderDal orderDal)
        {
            _orderDetailDal = orderDetailDal;
            _mapper = mapper;
            _productDal = productDal;
            _orderDal = orderDal;
        }

        public bool AddOrderDetail(OrderDetailDto orderDetailDto)
        {

            Product product = _productDal.Get(x=>x.ProductId==orderDetailDto.ProductId);
            product.Unit -= orderDetailDto.Amount;
            _productDal.Update(product);
            Order order = _orderDal.Get(x=>x.OrderId==orderDetailDto.OrderId);
            double res = order.Tax / 100;
            decimal decTax = Convert.ToDecimal(res);
            order.TotalPrice = order.TotalPrice + ((orderDetailDto.Amount * product.Price)*(decTax+1));
            _orderDal.Update(order);
            OrderDetail orderDetail = DtoConvert(orderDetailDto);
            int reponse = _orderDetailDal.Add(orderDetail);
            return reponse == 0 ? false : true;
        }

        public bool DeleteOrderDetail(OrderDetailDto orderDetailDto)
        {
            OrderDetail orderDetail = DtoConvert(orderDetailDto);
            int reponse = _orderDetailDal.Delete(orderDetail);
            return reponse == 0 ? false : true;
        }

        public List<OrderDetailDto> GetAllOrderDetail()
        {
            List<OrderDetail> orderDetails = _orderDetailDal.GetAll();
            List<OrderDetailDto> orderDetailDtos = new List<OrderDetailDto>();
            foreach (OrderDetail orderDetail in orderDetails)
            {
                OrderDetailDto orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                orderDetailDtos.Add(orderDetailDto);
            }
            return orderDetailDtos;
        }

        public OrderDetailDto GetOrderDetailById(int id)
        {
            OrderDetail orderDetail = _orderDetailDal.Get(x => x.OrderDetailId == id);
            return _mapper.Map<OrderDetailDto>(orderDetail);
        }

        public List<OrderDetailDto> GetOrderDetailsByOrderId(int id)
        {
            List<OrderDetail> orderDetails = _orderDetailDal.GetAll(x => x.OrderId == id).ToList();
            return _mapper.Map<List<OrderDetailDto>>(orderDetails);
        }

        public bool UpdateOrderDetail(OrderDetailDto orderDetailDto)
        {
            OrderDetail orderDetailCome = _orderDetailDal.Get(x=>x.OrderDetailId==orderDetailDto.OrderDetailId);
            int value = orderDetailDto.Amount - orderDetailCome.Amount;
            Product product = _productDal.Get(x => x.ProductId == orderDetailDto.ProductId);
            product.Unit =product.Unit - (value);
            _productDal.Update(product);
            OrderDetail orderDetail = DtoConvert(orderDetailDto);
            orderDetail.IsActive = true;
            int reponse = _orderDetailDal.Update(orderDetail);
            return reponse == 0 ? false : true;
        }

        public OrderDetail DtoConvert(OrderDetailDto orderDetailDto)
        {
            return _mapper.Map<OrderDetail>(orderDetailDto);
        }


   
    }

}

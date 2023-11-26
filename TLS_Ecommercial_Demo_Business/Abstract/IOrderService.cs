using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecommercial_Demo_Business.Abstract
{
    public interface IOrderService
    {
        bool AddOrder(OrderDto orderDto);
        bool UpdateOrder(OrderDto orderDto);
        bool DeleteOrder(OrderDto orderDto);
        OrderDto GetOrderById(int id);
        List<OrderDto> GetAllOrder();

        //OrderDetailDto GetOrderDetailsByOrderId(int id);
    }
}

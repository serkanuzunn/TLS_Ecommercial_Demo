using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecommercial_Demo_Business.Abstract
{
    public interface IOrderDetailService
    {
        bool AddOrderDetail(OrderDetailDto orderDetailDto);
        bool UpdateOrderDetail(OrderDetailDto orderDetailDto);
        bool DeleteOrderDetail(OrderDetailDto orderDetailDto);
        OrderDetailDto GetOrderDetailById(int id);
        List<OrderDetailDto> GetAllOrderDetail();
        List<OrderDetailDto> GetOrderDetailsByOrderId(int id);
    }
}

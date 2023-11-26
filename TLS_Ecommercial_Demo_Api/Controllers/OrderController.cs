using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TLS_Ecommercial_Demo_Business.Abstract;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecommercial_Demo_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            OrderDto orderDto = _orderService.GetOrderById(id);
            return Ok(orderDto);
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<OrderDto> orderDto = _orderService.GetAllOrder();
            return Ok(orderDto);
        }
        [HttpPost]
        public IActionResult Add(OrderDto orderDto)
        {
            bool res = _orderService.AddOrder(orderDto);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, OrderDto updatedOrderDto)
        {
            OrderDto existingOrderDto = _orderService.GetOrderById(id);

            if (existingOrderDto == null)
            {
                return NotFound("Order not found.");
            }

            existingOrderDto.TotalPrice = updatedOrderDto.TotalPrice;
            existingOrderDto.Tax = updatedOrderDto.Tax;
            existingOrderDto.OrderNo = updatedOrderDto.OrderNo;
            existingOrderDto.DeliveryAddressId = updatedOrderDto.DeliveryAddressId;
            existingOrderDto.InvoiceAddressId = updatedOrderDto.InvoiceAddressId;
            existingOrderDto.CustomerId = updatedOrderDto.CustomerId;
            bool isUpdated = _orderService.UpdateOrder(existingOrderDto);

            if (isUpdated)
            {
                return Ok("Order updated successfully.");
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update order.");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            OrderDto orderDto = _orderService.GetOrderById(id);
            bool response = _orderService.DeleteOrder(orderDto);
            return Ok(response);
        }
    }
}


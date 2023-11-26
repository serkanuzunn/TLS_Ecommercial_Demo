using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TLS_Ecommercial_Demo_Business.Abstract;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecommercial_Demo_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService, IProductService productService)
        {
            _orderDetailService = orderDetailService;
            _productService = productService;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            OrderDetailDto orderDetailDto = _orderDetailService.GetOrderDetailById(id);
            return Ok(orderDetailDto);
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<OrderDetailDto> orderDetailDto = _orderDetailService.GetAllOrderDetail();
            return Ok(orderDetailDto);
        }
        [HttpPost]
        public IActionResult Add(OrderDetailDto orderDetailDto)
        {
            ProductDto productDto = _productService.GetProductById(orderDetailDto.ProductId);   
            if (productDto.Unit >= orderDetailDto.Amount)
            {
                bool res = _orderDetailService.AddOrderDetail(orderDetailDto);
                return Ok(res);
            }
            bool ress = _orderDetailService.AddOrderDetail(orderDetailDto);
            return BadRequest("Not enough units in stock");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, OrderDetailDto updatedOrderDetailDto)
        {
            OrderDetailDto existingOrderDetailDto = _orderDetailService.GetOrderDetailById(id);

            if (existingOrderDetailDto == null)
            {
                return NotFound("Order detail not found.");
            }

            existingOrderDetailDto.OrderId = updatedOrderDetailDto.OrderId;
            existingOrderDetailDto.ProductId = updatedOrderDetailDto.ProductId;
            existingOrderDetailDto.Amount = updatedOrderDetailDto.Amount;
            bool isUpdated = _orderDetailService.UpdateOrderDetail(existingOrderDetailDto);

            if (isUpdated)
            {
                return Ok("Order detail updated successfully.");
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update order detail.");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            OrderDetailDto orderDetailDto = _orderDetailService.GetOrderDetailById(id);
            bool response = _orderDetailService.DeleteOrderDetail(orderDetailDto);
            return Ok(response);
        }
    }
}


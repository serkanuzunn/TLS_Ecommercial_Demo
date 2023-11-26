using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TLS_Ecommercial_Demo_Business.Abstract;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecommercial_Demo_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private readonly IOueryService _oueryService;

        public QueryController(IOueryService oueryService)
        {
            _oueryService = oueryService;
        }
        [HttpGet("CustomerOrders")]
        public IActionResult Get(int id)
        {
            List<CustomerWithAddressDto> customerWithAddressDtos = _oueryService.CustomerWithAddress(id);
            return Ok(customerWithAddressDtos);
        }
        [HttpGet("OrderDetailByAmount")]
        public IActionResult Get()
        {
            List<OrderDetailsByProductAmountDto> orderDetails = _oueryService.OrderDetailsByProductAmount();
            return Ok(orderDetails);
        }
        [HttpGet("DifferentAddress")]
        public IActionResult DifferentAddress()
        {
            List<CustomerDto> customerDtos = _oueryService.GetCustomersWithDifferentBillingAndShippingAddresses();
            return Ok(customerDtos);
        }
        [HttpGet("IstanbulOrderCount")]
        public IActionResult IstanbulOrder(string city)
        {
            int citycount = _oueryService.IstanbulOrder(city);
            return Ok(citycount);
        }
        [HttpGet("TLSOrders")]
        public IActionResult TLSOrders(string company)
        {
            List<OrderDto> orderDtos = _oueryService.TLSOrders(company);
            return Ok(orderDtos);
        }
    }
}

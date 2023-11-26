using Microsoft.AspNetCore.Mvc;
using TLS_Ecommercial_Demo_Business.Abstract;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecomaercial_Demo_WebUI.Controllers
{
    public class QueryController : Controller
    {

        public readonly IOrderService _orderService;
        public readonly IOrderDetailService _orderDetailService;
        public readonly IProductService _productService;
        public readonly ICustomerService _customerService;
        public readonly ICustomerAddressService _customerAdressService;
        public readonly IOueryService _oueryService;


        public QueryController(IOrderService orderService, IOrderDetailService orderDetailService, IProductService productService, ICustomerAddressService customerAddressService, ICustomerService customerService, IOueryService oueryService)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _productService = productService;
            _customerAdressService = customerAddressService;
            _customerService = customerService;
            _oueryService = oueryService;
        }
        public IActionResult CustomerOrders(int id)
        {
            List<CustomerWithAddressDto> customerWithAddressDto = _oueryService.CustomerWithAddress(id);
            return View(customerWithAddressDto);
        }
        public IActionResult OrderDetailByAmount()
        {
            List<OrderDetailsByProductAmountDto> orderDetails = _oueryService.OrderDetailsByProductAmount();
            return View(orderDetails);
        }
        public IActionResult DifferentAddress()
        {
            List<CustomerDto> customerDtos = _oueryService.GetCustomersWithDifferentBillingAndShippingAddresses();
            return View(customerDtos);
        }
        [HttpGet]
        public IActionResult IstanbulOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IstanbulOrder(string city)
        {
            int citycount = _oueryService.IstanbulOrder(city);
            ViewBag.CityCount = citycount;
            return View();
        }


        [HttpGet]
        public IActionResult TLSOrders()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TLSOrders(string company)
        {
            List<OrderDto> orderDtos = _oueryService.TLSOrders(company);
            ViewBag.Company = company;
            return View(orderDtos);
        }
    }
}

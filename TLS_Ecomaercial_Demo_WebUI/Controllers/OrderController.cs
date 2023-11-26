using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using TLS_Ecomaercial_Demo_WebUI.Models;
using TLS_Ecommercial_Demo_Business.Abstract;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecomaercial_Demo_WebUI.Controllers
{
    public class OrderController : Controller
    {
        public readonly IOrderService _orderService;
        public readonly IOrderDetailService _orderDetailService;
        public readonly IProductService _productService;
        public readonly ICustomerService _customerService;
        public readonly ICustomerAddressService _customerAdressService;


        public OrderController(IOrderService orderService, IOrderDetailService orderDetailService, IProductService productService, ICustomerAddressService customerAddressService, ICustomerService customerService)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _productService = productService;
            _customerAdressService = customerAddressService;
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            List<OrderDto> orders = _orderService.GetAllOrder();
            return View(orders);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(OrderDto orderDto)
        {
            bool res = _orderService.AddOrder(orderDto);
            return res ? RedirectToAction("index") : View(orderDto);
        }
        

        [HttpGet]
        public IActionResult Update(int id)
        {
            OrderDto orderDto = _orderService.GetOrderById(id);
            List<CustomerAddressDto> CustomerAddressDto = _customerAdressService.GetAllCustomerAddressById(orderDto.CustomerId);
            CustomerDto customerDto = _customerService.GetCustomerById(orderDto.CustomerId);
            ViewBag.Name = customerDto.CustomerName;
            List<OrderDetailDto> orderDetails = _orderDetailService.GetOrderDetailsByOrderId(id);
            List<ProductDto> allProducts = _productService.GetAllProduct();
            UpdateOrderViewModel updateOrderViewModel = new UpdateOrderViewModel
            {
                Order = orderDto,
                OrderDetails = orderDetails,
                AllProducts = allProducts,
                CustomerAddressDto = CustomerAddressDto
            };
            return View(updateOrderViewModel);
        }
        [HttpPost]
        public IActionResult Update(OrderDto orderDto)
        {

            bool res = _orderService.UpdateOrder(orderDto);
            return res ? RedirectToAction("index") : View(orderDto);
        }

        [HttpGet]
        public IActionResult OrderDetailUpdate(int id)
        {
            OrderDetailDto orderDetail = _orderDetailService.GetOrderDetailById(id);
            List<ProductDto> allProducts = _productService.GetAllProduct();

            UpdateOrderViewModel updateOrderViewModel = new UpdateOrderViewModel
            {
                OrderDetail = orderDetail,
                AllProducts = allProducts
            };
            return View(updateOrderViewModel);
        }
        [HttpPost]
        public IActionResult OrderDetailUpdate(OrderDetailDto orderDetailDto)
        {
            bool res = _orderDetailService.UpdateOrderDetail(orderDetailDto);
            return res ? RedirectToAction("index") : View(orderDetailDto);
        }

        public IActionResult Delete(int id)
        {
            OrderDto orderDto = _orderService.GetOrderById(id);
            bool res = _orderService.DeleteOrder(orderDto);
            return RedirectToAction("index");
        }

        public IActionResult OrderDetailDelete(int id)
        {
            OrderDetailDto orderDetailDto = _orderDetailService.GetOrderDetailById(id);
            bool res = _orderDetailService.DeleteOrderDetail(orderDetailDto);
            return RedirectToAction("index");
        }
        public IActionResult OrderDetailAdd(OrderDetailDto orderDetailDto)
        {
            bool res = _orderDetailService.AddOrderDetail(orderDetailDto);
            return res ? RedirectToAction("index") : View(orderDetailDto);
        }
    }
}

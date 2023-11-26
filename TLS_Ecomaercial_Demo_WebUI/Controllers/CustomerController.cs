using Microsoft.AspNetCore.Mvc;
using TLS_Ecommercial_Demo_Business.Abstract;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecomaercial_Demo_WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerAddressService _customerAddressService;


        public CustomerController(ICustomerService customerService, ICustomerAddressService customerAddressService)
        {
            _customerService = customerService;
            _customerAddressService = customerAddressService;
        }

        public IActionResult Index()
        {
            List<CustomerDto> customerDtos = _customerService.GetAllCustomer();

            return View(customerDtos);
        }

        public IActionResult Add(CustomerDto customerDto)
        {
            bool res = _customerService.AddCustomer(customerDto);
            return res ? RedirectToAction("index") : View(customerDto);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            CustomerDto customerDto = _customerService.GetCustomerById(id);
            return View(customerDto);
        }
        [HttpPost]
        public IActionResult Update(CustomerDto customerDto)
        {

            bool res = _customerService.UpdateCustomer(customerDto);
            return res ? RedirectToAction("index") : View(customerDto);
        }
        public IActionResult Delete(int id)
        {
            CustomerDto customerDto = _customerService.GetCustomerById(id);
            bool res = _customerService.DeleteCustomer(customerDto);
            return RedirectToAction("index");
        }
        public IActionResult CustomerAddress(int id)
        {
            List<CustomerAddressDto> customerAddressDtos = _customerAddressService.GetAllCustomerAddressById(id);
            return View(customerAddressDtos);
        }
    }
}

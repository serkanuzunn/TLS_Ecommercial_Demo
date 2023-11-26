using Microsoft.AspNetCore.Mvc;
using TLS_Ecommercial_Demo_Business.Abstract;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecomaercial_Demo_WebUI.Controllers
{
    public class CustomerAddressController : Controller
    {
        private readonly ICustomerAddressService _customerAddressService;

        public CustomerAddressController(ICustomerAddressService customerAddressService)
        {
            _customerAddressService = customerAddressService;
            
        }
        public IActionResult Add(CustomerAddressDto customerAddressDto)
        {
            _customerAddressService.AddCustomerAddress(customerAddressDto);
            return RedirectToAction("CustomerAddress", "Customer", new { id = customerAddressDto.CustomerId });
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            CustomerAddressDto customerAddressDto = _customerAddressService.GetCustomerAddressById(id);
            return View(customerAddressDto);
        }
        [HttpPost]
        public IActionResult Update(CustomerAddressDto customerAddressDto)
        {
           bool res = _customerAddressService.UpdateCustomerAddress(customerAddressDto);

            return res ? RedirectToAction("CustomerAddress", "Customer",new {id=customerAddressDto.CustomerId}) : View(customerAddressDto);
        }
        public IActionResult Delete(int id)
        {
            CustomerAddressDto customerAddressDto = _customerAddressService.GetCustomerAddressById(id);
            _customerAddressService.DeleteCustomerAddress(customerAddressDto);
            return RedirectToAction("CustomerAddress", "Customer", new { id = customerAddressDto.CustomerId });
        }
    }
}

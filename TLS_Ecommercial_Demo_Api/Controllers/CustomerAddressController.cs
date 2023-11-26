using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TLS_Ecommercial_Demo_Business.Abstract;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecommercial_Demo_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressController : ControllerBase
    {
        private readonly ICustomerAddressService _customerAddressService;

        public CustomerAddressController(ICustomerAddressService customerAddressService)
        {
            _customerAddressService = customerAddressService;
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            CustomerAddressDto customerAddressDto = _customerAddressService.GetCustomerAddressById(id);
            return Ok(customerAddressDto);
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<CustomerAddressDto> customerAddressDto = _customerAddressService.GetAllCustomerAddress();
            return Ok(customerAddressDto);
        }
        [HttpPost]
        public IActionResult Add(CustomerAddressDto customerAddressDto)
        {
            bool res = _customerAddressService.AddCustomerAddress(customerAddressDto);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CustomerAddressDto updatedCustomerAddressDto)
        {
            CustomerAddressDto existingCustomerAddressDto = _customerAddressService.GetCustomerAddressById(id);

            if (existingCustomerAddressDto == null)
            {
                return NotFound("Customer Address not found.");
            }

             existingCustomerAddressDto.AddressType = updatedCustomerAddressDto.AddressType;
            existingCustomerAddressDto.Country = updatedCustomerAddressDto.Country;
            existingCustomerAddressDto.City = updatedCustomerAddressDto.City;
            existingCustomerAddressDto.Town = updatedCustomerAddressDto.Town;
            existingCustomerAddressDto.Address = updatedCustomerAddressDto.Address;
            existingCustomerAddressDto.Email = updatedCustomerAddressDto.Email;
            existingCustomerAddressDto.Phone = updatedCustomerAddressDto.Phone;
            existingCustomerAddressDto.PostalCode = updatedCustomerAddressDto.PostalCode;

             bool isUpdated = _customerAddressService.UpdateCustomerAddress(existingCustomerAddressDto);

            if (isUpdated)
            {
                return Ok("Customer Address updated successfully.");
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update customer address.");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            CustomerAddressDto customerAddressDto = _customerAddressService.GetCustomerAddressById(id);
            bool response = _customerAddressService.DeleteCustomerAddress(customerAddressDto);
            return Ok(response);
        }
    }
}

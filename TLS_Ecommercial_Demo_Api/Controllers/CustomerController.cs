using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TLS_Ecommercial_Demo_Business.Abstract;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecommercial_Demo_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("{id}")]
        public  IActionResult Get(int id)
        {
            CustomerDto customerDto =  _customerService.GetCustomerById(id);
            return Ok(customerDto);
        }
        [HttpGet]
        public  IActionResult Get()
        {
            List<CustomerDto> customerDtos =  _customerService.GetAllCustomer();
            return Ok(customerDtos);
        }
        [HttpPost]
        public IActionResult Add(CustomerDto customerDto)
        {
            bool res =_customerService.AddCustomer(customerDto);
            return Ok(res);
        }
        //[HttpPut]
        //public IActionResult Update(CustomerDto customerDto)
        //{
        //    CustomerDto customerDto1= _customerService.GetCustomerById(customerDto.CustomerId);
        //    customerDto1.CustomerName = customerDto.CustomerName;
        //    bool res =  _customerService.UpdateCustomer(customerDto1);
        //    return Ok(res);
        //}

        [HttpPut("{id}")]
        public IActionResult Update(int id, CustomerDto updatedCustomerDto)
        {
            if (id != updatedCustomerDto.CustomerId)
            {
                return BadRequest("ID in the request body doesn't match the ID in the URL.");
            }

            CustomerDto existingCustomerDto = _customerService.GetCustomerById(id);

            if (existingCustomerDto == null)
            {
                return NotFound("Customer not found.");
            }

            existingCustomerDto.CustomerName = updatedCustomerDto.CustomerName;
            bool isUpdated = _customerService.UpdateCustomer(existingCustomerDto);

            if (isUpdated)
            {
                return Ok("Customer updated successfully.");
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update customer.");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            CustomerDto customerDto = _customerService.GetCustomerById(id);
            bool response =  _customerService.DeleteCustomer(customerDto);
            return Ok(response);
        }
    }
}

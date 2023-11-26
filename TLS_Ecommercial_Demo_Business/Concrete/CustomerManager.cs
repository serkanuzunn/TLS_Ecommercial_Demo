using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLS_Ecomaercial_Demo_DataAccess.Abstract;
using TLS_Ecommercial_Demo_Business.Abstract;
using TLS_Ecommercial_Demo_Entity.Entities.Concretes;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecommercial_Demo_Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IMapper _mapper;

        public CustomerManager(ICustomerDal about, IMapper mapper)
        {
            _customerDal = about;
            _mapper = mapper;
        }

        public bool AddCustomer(CustomerDto customerDto)
        {
            Customer customer = DtoConvert(customerDto);
            int reponse = _customerDal.Add(customer);
            return reponse == 0 ? false : true;
        }

        public bool DeleteCustomer(CustomerDto customerDto)
        {
            Customer customer = DtoConvert(customerDto);
            int reponse = _customerDal.Delete(customer);
            return reponse == 0 ? false : true;
        }

        public List<CustomerDto> GetAllCustomer()
        {
            List<Customer> customers = _customerDal.GetAll();
            List<CustomerDto> customerDtos = new List<CustomerDto>();
            foreach (Customer customer in customers)
            {
                CustomerDto customerDto = _mapper.Map<CustomerDto>(customer);
                customerDtos.Add(customerDto);
            }
            return customerDtos;
        }

        public CustomerDto GetCustomerById(int id)
        {
            Customer customer = _customerDal.Get(x => x.CustomerId == id);
            return _mapper.Map<CustomerDto>(customer);
        }

        public bool UpdateCustomer(CustomerDto customerDto)
        {
            Customer customer = DtoConvert(customerDto);
            customer.IsActive = true;
            int reponse = _customerDal.Update(customer);
            return reponse == 0 ? false : true;
        }

        public Customer DtoConvert(CustomerDto customerDto)
        {
            return _mapper.Map<Customer>(customerDto);
        }
    }

}

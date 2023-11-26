using AutoMapper;
using TLS_Ecomaercial_Demo_DataAccess.Abstract;
using TLS_Ecommercial_Demo_Business.Abstract;
using TLS_Ecommercial_Demo_Entity.Entities.Concretes;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecommercial_Demo_Business.Concrete
{
    public class CustomerAddressManager : ICustomerAddressService
    {
        private readonly ICustomerAddressDal _customerAddressDal;
        private readonly IMapper _mapper;

        public CustomerAddressManager(ICustomerAddressDal customerAddress, IMapper mapper)
        {
            _customerAddressDal = customerAddress;
            _mapper = mapper;
        }

        public bool AddCustomerAddress(CustomerAddressDto customerAddressDto)
        {
            CustomerAddress customerAddress = DtoConvert(customerAddressDto);
            int reponse = _customerAddressDal.Add(customerAddress);
            return reponse == 0 ? false : true;
        }

        public bool DeleteCustomerAddress(CustomerAddressDto customerAddressDto)
        {
            CustomerAddress customerAddress = DtoConvert(customerAddressDto);
            int reponse = _customerAddressDal.Delete(customerAddress);
            return reponse == 0 ? false : true;
        }

        public List<CustomerAddressDto> GetAllCustomerAddress()
        {
            List<CustomerAddress> customerAdresses = _customerAddressDal.GetAll();
            List<CustomerAddressDto> customerAddressDtos = new List<CustomerAddressDto>();
            foreach (CustomerAddress customerAddress in customerAdresses)
            {
                CustomerAddressDto customerAddressDto = _mapper.Map<CustomerAddressDto>(customerAddress);
                customerAddressDtos.Add(customerAddressDto);
            }
            return customerAddressDtos;
        }

        public CustomerAddressDto GetCustomerAddressById(int id)
        {
            CustomerAddress customerAddress = _customerAddressDal.Get(x => x.AddressId == id);
            return _mapper.Map<CustomerAddressDto>(customerAddress);
        }

        public bool UpdateCustomerAddress(CustomerAddressDto customerAddressDto)
        {
            CustomerAddress customerAddress = DtoConvert(customerAddressDto);
            customerAddress.IsActive = true;
            int reponse = _customerAddressDal.Update(customerAddress);
            return reponse == 0 ? false : true;
        }
        public List<CustomerAddressDto> GetAllCustomerAddressById(int id)
        {
            List<CustomerAddress> customerAdresses = _customerAddressDal.GetAll(x=>x.CustomerId==id);
            List<CustomerAddressDto> customerAddressDtos = new List<CustomerAddressDto>();
            foreach (CustomerAddress customerAddress in customerAdresses)
            {
                CustomerAddressDto customerAddressDto = _mapper.Map<CustomerAddressDto>(customerAddress);
                customerAddressDtos.Add(customerAddressDto);
            }
            return customerAddressDtos;
        }
        public CustomerAddress DtoConvert(CustomerAddressDto customerAddressDto)
        {
            return _mapper.Map<CustomerAddress>(customerAddressDto);
        }


    }

}

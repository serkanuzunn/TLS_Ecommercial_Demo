using AutoMapper;
using TLS_Ecomaercial_Demo_DataAccess.Abstract;
using TLS_Ecommercial_Demo_Business.Abstract;
using TLS_Ecommercial_Demo_Entity.Entities.Concretes;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecommercial_Demo_Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public bool AddProduct(ProductDto productDto)
        {
            Product product = DtoConvert(productDto);
            int reponse = _productDal.Add(product);
            return reponse == 0 ? false : true;
        }

        public bool DeleteProduct(ProductDto productDto)
        {
            Product product = DtoConvert(productDto);
            int reponse = _productDal.Delete(product);
            return reponse == 0 ? false : true;
        }

        public List<ProductDto> GetAllProduct()
        {
            List<Product> products = _productDal.GetAll();
            List<ProductDto> productDtos = new List<ProductDto>();
            foreach (Product product in products)
            {
                ProductDto productDto = _mapper.Map<ProductDto>(product);
                productDtos.Add(productDto);
            }
            return productDtos;
        }

        public ProductDto GetProductById(int id)
        {
            Product product = _productDal.Get(x => x.ProductId == id);
            return _mapper.Map<ProductDto>(product);
        }

        public bool UpdateProduct(ProductDto productDto)
        {
            Product product = DtoConvert(productDto);
            product.IsActive = true;    
            int reponse = _productDal.Update(product);
            return reponse == 0 ? false : true;
        }

        public Product DtoConvert(ProductDto productDto)
        {
            return _mapper.Map<Product>(productDto);
        }
    
    
    }

}

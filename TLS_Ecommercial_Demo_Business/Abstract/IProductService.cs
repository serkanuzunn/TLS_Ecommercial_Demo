using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecommercial_Demo_Business.Abstract
{
    public interface IProductService
    {
        bool AddProduct(ProductDto productDto);
        bool UpdateProduct(ProductDto productDto);
        bool DeleteProduct(ProductDto productDto);
        ProductDto GetProductById(int id);
        List<ProductDto> GetAllProduct();
    }
}

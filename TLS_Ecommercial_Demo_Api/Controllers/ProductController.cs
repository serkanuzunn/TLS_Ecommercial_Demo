using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TLS_Ecommercial_Demo_Business.Abstract;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecommercial_Demo_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ProductDto productDto = _productService.GetProductById(id);
            return Ok(productDto);
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<ProductDto> productDto = _productService.GetAllProduct();
            return Ok(productDto);
        }
        [HttpPost]
        public IActionResult Add(ProductDto productDto)
        {
            bool res = _productService.AddProduct(productDto);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductDto updatedProductDto)
        {
            ProductDto existingProductDto = _productService.GetProductById(id);

            if (existingProductDto == null)
            {
                return NotFound("Product not found.");
            }

            existingProductDto.ProductName = updatedProductDto.ProductName;
            existingProductDto.Unit = updatedProductDto.Unit;
            existingProductDto.Price = updatedProductDto.Price;
            existingProductDto.Barcode = updatedProductDto.Barcode;
            bool isUpdated = _productService.UpdateProduct(existingProductDto);

            if (isUpdated)
            {
                return Ok("Product updated successfully.");
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update product.");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ProductDto productDto = _productService.GetProductById(id);
            bool response = _productService.DeleteProduct(productDto);
            return Ok(response);
        }
    }
}

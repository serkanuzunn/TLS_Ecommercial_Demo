using Microsoft.AspNetCore.Mvc;
using TLS_Ecommercial_Demo_Business.Abstract;
using TLS_Ecommercial_Demo_Entity.Entities.Dtos;

namespace TLS_Ecomaercial_Demo_WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            List<ProductDto> products = _productService.GetAllProduct();
            return View(products);
        }
        public IActionResult Add(ProductDto productDto)
        {
            bool res= _productService.AddProduct(productDto);
            return res ? RedirectToAction("index") : View(productDto);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ProductDto productDto = _productService.GetProductById(id);
            return View(productDto);
        }
        [HttpPost]
        public IActionResult Update(ProductDto productDto)
        {
           
            bool res = _productService.UpdateProduct(productDto);
            return res ? RedirectToAction("index") : View(productDto);
        }
        public IActionResult Delete(int id)
        {
            ProductDto productDto = _productService.GetProductById(id);
            bool res = _productService.DeleteProduct(productDto);
            return RedirectToAction("index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using NLayerCore.Servicess;

namespace NLayer.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetProductWithCategory());
        }
    }
}

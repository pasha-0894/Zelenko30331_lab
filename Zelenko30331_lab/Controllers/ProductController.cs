using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zelenko30331_lab.Services;

namespace Zelenko30331_lab.Controllers
{
    public class ProductController(IProductService productService, ICategoryService categoryService) : Controller
    {
        [Route("Asset")]
        [Route("Asset/{category}")]
        public async Task<IActionResult> Index(string? category, int pageNo = 1)
        {
            // получить список категорий
            var categoriesResponse = await
            categoryService.GetCategoryListAsync();
            // если список не получен, вернуть код 404
            if (!categoriesResponse.Success)
                return NotFound(categoriesResponse.ErrorMessage);
            // передать список категорий во ViewData
            ViewData["categories"] = categoriesResponse.Data;
            // передать во ViewData имя текущей категории
            var currentCategory = category == "Все" ? "Все" : categoriesResponse.Data.FirstOrDefault(c => c.NormalizedName == category)?.Name;
            if (currentCategory == null) currentCategory = "Все";
            ViewData["currentCategory"] = currentCategory;
            var productResponse =
            await
            productService.GetProductListAsync(category, pageNo);
            if (!productResponse.Success)
                ViewData["Error"] = productResponse.ErrorMessage;
            return View(productResponse.Data);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Zelenko30331_lab.Components
{
    public class CartViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default");
        }
    }
}

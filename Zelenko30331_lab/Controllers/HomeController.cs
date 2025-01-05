using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zelenko30331_lab.ViewModels;
using Zelenko30331_lab.Models;

namespace Zelenko30331_lab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["LabTitle"] = "������������ ������ 2";
            var items = new List<ListDemo>
    {
        new ListDemo { Id = 1, Name = "������� 1" },
        new ListDemo { Id = 2, Name = "������� 2" },
        new ListDemo { Id = 3, Name = "������� 3" }
    };

            var selectList = new SelectList(items, "Id", "Name");

            var model = new ListDemoViewModel
            {
                Items = selectList
            };
            return View(model);
        }
    }
}

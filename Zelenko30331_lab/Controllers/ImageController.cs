using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Zelenko30331_lab.Data;
using System.Security.Claims;

namespace Zelenko30331_lab.Controllers
{
    public class ImageController(UserManager<ApplicationUser> userManager) : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public async Task<IActionResult> GetAvatar()
        {
            var email = User.FindFirst(ClaimTypes.Email)!.Value;
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            if (user.Avatar.Length != 0)
                return File(user.Avatar, user.MimeType);
            var imagePath = Path.Combine("Images", "def.png");
            return File(imagePath, "image/png");
        }
    }
}

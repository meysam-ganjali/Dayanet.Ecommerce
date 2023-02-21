using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dayanet.Ecommerce.Endpoint.Areas.Admin.Controllers {
    [Area("Admin")]
    [Authorize(Roles = SD.Admin)]
    public class HomeController : Controller {
        public async Task<IActionResult> Index() {
            return View();
        }
    }
}

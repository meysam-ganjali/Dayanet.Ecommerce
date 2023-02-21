using Dayanet.Ecommerce.Application.FASADE.Banner;
using Dayanet.Ecommerce.Application.Services.Repository.Possition;
using Dayanet.Ecommerce.SharedModels.Dtos.Possition;
using Dayanet.Ecommerce.SharedModels.Dtos.Banner;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Dayanet.Ecommerce.Endpoint.Areas.Admin.Controllers.Common {
    [Area("Admin")]
    [Authorize(Roles = SD.Admin)]
    public class BannersController : Controller {
        private readonly IBannerFasade _bannerService;
        private readonly IPossitionRepository _possitionRepository;

        public BannersController(IBannerFasade bannerService, IPossitionRepository possitionRepository) {
            _bannerService = bannerService;
            _possitionRepository = possitionRepository;
        }
        public async Task<IActionResult> Index() {
            var Possition = await _possitionRepository.GetAllAsync();
            ViewBag.Possition = new SelectList(Possition, "Id", $"PossitionNameFA");
            var model = await _bannerService.FetchBanner.GetAllAsync();
            return View(model.Data);
        }

        public async Task<IActionResult> CreateBanner() {
            var Possition = await _possitionRepository.GetAllAsync();
            ViewBag.Possition = new SelectList(Possition, "Id", $"PossitionNameFA");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto Banner) {
            var Image = HttpContext.Request.Form.Files;
            Banner.Image = Image[0];
            var result = await _bannerService.CreateBanner.CreateAsync(Banner);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Banners/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Banners/Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePossition(CreatePossitionDto possitionDto) {
            var result = await _possitionRepository.CreateAsync(possitionDto);
            return Redirect("/Admin/Banners/CreateBanner");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBanner(int id) {
            var result = await _bannerService.RemoveBanner.RemoveAsync(id);
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto Banner) {
            var Image = HttpContext.Request.Form.Files;
            if (Image != null) {
                Banner.Image = Image[0];
            }

            var result = await _bannerService.UpdateBanner.UpdateAsync(Banner);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Banners/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Banners/Index");
        }
    }
}

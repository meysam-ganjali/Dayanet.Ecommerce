using Dayanet.Ecommerce.Application.FASADE.Slider;
using Dayanet.Ecommerce.Application.Services.Repository.Possition;
using Dayanet.Ecommerce.SharedModels.Dtos.Possition;
using Dayanet.Ecommerce.SharedModels.Dtos.Slider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dayanet.Ecommerce.Endpoint.Areas.Admin.Controllers.Common {
    [Area("Admin")]
    [Authorize(Roles = SD.Admin)]
    public class SlidersController : Controller {
        private readonly ISliderFasade _sliderService;
        private readonly IPossitionRepository _possitionRepository;

        public SlidersController(ISliderFasade sliderService, IPossitionRepository possitionRepository) {
            _sliderService = sliderService;
            _possitionRepository = possitionRepository;
        }
        public async Task<IActionResult> Index() {
            var Possition = await _possitionRepository.GetAllAsync();
            ViewBag.Possition = new SelectList(Possition, "Id", $"PossitionNameFA");
            var model = await _sliderService.FetchSlider.GetAllAsync();
            return View(model.Data);
        }

        public async Task<IActionResult> CreateSlider() {
            var Possition = await _possitionRepository.GetAllAsync();
            ViewBag.Possition = new SelectList(Possition, "Id", $"PossitionNameFA");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto slider) {
            var Image = HttpContext.Request.Form.Files;
            slider.Image = Image[0];
            var result = await _sliderService.CreateSlider.CreateAsync(slider);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Sliders/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Sliders/Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePossition(CreatePossitionDto possitionDto) {
            var result = await _possitionRepository.CreateAsync(possitionDto);
            return Redirect("/Admin/Sliders/CreateSlider");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSlider(int id) {
            var result = await _sliderService.RemoveSlider.RemoveAsync(id);
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto slider) {
            var Image = HttpContext.Request.Form.Files;
            if (Image != null) {
                slider.Image = Image[0];
            }

            var result = await _sliderService.UpdateSlider.UpdateAsync(slider);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Sliders/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Sliders/Index");
        }
    }
}

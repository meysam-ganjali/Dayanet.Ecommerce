using Dayanet.Ecommerce.Application.FASADE.CategoryAttribute;
using Dayanet.Ecommerce.SharedModels.Dtos.CategoryAttribute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dayanet.Ecommerce.Endpoint.Areas.Admin.Controllers.Shopping {
    [Area("Admin")]
    [Authorize(Roles = SD.Admin)]
    public class CategoryAttributesController : Controller {
        private readonly ICategoryAttributeFasade _categoryAttributeService;

        public CategoryAttributesController(ICategoryAttributeFasade categoryAttributeService) {
            _categoryAttributeService = categoryAttributeService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? filter) {
            var model = await _categoryAttributeService.FetchCategoryAttribute.GetAllAsync(filter);
            return View(model.Data);
        }
        [HttpGet]
        public async Task<IActionResult> CategoryAttributeIndex(int id)
        {
            ViewBag.CategoryId = id;
            var model = await _categoryAttributeService.FetchCategoryAttributeById.GetAsync(id);
            return View(model.Data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategoryAttributes(CreateCategoryAttributeDto attr) {
            if (string.IsNullOrWhiteSpace(attr.AttributeName)) {
                TempData["error"] = "عنوان مشخصه را وارد نکردید";
                return Redirect($"/Admin/CategoryAttributes/CategoryAttributeIndex/{attr.CategoryId}");
            }

            var result = await _categoryAttributeService.CreateCategoryAttribute.AddAsync(attr);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect($"/Admin/CategoryAttributes/CategoryAttributeIndex/{attr.CategoryId}");
            }

            TempData["error"] = result.Message;
            return Redirect($"/Admin/CategoryAttributes/CategoryAttributeIndex/{attr.CategoryId}");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategoryAttributes(UpdateCategoryAttributeDto attr) {
            if (string.IsNullOrWhiteSpace(attr.AttributeName)) {
                TempData["error"] = "عنوان مشخصه را وارد نکردید";
                return Redirect($"/Admin/CategoryAttributes/CategoryAttributeIndex/{attr.CategoryId}");
            }

            var result = await _categoryAttributeService.UpdateCategoryAttribute.UpdateAsync(attr);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect($"/Admin/CategoryAttributes/CategoryAttributeIndex/{attr.CategoryId}");
            }

            TempData["error"] = result.Message;
            return Redirect($"/Admin/CategoryAttributes/CategoryAttributeIndex/{attr.CategoryId}");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategoryAttributes(int id) {
            var res = await _categoryAttributeService.DeleteCategoruAttribute.RemoveAsync(id);
            return Json(res);
        }
    }
}

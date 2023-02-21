using Dayanet.Ecommerce.Application.FASADE.Category;
using Dayanet.Ecommerce.SharedModels.Dtos.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dayanet.Ecommerce.Endpoint.Areas.Admin.Controllers.Shopping {
    [Area("Admin")]
    [Authorize(Roles = SD.Admin)]
    public class CategoriesController : Controller {
        private readonly ICategoryFasade _categoryServices;

        public CategoriesController(ICategoryFasade categoryServices) {
            _categoryServices = categoryServices;
        }
        public async Task<IActionResult> Index(string? filter, int? id) {

            IEnumerable<CategoryDto> CategoryList;
            if (filter != null) {
                var model = await _categoryServices.FetchCategoryService.GetAllAsync(filter, id);
                return View(model.Data.Where(x => x.ParentCategoryId == null));
            }

            if (id > 0 || id != null) {
                var childsModels = await _categoryServices.FetchCategoryService.GetAllAsync(filter, id);
                return View(childsModels.Data.Where(x => x.ParentCategoryId == id));
            }
            var modelNotFilter = await _categoryServices.FetchCategoryService.GetAllAsync(filter, id);
            ViewBag.Category = new SelectList(modelNotFilter.Data.Where(x => x.ParentCategoryId == null), "Id", "Name");
            return View(modelNotFilter.Data.Where(x => x.ParentCategoryId == null));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto) {
            if (string.IsNullOrWhiteSpace(categoryDto.Name)) {
                TempData["error"] = "عنوان دسته بندی را وارد نکردید";
                return Redirect("/Admin/Categories/Index");
            }
            var result = await _categoryServices.CreateCategoryService.AddAsync(categoryDto);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Categories/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Categories/Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto) {
            if (string.IsNullOrWhiteSpace(categoryDto.Name)) {
                TempData["error"] = "عنوان دسته بندی را وارد نکردید";
                return Redirect("/Admin/Categories/Index");
            }
            var result = await _categoryServices.UpdateCategoryService.UpdateAsync(categoryDto);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Categories/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Categories/Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCategory(int id) {
            if (id == 0 || id < 0 || id == null) {
                return Json(new { Message = "پارامتر ارسالی نا معتبر است", IsSuccess = false });
            }
            var result = await _categoryServices.DeleteCategoryService.DeleteAsync(id);
            return Json(result);
        }
    }
}

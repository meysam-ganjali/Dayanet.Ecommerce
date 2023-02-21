using Dayanet.Ecommerce.Application.Services.Repository.Role;
using Dayanet.Ecommerce.SharedModels.Dtos.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dayanet.Ecommerce.Endpoint.Areas.Admin.Controllers.Auth {
    [Area("Admin")]
    [Authorize(Roles = SD.Admin)]
    public class RolesController : Controller {
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleRepository roleRepository) {
            _roleRepository = roleRepository;
        }
        public async Task<IActionResult> Index() {
            var model = await _roleRepository.GetAllAsync();
            return View(model.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto roleDto)
        {
            var result = await _roleRepository.AddAsync(roleDto);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Roles/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Roles/Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto roleDto) {
            var result = await _roleRepository.UpdateAsync(roleDto);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Roles/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Roles/Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(int id) {
            var result = await _roleRepository.RemoveAsync(id);
            return Json(result);
        }
    }
}

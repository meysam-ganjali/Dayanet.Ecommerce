using Dayanet.Ecommerce.Application.FASADE.Users;
using Dayanet.Ecommerce.Application.Services.Repository.Role;
using Dayanet.Ecommerce.Application.Services.Repository.User;
using Dayanet.Ecommerce.SharedModels.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dayanet.Ecommerce.Endpoint.Areas.Admin.Controllers.User {
    [Area("Admin")]
    [Authorize(Roles = SD.Admin)]
    public class UsersController : Controller {
        private readonly IUserFasade _userService;
        private readonly IActivityUserRepository _activityService;
        private readonly IRoleRepository _roleRepository;

        public UsersController(IUserFasade userService, IActivityUserRepository activityService, IRoleRepository roleRepository) {
            _userService = userService;
            _activityService = activityService;
            _roleRepository = roleRepository;
        }
        public async Task<IActionResult> Index(string? filter, string? filterUser, int page = 1, int pageSize = 100)
        {
            var result =  _userService.FetchUsersService.GetAllAsync(filterUser, filter, pageSize, page);
            var roles = await _roleRepository.GetAllAsync();
            ViewBag.Role = new SelectList(roles.Data, "Id", "Name");
            return View(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Detaile(long id) {
            var res = await _userService.FetchUsersByIdService.GetAsyncById(id);
            if (res.IsSuccess) {
                TempData["success"] = res.Message;
                return View(res.Data);
            } else {
                TempData["error"] = res.Message;
                return Redirect("/Admin/Users/Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> ChangeLock(int id) {
            var result = await _activityService.LockOnLockAsync(id);
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeActive(int id) {
            var result = await _activityService.ActiveDeActiveAsync(id);
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveUser(long id) {
            var result = await _userService.DeleteUserService.RemoveAsync(id);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(CreateUserAddressDto addressِDto) {
            var result = await _userService.UserAddressService.CreateAsync(addressِDto);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Users/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Users/Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(int roleId, long userId) {
            var res = await _activityService.ChangeRoleAsync(userId, roleId);
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserDto updateUserDto) {
            var result = await _userService.UpdateUserService.UpdateAsync(updateUserDto);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Users/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Users/Index");
        }

        [HttpGet]
        public async Task<IActionResult> CreateUser() {
            var roles = await _roleRepository.GetAllAsync();
            ViewBag.Role = new SelectList(roles.Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto) {
            var result = await _userService.CreateUserAdminService.CreateUserAdminAsync(userDto);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Users/Index");
            }

            TempData["error"] = result.Message;
            return Redirect("/Admin/Users/Index");
        }
    }
}

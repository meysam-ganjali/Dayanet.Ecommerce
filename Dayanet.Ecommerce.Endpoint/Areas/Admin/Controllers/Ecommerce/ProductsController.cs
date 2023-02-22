using Dayanet.Ecommerce.Application.FASADE.Category;
using Dayanet.Ecommerce.Application.FASADE.Product;
using Dayanet.Ecommerce.Application.Services.Repository.Product;
using Dayanet.Ecommerce.Domain.Entities.Auth;
using Dayanet.Ecommerce.Domain.Entities.Ecommerce;
using Dayanet.Ecommerce.SharedModels.Dtos.Product;
using Dayanet.Ecommerce.SharedModels.Dtos.Product.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dayanet.Ecommerce.Endpoint.Areas.Admin.Controllers.Ecommerce {
    [Area("Admin")]
    [Authorize(Roles = SD.Admin)]
    public class ProductsController : Controller {
        private readonly IProductFasade _productService;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryFasade _categoryService;

        public ProductsController(IProductFasade productService, IProductRepository productRepository, ICategoryFasade categoryService) {
            _productService = productService;
            _productRepository = productRepository;
            _categoryService = categoryService;
        }
        public IActionResult Index(string? searchKey, int page = 1, int pageSize = 100) {
            var model = _productService.FetchProduct.GetAll(searchKey, page, pageSize).Data;
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct() {
            var Category = await _categoryService.FetchCategoryService.GetAllAsync(null, null);
            var ChildCategory = Category.Data.Where(x => x.ParentCategoryId != null);
            ViewBag.Category = new SelectList(ChildCategory, "Id", "Name");
            return View();
        }
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(CreateProductDto product) {
            var Files = HttpContext.Request.Form.Files;
            if (Files == null) {
                ModelState.AddModelError(string.Empty, "تصویر کاور برای محصول انتخاب نشده");
            }
            var result = await _productService.CreateProduct.AddAsync(product);
            if (result.IsSuccess) {
                TempData["success"] = result.Message;
                return View();
            } else {
                TempData["error"] = result.Message;
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddToInventory(CreateInventoryDto inventory) {
            var res = await _productRepository.AddToInventoryAsync(inventory);
            if (res.IsSuccess) {
                TempData["success"] = res.Message;
                return Redirect($"/Admin/Products/Index");
            }

            TempData["error"] = res.Message;
            return Redirect($"/Admin/Products/Index");
        }
        [HttpGet]//id = category id
        public async Task<IActionResult> AddProductAttribute(int categoryId,int productId)
        {
            ViewBag.ProductId = productId;
            ViewBag.CategoryId = categoryId;
            var AllowedAttribute = await _productRepository.GetAttributeForProductCategory(categoryId);
            ViewBag.Attribute = new SelectList(AllowedAttribute.Data, "Id", "AttributeName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProductAttribute(ProductAttributeDto attr,int categoryId)
        {
            var res = await _productRepository.AddAttribute(attr, categoryId);
            if (res.IsSuccess) {
                TempData["success"] = res.Message;
                return Redirect($"/Admin/Products/AddProductAttribute?categoryId={res.Data.CategoryId}&productId={res.Data.ProductId}");
            }
           
            TempData["error"] = res.Message;
            return View();
        }
    }
}

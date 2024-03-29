﻿using Dayanet.Ecommerce.Application.FASADE.Category;
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
        public async Task<IActionResult> AddProductAttribute(int categoryId, int productId) {
            ViewBag.ProductId = productId;
            ViewBag.CategoryId = categoryId;
            var AllowedAttribute = await _productRepository.GetAttributeForProductCategory(categoryId);
            ViewBag.Attribute = new SelectList(AllowedAttribute.Data, "Id", "AttributeName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProductAttribute(ProductAttributeDto attr, int categoryId) {
            var res = await _productRepository.AddAttribute(attr);//Data = Product Id
            if (res.IsSuccess) {
                TempData["success"] = res.Message;
                return Redirect($"/Admin/Products/AddProductAttribute?categoryId={categoryId}&productId={res.Data}");
            }

            TempData["error"] = res.Message;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProductGallery(CreateProductGallaryDto gallaryDto) {
            var Files = HttpContext.Request.Form.Files.ToList();
            gallaryDto.Images = Files;
            var res = await _productRepository.AddProductGallaryAsync(gallaryDto);
            if (res.IsSuccess) {
                TempData["success"] = res.Message;
                return Redirect($"/Admin/Products/Index");
            }

            TempData["error"] = res.Message;
            return Redirect($"/Admin/Products/Index");
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetaile(int id) {
            var res = await _productService.FetchProductById.GetByIdAsync(id);
            return View(res.Data);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProductPicture(int id) {
            var result = await _productRepository.RemoveFromGallery(id);
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddProductGalleryInDetaile(CreateProductGallaryDto gallaryDto) {
            var Files = HttpContext.Request.Form.Files.ToList();
            gallaryDto.Images = Files;
            var res = await _productRepository.AddProductGallaryAsync(gallaryDto);
            if (res.IsSuccess) {
                TempData["success"] = res.Message;
                return Redirect($"/Admin/Products/ProductDetaile/{gallaryDto.ProductId}");
            }

            TempData["error"] = res.Message;
            return Redirect($"/Admin/Products/ProductDetaile/{gallaryDto.ProductId}");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProductAttribute(int id) {
            var result = await _productRepository.RemoveFromProductAttribute(id);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductAttribute(int id, string Attrvalue, int pId, string? colorHex) {
            var res = await _productRepository.UpdateProductAttribute(id, Attrvalue, colorHex);
            if (res.IsSuccess) {
                TempData["success"] = res.Message;
                return Redirect($"/Admin/Products/ProductDetaile/{pId}");
            }

            TempData["error"] = res.Message;
            return Redirect($"/Admin/Products/ProductDetaile/{pId}");
        }

        [HttpPost]
        public async Task<IActionResult> AllowCommentCheck(int id) {
            var res = await _productRepository.ActivDeActivComment(id);
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> AllowIsShowCheck(int id) {
            var res = await _productRepository.ActivDeActivIsShow(id);
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> AllowSHowHomePagetCheck(int id) {
            var res = await _productRepository.ActivDeActivShowInHomePage(id);
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> AllowIsSotialCheck(int id) {
            var res = await _productRepository.ActivDeActivIsSotial(id);
            return Json(res);
        }
    }
}

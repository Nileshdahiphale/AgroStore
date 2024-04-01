using AgroStore.Web.Models;
using AgroStore.Web.Service.IService;
using AgroStore.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;

namespace AgroStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService=productService;
        }


        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto>? list = new();

            ResponseDto? response = new();

            if (User.IsInRole(SD.RoleAdmin))
            {
                response = await _productService.GetAllProductsAsync();
            }
            else if (User.IsInRole(SD.RoleProvider))
            {
                response = await _productService.GetProductsByProviderIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }

            if (response != null && response.IsSuccess)
            {
                list= JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

       

        public async Task<IActionResult> ProductCreate()
        {
            var categoryList = new List<SelectListItem>()
            {
                new SelectListItem() {Text = CategorySD.Seeds,Value = CategorySD.Seeds},
                new SelectListItem() {Text = CategorySD.Equipments,Value = CategorySD.Equipments},
                new SelectListItem() {Text = CategorySD.OrganicFarming,Value = CategorySD.OrganicFarming},
                new SelectListItem() {Text = CategorySD.Fertilizers,Value = CategorySD.Fertilizers},
            };

            ViewBag.categoryList = categoryList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDto model)
        {
            //model.ProviderId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //model.ProviderName = User.FindFirstValue(ClaimTypes.Name);

            if (ModelState.IsValid)
            {
                ResponseDto? response = await _productService.CreateProductsAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Product created successfully";
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ProductDelete(int productId)
        {
			ResponseDto? response = await _productService.GetProductByIdAsync(productId);

			if (response != null && response.IsSuccess)
			{
                ProductDto? model= JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
			}
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductDto productDto)
        {
            ResponseDto? response = await _productService.DeleteProductsAsync(productDto.ProductId);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Product deleted successfully";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(productDto);
        }

        public async Task<IActionResult> ProductEdit(int productId)
        {
            ResponseDto? response = await _productService.GetProductByIdAsync(productId);

            if (response != null && response.IsSuccess)
            {
                ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _productService.UpdateProductsAsync(productDto);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Product updated successfully";
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(productDto);
        }

    }
}

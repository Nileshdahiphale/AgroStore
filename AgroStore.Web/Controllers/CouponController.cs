using AgroStore.Web.Models;
using AgroStore.Web.Service.IService;
using AgroStore.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;

namespace AgroStore.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> CouponIndex()
        {
			ResponseDto? response = new();
            List<CouponDto>? list = new();
			if (User.IsInRole(SD.RoleAdmin))
			{
                 response = await _couponService.GetAllCouponsAsync();
            }
			else if (User.IsInRole(SD.RoleProvider))
			{
                response = await _couponService.GetAllCouponByProviderAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }

            

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        
        public async Task<IActionResult> CouponCreate()
        {
            
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _couponService.CreateCouponsAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Coupon created successfully";
                    return RedirectToAction(nameof(CouponIndex));

                }
                else
                {
                    TempData["error"] = response?.Message;
                }

            }

            return View(model);
        }

		public async Task<IActionResult> CouponDelete(int couponId)
		{
			ResponseDto? response = await _couponService.GetCouponByIdAsync(couponId);

			if (response != null && response.IsSuccess)
			{
				CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
				return View(model);
			}
			else
			{
				TempData["error"] = response?.Message;
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> CouponDelete(CouponDto couponDto)
		{
			ResponseDto? response = await _couponService.DeleteCouponsAsync(couponDto.CouponId);

			if (response != null && response.IsSuccess)
			{
				TempData["success"] = "Coupon deleted successfully";
				return RedirectToAction(nameof(CouponIndex));
			}
			else
			{
				TempData["error"] = response?.Message;
			}
			return View(couponDto);
		}


		public async Task<IActionResult> CouponEdit(int couponId)
		{
			ResponseDto? response = await _couponService.GetCouponByIdAsync(couponId);

			if (response != null && response.IsSuccess)
			{
				CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
				return View(model);
			}
			else
			{
				TempData["error"] = response?.Message;
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> CouponUpdate(CouponDto couponDto)
		{
			
			ResponseDto? response = await _couponService.UpdateCouponsAsync(couponDto);

			if (response != null && response.IsSuccess)
			{
				TempData["success"] = "Coupon updated successfully";
				return RedirectToAction(nameof(CouponIndex));
			}
			else
			{
				TempData["error"] = response?.Message;
			}
			return RedirectToAction(nameof(CouponIndex));
		}


	}
}

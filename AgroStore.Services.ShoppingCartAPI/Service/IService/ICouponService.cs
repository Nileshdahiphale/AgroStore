﻿using AgroStore.Services.ShoppingCartAPI.Models.Dto;

namespace AgroStore.Services.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
using AgroStore.Services.ShoppingCartAPI.Models.Dto;

namespace AgroStore.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}

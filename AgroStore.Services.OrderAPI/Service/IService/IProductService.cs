
using AgroStore.Services.OrderAPI.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgroStore.Services.OrderAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}

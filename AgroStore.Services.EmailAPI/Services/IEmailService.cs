using AgroStore.Services.EmailAPI.Message;
using AgroStore.Services.EmailAPI.Models.Dto;

namespace AgroStore.Services.EmailAPI.Services
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDto cartDto);
        Task RegisterUserEmailAndLog(string email);
        Task LogOrderPlaced(RewardsMessage rewardsDto);
    }
}

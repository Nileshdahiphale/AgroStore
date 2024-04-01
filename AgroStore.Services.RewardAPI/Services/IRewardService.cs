using AgroStore.Services.RewardAPI.Message;

namespace AgroStore.Services.RewardAPI.Services
{
    public interface IRewardService
    {
        Task UpdateRewards(RewardsMessage rewardsMessage);
    }
}

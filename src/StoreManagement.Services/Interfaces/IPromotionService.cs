using StoreManagement.Data.Entities;

namespace StoreManagement.Services.Interfaces
{
    public interface IPromotionService
    {
        Task<IEnumerable<Promotion>> GetAllPromotionsAsync();
        Task<Promotion?> GetPromotionByIdAsync(int id);
        Task<IEnumerable<Promotion>> SearchPromotionsAsync(string keyword);
        Task AddPromotionAsync(Promotion promotion);
        Task UpdatePromotionAsync(Promotion promotion);
        Task DeletePromotionAsync(int id);
        Task<IEnumerable<Promotion>> GetActivePromotionsAsync();
        Task<Promotion?> GetPromotionByCodeAsync(string code);
    }
}

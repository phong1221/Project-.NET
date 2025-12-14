using Microsoft.EntityFrameworkCore;
using StoreManagement.Data.Entities;
using StoreManagement.Data.Repositories;
using StoreManagement.Services.Interfaces;

namespace StoreManagement.Services.Implementations
{
    public class PromotionService : IPromotionService
    {
        private readonly IRepository<Promotion> _repository;

        public PromotionService(IRepository<Promotion> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Promotion>> GetAllPromotionsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Promotion?> GetPromotionByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Promotion>> SearchPromotionsAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await _repository.GetAllAsync();

            return await _repository.Query()
                .Where(p => p.PromoCode.Contains(keyword) || (p.Description != null && p.Description.Contains(keyword)))
                .ToListAsync();
        }

        public async Task AddPromotionAsync(Promotion promotion)
        {
            promotion.CreatedAt = DateTime.Now;
            await _repository.AddAsync(promotion);
        }

        public async Task UpdatePromotionAsync(Promotion promotion)
        {
            await _repository.UpdateAsync(promotion);
        }

        public async Task DeletePromotionAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

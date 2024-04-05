using Application.DTOs;
using Core.Entities;

namespace Application.Repositories.IRepository
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync(PaginationDto paginationDto);
        Task<Item?> GetByIdAsync(Guid id);
        Task<Item> AddAsync(Item item);
        Task<bool> UpdateAsync(Item item);
        Task<bool> DelteAsync(Item item);
        public Task<int> GetCountAsync();
    }
}

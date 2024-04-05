using Application.DTOs;
using Application.Repositories.IRepository;
using Core.Entities;
using Infrastructure.Persistence.ContextDB;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Repository
{
    public class ItemRepository(LuftBornContext context) : IItemRepository
    {
        public async Task<List<Item>> GetAllAsync(PaginationDto paginationDto)
        {
            return await context
                .Items
                .AsNoTracking()
                .OrderByDescending(w=>w.CreatedOn)
                .Skip(paginationDto.PageIndex * paginationDto.PageSize)
                .Take(paginationDto.PageSize)
                .ToListAsync();
        }
        public async Task<Item?> GetByIdAsync(Guid id)
        {
            return await context
                .Items
                .FindAsync(id);
        }
        public async Task<Item> AddAsync(Item item)
        {
            await context.AddAsync(item);

            await context.SaveChangesAsync();

            return item;
        }
        public async Task<bool> UpdateAsync(Item item)
        {
            context.Update(item);

            return await context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DelteAsync(Item item)
        {
            context.Remove(item);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<int> GetCountAsync()
        {
            return await context.Items.CountAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using QrMenu.Domain.Entities;
using QrMenu.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrMenu.Infrastructure.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _context;

        public MenuRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuItem>> GetAllAsync()
        {
            return await _context.MenuItems.Include(m => m.Category).ToListAsync();
        }

        public async Task<MenuItem?> GetByIdAsync(int id)
        {
            return await _context.MenuItems.Include(m => m.Category)
                                           .FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<IEnumerable<MenuItem>> GetMenuItemsByCategoryIdAsync(int categoryId)

        {
            return await _context.MenuItems
                        .AsNoTracking()
                        .Where(m => m.CategoryId == categoryId)
                        .Include(m => m.Category)
                        .ToListAsync();
        }

        public async Task<MenuItem> AddAsync(MenuItem item)
        {
            _context.MenuItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<MenuItem?> UpdateAsync(MenuItem item)
        {
            var existing = await _context.MenuItems.FindAsync(item.Id);
            if (existing == null) return null;

            existing.Name = item.Name;
            existing.Price = item.Price;
            existing.ImageUrl = item.ImageUrl;
            existing.CategoryId = item.CategoryId;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.MenuItems.FindAsync(id);
            if (existing == null) return false;

            _context.MenuItems.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

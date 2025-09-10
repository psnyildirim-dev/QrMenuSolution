using QrMenu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrMenu.Infrastructure.Repository
{
    public interface IMenuRepository
    {
        Task<IEnumerable<MenuItem>> GetAllAsync();
        Task<MenuItem?> GetByIdAsync(int id);
        Task<IEnumerable<MenuItem>> GetMenuItemsByCategoryIdAsync(int categoryId);
        Task<MenuItem> AddAsync(MenuItem item);
        Task<MenuItem?> UpdateAsync(MenuItem item);
        Task<bool> DeleteAsync(int id);
    }
}

using QrMenu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrMenu.Application.Interfaces
{
public interface IMenuService
    {
        Task<IEnumerable<MenuItem>> GetMenuItemsAsync();
        Task<MenuItem?> GetMenuItemByIdAsync(int id);
        Task<IEnumerable<MenuItem>> GetMenuItemsByCategoryIdAsync(int categoryId);
        Task AddMenuItemAsync(MenuItem item);
    }   
}

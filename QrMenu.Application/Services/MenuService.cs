using QrMenu.Application.Interfaces;
using QrMenu.Domain.Entities;
using QrMenu.Infrastructure.Repository;
using System.Collections.Generic;

namespace QrMenu.Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IEnumerable<MenuItem>> GetMenuItemsAsync()
        {
            return await _menuRepository.GetAllAsync();
        }

        public async Task<MenuItem?> GetMenuItemByIdAsync(int id)
        {
            return await _menuRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<MenuItem>> GetMenuItemsByCategoryIdAsync(int categoryId)
        {
            return await _menuRepository.GetMenuItemsByCategoryIdAsync(categoryId);
        }

        public async Task AddMenuItemAsync(MenuItem item)
        {
            await _menuRepository.AddAsync(item);
        }
    }
}

using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Recodme.RD.Lennyouse.DataLayer.MenuInfo;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects
{
    public class MenuDataAccessObject
    {
        private RestaurantContext _context;
        public MenuDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region Create
        public void Create(Menu menu)
        {
            _context.Menus.Add(menu);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Menu Read(Guid id)
        {
            return _context.Menus.FirstOrDefault(x => x.Id == id);
        }
        public async Task<Menu> ReadAsync(Guid id)
        {
            return await
                new Task<Menu>
                (
                    () => _context.Menus.FirstOrDefault(x => x.Id == id)
                );
        }
        #endregion

        #region Update
        public void Update(Menu menu)
        {
            _context.Entry(menu).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public async Task UpdateAsync(Menu menu)
        {
            _context.Entry(menu).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Menu menu)
        {
            menu.IsDeleted = true;
            Update(menu);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(Menu menu)
        {
            menu.IsDeleted = true;
            await UpdateAsync(menu);
        }
        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;

            if (item == null) return;
            await DeleteAsync(item);
        }
        #endregion
    }
}

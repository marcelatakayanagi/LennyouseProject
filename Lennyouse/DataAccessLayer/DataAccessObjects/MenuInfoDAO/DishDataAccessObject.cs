using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.MenuInfoDAO
{
    public class DishDataAccessObject
    {
        private RestaurantContext _context;
        public DishDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region Create
        public void Create(Dish dish)
        {
            _context.Dishes.Add(dish);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Dish dish)
        {
            await _context.Dishes.AddAsync(dish);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Dish Read(Guid id)
        {
            return _context.Dishes.FirstOrDefault(x => x.Id == id);
        }
        public async Task<Dish> ReadAsync(Guid id)
        {
            return await
                new Task<Dish>
                (
                    () => _context.Dishes.FirstOrDefault(x => x.Id == id)
                );
        }
        #endregion

        #region Update
        public void Update(Dish dish)
        {
            _context.Entry(dish).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public async Task UpdateAsync(Dish dish)
        {
            _context.Entry(dish).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Dish dish)
        {
            dish.IsDeleted = true;
            Update(dish);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(Dish dish)
        {
            dish.IsDeleted = true;
            await UpdateAsync(dish);
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

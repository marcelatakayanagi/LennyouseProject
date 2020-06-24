using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects
{
    public class MealDataAccessObject
    {
        private RestaurantContext _context;
        public MealDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region Create
        public void Create(Meal meal)
        {
            _context.Meals.Add(meal);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Meal meal)
        {
            await _context.Meals.AddAsync(meal);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Meal Read(Guid id)
        {
            return _context.Meals.FirstOrDefault(x => x.Id == id);
        }
        public async Task<Meal> ReadAsync(Guid id)
        {
            return await
                new Task<Meal>
                (
                    () => _context.Meals.FirstOrDefault(x => x.Id == id)
                );
        }
        #endregion

        #region Update
        public void Update(Meal meal)
        {
            _context.Entry(meal).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public async Task UpdateAsync(Meal meal)
        {
            _context.Entry(meal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Meal meal)
        {
            meal.IsDeleted = true;
            Update(meal);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(Meal meal)
        {
            meal.IsDeleted = true;
            await UpdateAsync(meal);
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

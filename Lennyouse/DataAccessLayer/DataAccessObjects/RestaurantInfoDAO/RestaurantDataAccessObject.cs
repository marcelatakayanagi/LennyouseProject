using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using Recodme.RD.Lennyouse.DataLayer.RestaurantInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.RestaurantInfoDAO
{
    public class RestaurantDataAccessObject
    {
        private RestaurantContext _context;
        public RestaurantDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region List
        public List<Restaurant> List()
        {
            return _context.Set<Restaurant>().ToList();
        }
        public async Task<List<Restaurant>> ListAsync()
        {
            return await _context.Set<Restaurant>().ToListAsync();
        }
        #endregion

        #region Create
        public void Create(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Restaurant Read(Guid id)
        {
            return _context.Restaurants.FirstOrDefault(x => x.Id == id);
        }
        public async Task<Restaurant> ReadAsync(Guid id)
        {
            return await
                new Task<Restaurant>
                (
                    () => _context.Restaurants.FirstOrDefault(x => x.Id == id)
                );
        }
        #endregion

        #region Update
        public void Update(Restaurant restaurant)
        {
            _context.Entry(restaurant).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public async Task UpdateAsync(Restaurant restaurant)
        {
            _context.Entry(restaurant).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Restaurant restaurant)
        {
            restaurant.IsDeleted = true;
            Update(restaurant);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(Restaurant restaurant)
        {
            restaurant.IsDeleted = true;
            await UpdateAsync(restaurant);
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

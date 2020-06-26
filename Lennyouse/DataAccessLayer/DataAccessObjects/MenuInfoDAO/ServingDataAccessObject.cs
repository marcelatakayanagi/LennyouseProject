using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.MenuInfoDAO
{
    public class ServingDataAccessObject
    {
        private RestaurantContext _context;
        public ServingDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region Create
        public void Create(Serving serving)
        {
            _context.Servings.Add(serving);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Serving serving)
        {
            await _context.Servings.AddAsync(serving);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Serving Read(Guid id)
        {
            return _context.Servings.FirstOrDefault(x => x.Id == id);
        }
        public async Task<Serving> ReadAsync(Guid id)
        {
            return await
                new Task<Serving>
                (
                    () => _context.Servings.FirstOrDefault(x => x.Id == id)
                );
        }
        #endregion

        #region Update
        public void Update(Serving serving)
        {
            _context.Entry(serving).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public async Task UpdateAsync(Serving serving)
        {
            _context.Entry(serving).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Serving serving)
        {
            serving.IsDeleted = true;
            Update(serving);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(Serving serving)
        {
            serving.IsDeleted = true;
            await UpdateAsync(serving);
        }
        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;

            if (item == null) return;
            await DeleteAsync(item);
        }
        #endregion

        #region List
        public List<Serving> List()
        {
            return _context.Servings.ToList();
        }

        public async Task<List<Serving>> ListAsync()
        {
            return await _context.Servings.ToListAsync();
        }
        #endregion
    }
}

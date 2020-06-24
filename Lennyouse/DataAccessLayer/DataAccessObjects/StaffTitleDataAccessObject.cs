using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using Recodme.RD.Lennyouse.DataLayer.RestaurantInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects
{
    public class StaffTitleDataAccessObject
    {
        private RestaurantContext _context;
        public StaffTitleDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region Create
        public void Create(StaffTitle staffTitle)
        {
            _context.StaffTitles.Add(staffTitle);
            _context.SaveChanges();
        }

        public async Task CreateAsync(StaffTitle staffTitle)
        {
            await _context.StaffTitles.AddAsync(staffTitle);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Region
        public StaffTitle Read(Guid id)
        {
            return _context.StaffTitles.FirstOrDefault(x => x.Id == id);
        }
        public async Task<StaffTitle> ReadAsync(Guid id)
        {
            return await
                new Task<StaffTitle>
                (
                    () => _context.StaffTitles.FirstOrDefault(x => x.Id == id)
                );
        }
        #endregion

        #region Update
        public void Update(StaffTitle staffTitle)
        {
            _context.Entry(staffTitle).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public async Task UpdateAsync(StaffTitle staffTitle)
        {
            _context.Entry(staffTitle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(StaffTitle staffTitle)
        {
            staffTitle.IsDeleted = true;
            Update(staffTitle);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(StaffTitle staffTitle)
        {
            staffTitle.IsDeleted = true;
            await UpdateAsync(staffTitle);
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

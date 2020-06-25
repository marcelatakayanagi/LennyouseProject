using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects
{
    public class BaseDataAccessObject<T> where T : Entity
    {
        private RestaurantContext _ctx;

        public BaseDataAccessObject()
        {
            _ctx = new RestaurantContext();
        }

        public List<T> List()
        {
            return _ctx.Set<T>().ToList();
        }

        public async Task<List<T>> ListAsync()
        {
            return await _ctx.Set<T>().ToListAsync();
        }

        public void Create(T item)
        {
            _ctx.Set<T>().Add(item);
            _ctx.SaveChanges();
        }

        public async Task CreateAsync(T item)
        {
            await _ctx.Set<T>().AddAsync(item);
            await _ctx.SaveChangesAsync();
        }

        public T Read(Guid id)
        {
            return _ctx.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public async Task<T> ReadAsync(Guid id)
        {
            return await _ctx.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(T item)
        {
            _ctx.Entry(item).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public async Task UpdateAsync(T item)
        {
            _ctx.Entry(item).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }

        public void Delete(T item)
        {
            item.IsDeleted = true;
            Update(item);
        }

        public async Task DeleteAsync(T item)
        {
            item.IsDeleted = true;
            await UpdateAsync(item);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == default) return;
            Delete(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await ReadAsync(id);
            await DeleteAsync(item);
        }
    }
}

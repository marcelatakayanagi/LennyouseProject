using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using Recodme.RD.Lennyouse.DataLayer.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.UserInfoDAO
{
    public class LennyouseUserDataAccessObject
    {
        private RestaurantContext _context;

        public LennyouseUserDataAccessObject()
        {
            _context = new RestaurantContext();
        }


        #region List
        public List<LennyouseUser> List()
        {
            return _context.Set<LennyouseUser>().ToList();
        }
        public async Task<List<LennyouseUser>> ListAsync()
        {
            return await _context.Set<LennyouseUser>().ToListAsync();
        }
        #endregion

        #region Create
        public void Create(LennyouseUser lennyouseUser)
        {
            _context.LennyouseUser.Add(lennyouseUser);
            _context.SaveChanges();
        }

        public async Task CreateAsync(LennyouseUser lennyouseUser)
        {
            await _context.LennyouseUser.AddAsync(lennyouseUser);
            await _context.SaveChangesAsync();

        }
        #endregion

        #region Read
        public LennyouseUser Read(Guid id)
        {
            return _context.LennyouseUser.FirstOrDefault(x => x.Id == id);
        }

        public async Task<LennyouseUser> ReadAsync(Guid id)
        {
            return await
                new Task<LennyouseUser>
                (
                    () => _context.LennyouseUser.FirstOrDefault(x => x.Id == id)
                );
        }
        #endregion

        #region Update
        public void Update(LennyouseUser lennyouseUser)
        {
            _context.Entry(lennyouseUser).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(LennyouseUser lennyouseUser)
        {
            _context.Entry(lennyouseUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

    }
}
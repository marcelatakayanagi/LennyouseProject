using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using Recodme.RD.Lennyouse.DataLayer.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.UserInfoDAO
{
    public class PersonDataAccessObject
    {
        private RestaurantContext _context;
        public PersonDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region List
        public List<Person> List()
        {
            return _context.Set<Person>().ToList();
        }
        public async Task<List<Person>> ListAsync()
        {
            return await _context.Set<Person>().ToListAsync();
        }
        #endregion

        #region Create
        public void Create(Person person)
        {
            var lennyouseUser = new LennyouseUser();
            _context.LennyouseUser.Add(lennyouseUser);
            person.LennyouseUser = lennyouseUser;
            person.LennyouseUserId = lennyouseUser.Id;
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Person Read(Guid id)
        {
            return _context.Persons.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Person> ReadAsync(Guid id)
        {
            return await
                new Task<Person>
                (
                    () => _context.Persons.FirstOrDefault(x => x.Id == id)
                );
        }
        #endregion

        # region Update
        public void Update(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Person person)
        {
            person.IsDeleted = true;
            Update(person);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(Person person)
        {
            person.IsDeleted = true;
            await UpdateAsync(person);
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

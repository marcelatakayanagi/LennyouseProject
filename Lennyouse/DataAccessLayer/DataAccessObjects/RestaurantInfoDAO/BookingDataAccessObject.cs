﻿using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using Recodme.RD.Lennyouse.DataLayer.RestaurantInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.RestaurantInfoDAO
{
    public class BookingDataAccessObject
    {
        private RestaurantContext _context;
        public BookingDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region Create
        public void Create(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Booking Read(Guid id)
        {
            return _context.Bookings.FirstOrDefault(x => x.Id == id);
        }
        public async Task<Booking> ReadAsync(Guid id)
        {
            return await
                new Task<Booking>
                (
                    () => _context.Bookings.FirstOrDefault(x => x.Id == id)
                );
        }
        #endregion

        #region Update
        public void Update(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public async Task UpdateAsync(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Booking booking)
        {
            booking.IsDeleted = true;
            Update(booking);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(Booking booking)
        {
            booking.IsDeleted = true;
            await UpdateAsync(booking);
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

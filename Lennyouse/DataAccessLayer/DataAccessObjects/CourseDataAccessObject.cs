using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.DataLayer.Base;
using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects
{
    public class CourseDataAccessObject
    {
        private RestaurantContext _context;
        public CourseDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region Create
        public void Create(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Region
        public Course Read(Guid id)
        {
            return _context.Courses.FirstOrDefault(x => x.Id == id);
        }
        public async Task<Course> ReadAsync(Guid id)
        {
            return await 
                new Task<Course>
                (
                    ()=>_context.Courses.FirstOrDefault(x => x.Id == id)
                );
        }
        #endregion

        #region Update
        public void Update(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public async Task UpdateAsync(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Course course)
        {
            course.IsDeleted = true;
            Update(course);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(Course course)
        {
            course.IsDeleted = true;
            await UpdateAsync(course); 
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

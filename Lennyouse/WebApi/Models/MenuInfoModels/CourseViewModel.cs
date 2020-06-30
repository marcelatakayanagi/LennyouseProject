using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.MenuInfoModels
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Course ToCourse()
        {
            return new Course(Id, DateTime.UtcNow, DateTime.UtcNow, false, Name);
        }
        public static CourseViewModel Parse(Course course)
        {
            return new CourseViewModel()
            {
                Id = course.Id,
                Name = course.Name
            };
        }
    }
}

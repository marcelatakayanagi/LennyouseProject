using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;

namespace Recodme.RD.Lennyouse.DataLayer.MenuInfo
{
    public class Course : NamedEntity
    {
        public ICollection<Course> ServingCourses { get; set; }


        public Course(string name, string description, string position) : base(name)
        {

        }

        public Course(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, string name, string description, string position) : base(id, createdAt, updatedAd, isDeleted, name)
        {

        }
    }
}

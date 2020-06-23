using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;

namespace Recodme.RD.Lennyouse.DataLayer.MenuInfo
{
    public class Course : NamedEntity
    {
        public virtual ICollection<Serving> Servings { get; set; }


        public Course(string name) : base(name)
        {

        }

        public Course(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, string name) : base(id, createdAt, updatedAd, isDeleted, name)
        {

        }
    }
}

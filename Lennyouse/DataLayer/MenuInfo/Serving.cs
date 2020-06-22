using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.RD.Lennyouse.DataLayer.MenuInfo
{
    public class Serving : Entity
    {
        [ForeignKey("Menu")]
        public Guid MenuId { get; set; }

        [ForeignKey("Course")]
        public Guid CourseId { get; set; }

        [ForeignKey("Dish")]
        public Guid DishId { get; set; }


        public virtual Menu Menu { get; set; }

        public virtual Course Course { get; set; }

        public virtual Dish Dish { get; set; }


        public Serving(Guid menuId, Guid courseId, Guid dishId)
        {
            MenuId = menuId;
            CourseId = courseId;
            DishId = dishId;
        }

        public Serving(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, Guid menuId, Guid courseId, Guid dishId) : base(id, createdAt, updatedAd, isDeleted)
        {
            MenuId = menuId;
            CourseId = courseId;
            DishId = dishId;
        }
    }
}

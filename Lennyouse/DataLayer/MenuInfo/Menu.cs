using System;
using System.ComponentModel.DataAnnotations;
using Recodme.RD.Lennyouse.DataLayer.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Recodme.RD.Lennyouse.DataLayer.RestaurantInfo;

namespace Recodme.RD.Lennyouse.DataLayer.MenuInfo
{
    public class Menu : Entity
    {
        private DateTime _date;


        [Required(ErrorMessage = "Input Data")]
        public DateTime Date 
        {
            get => _date; 
            set
            {
                _date = value;
                RegisterChange();
            }
        }

        [ForeignKey("Meal")]
        public Guid MealId { get; set; }
        public virtual Meal Meal { get; set; }


        [ForeignKey("Restaurant")]
        public Guid RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<Serving> Servings { get; set; }

        public Menu(DateTime date, Guid mealId, Guid restaurantId) : base()
        {
            _date = date;
            MealId = mealId;
            RestaurantId = restaurantId;
        }

        public Menu(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, DateTime date, Guid mealId, Guid restaurantId) : base(id, createdAt, updatedAd, isDeleted)
        {
            _date = date;
            MealId = mealId;
            RestaurantId = restaurantId;
        }
    }
}

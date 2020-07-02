using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using System;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.MenuInfoModels
{
    public class MenuViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid MealId { get; set; }
        public Guid RestaurantId { get; set; }


        public Menu ToMenu()
        {
            return new Menu(Id, DateTime.UtcNow, DateTime.UtcNow, false, Date,MealId,RestaurantId);
        }

        public static MenuViewModel Parse(Menu obj)
        {
            return new MenuViewModel()
            {
                Id = obj.Id,
                Date = obj.Date,
                MealId = obj.MealId,
                RestaurantId = obj.RestaurantId
            };
        }

        public bool Equals(Menu obj)
        {
            bool res = 
                (Id == obj.Id &&
                Date == obj.Date &&
                MealId == obj.MealId &&
                RestaurantId == obj.MealId);
            return res;
        }
    }
}
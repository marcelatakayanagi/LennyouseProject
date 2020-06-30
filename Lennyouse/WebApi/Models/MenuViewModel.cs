using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using System;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models
{
    public class MenuViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid MealId { get; set; }
        public Guid ReastaurantId { get; set; }


        public Menu ToObjt()
        {
            return new Menu(Id, DateTime.UtcNow, DateTime.UtcNow, false, Date,MealId,ReastaurantId);
        }

        public static MenuViewModel Parse(Menu obj)
        {
            return new MenuViewModel()
            {
                Id = obj.Id,
                Date = obj.Date,
                MealId = obj.MealId,
                ReastaurantId = obj.ReastaurantId
            };
        }

        public bool Equals(Menu obj)
        {
            bool res = 
                (Id == obj.Id &&
                Date == obj.Date &&
                MealId == obj.MealId &&
                ReastaurantId == obj.MealId);
            return res;
        }
    }
}
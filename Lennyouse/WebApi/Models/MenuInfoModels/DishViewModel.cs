using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.MenuInfoModels
{
    public class DishViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DietaryRestrictionId { get; set; }



        public Dish ToDish()
        {
            return new Dish(Id, DateTime.UtcNow, DateTime.UtcNow, false, Name, DietaryRestrictionId);
        }

        public static DishViewModel Parse(Dish dish)
        {
            return new DishViewModel()
            {
                Id = dish.Id,
                Name = dish.Name,
                DietaryRestrictionId = dish.DietaryRestrictionId
            };
        }
    }
}

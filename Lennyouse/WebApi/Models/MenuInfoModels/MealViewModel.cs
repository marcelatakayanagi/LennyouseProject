using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using System;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.MenuInfoModels
{
    public class MealViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Starting { get; set; }
        public string Ending { get; set; }

        public Meal ToMeal()
        {
            return new Meal(Id, DateTime.UtcNow, DateTime.UtcNow, false, Name, Starting, Ending);
        }

        public static MealViewModel Parse(Meal meal)
        {
            return new MealViewModel()
            {
                Id = meal.Id,
                Name = meal.Name,
                Starting = meal.StartingHours,
                Ending = meal.EndingHours
            };
        }
    }
}

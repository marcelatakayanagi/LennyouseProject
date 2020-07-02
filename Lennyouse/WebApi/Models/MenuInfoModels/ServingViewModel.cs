using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.MenuInfoModels
{
    public class ServingViewModel
    {
        public Guid Id { get; set; }
        public Guid MenuId { get; set; }
        public Guid CourseId { get; set; }
        public Guid DishId { get; set; }



        public Serving ToServing()
        {
            return new Serving(Id, DateTime.UtcNow, DateTime.UtcNow, false, MenuId, CourseId, DishId);
        }

        public static ServingViewModel Parse(Serving serving)
        {
            return new ServingViewModel()
            {
                Id = serving.Id,
                MenuId = serving.MenuId,
                CourseId = serving.CourseId,
                DishId = serving.DishId
            };
        }
    }
}

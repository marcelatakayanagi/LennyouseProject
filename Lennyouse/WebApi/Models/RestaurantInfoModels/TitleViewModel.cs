using Recodme.RD.Lennyouse.DataLayer.RestaurantInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.RestaurantInfoModels
{
    public class TitleViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OpeningHours { get; set; }
        public string ClosingHours { get; set; }

        public Title ToTitle()
        {
            return new Title(Id, DateTime.UtcNow, DateTime.UtcNow, false, Name, OpeningHours, ClosingHours);
        }
        public static TitleViewModel Parse(Title title)
        {
            return new TitleViewModel()
            {
                Id = title.Id,
                Name = title.Name,
                OpeningHours = title.OpeningHours,
                ClosingHours = title.ClosingHours
            };
        }
    }
}

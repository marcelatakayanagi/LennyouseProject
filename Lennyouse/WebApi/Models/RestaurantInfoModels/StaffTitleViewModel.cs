using Recodme.RD.Lennyouse.DataLayer.RestaurantInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.RestaurantInfoModels
{
    public class StaffTitleViewModel
    {
        public Guid Id { get; set; }
        public  DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid TitleId { get; set; }
        public Guid StaffRecordId { get; set; }

        public StaffTitle ToStaffTitle()
        {
            return new StaffTitle(Id, DateTime.UtcNow, DateTime.UtcNow, false, StartDate , EndDate , TitleId, StaffRecordId);
        }
        public static StaffTitleViewModel Parse(StaffTitle staffTitle)
        {
            return new StaffTitleViewModel()
            {
                Id = staffTitle.Id,
                StartDate  = staffTitle.StartDate,
                EndDate = staffTitle.EndDate,
                TitleId = staffTitle.TitleId,
                StaffRecordId = staffTitle.StaffRecordId
            };
        }
    }
}

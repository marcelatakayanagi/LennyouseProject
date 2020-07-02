using Recodme.RD.Lennyouse.DataLayer.UserInfo;
using System;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.UserInfoModels
{
    public class StaffRecordViewModel
    {
        public Guid Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid PersonId { get; set; }
        public Guid RestaurantId { get; set; }

        public StaffRecord ToStaffRecord()
        {
            return new StaffRecord(Id, DateTime.UtcNow, DateTime.UtcNow, false, DateTime.UtcNow, DateTime.UtcNow, PersonId, RestaurantId);
        }

        public static StaffRecordViewModel Parse(StaffRecord staffRecord)
        {
            return new StaffRecordViewModel()
            {
                Id = staffRecord.Id,
                BeginDate = staffRecord.BeginDate,
                EndDate = staffRecord.EndDate
            };
        }
    }
}

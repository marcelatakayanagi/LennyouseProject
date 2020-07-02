using Recodme.RD.Lennyouse.DataLayer.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.UserInfoModels
{
    public class ClientRecordViewModel
    {
        public Guid Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public Guid PersonId { get; set; }
        public Guid RestaurantId { get; set; }

        public ClientRecord ToClientRecord()
        {
            return new ClientRecord(Id, DateTime.UtcNow, DateTime.UtcNow, false, DateTime.UtcNow, PersonId, RestaurantId);
        }

        public static ClientRecordViewModel Parse(ClientRecord clientRecord)
        {
            return new ClientRecordViewModel()
            {
                Id = clientRecord.Id,
                RegisterDate = clientRecord.RegisterDate,
                PersonId = clientRecord.PersonId,
                RestaurantId = clientRecord.RestaurantId
            };
        }
    }
}

using Recodme.RD.Lennyouse.DataLayer.RestaurantInfo;
using Recodme.RD.Lennyouse.DataLayer.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebApi.Models.RestaurantInfoModels
{
    public class BookingViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid ClientRecordId { get; set; }
        

        public Booking ToBooking()
        {
            return new Booking(Id, DateTime.UtcNow,DateTime.UtcNow,false,DateTime.UtcNow,ClientRecordId);
        }
        public static BookingViewModel Parse(Booking booking)
        {
            return new BookingViewModel()
            {
                Id = booking.Id,
                Date = booking.Date,
                ClientRecordId = booking.ClientRecordId
            };
        }
    }
}

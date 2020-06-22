using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recodme.RD.Lennyouse.DataLayer.RestaurantInfo
{
    public class Booking:Entity
    {
        private DateTime _date;
        [Required(ErrorMessage = "Input Data")]
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                RegisterChange();
            }
        }

        [ForeignKey("ClientRecord")]
        public Guid ClientRecordId { get; set; }
        public virtual ClientRecord ClientRecord { get; set; }

        public Booking(DateTime date, Guid clientRecordId)
        {
            _date = date;
            ClientRecordId = clientRecordId;
        }

        public Booking(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, DateTime date, Guid clientRecordId) : base(id, createdAt, updatedAd, isDeleted)
        {
            _date = date;
            ClientRecordId = clientRecordId;
        }

        
    }
}

using Recodme.RD.Lennyouse.DataLayer.Base;
using Recodme.RD.Lennyouse.DataLayer.RestaurantInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recodme.RD.Lennyouse.DataLayer.UserInfo
{
    public class ClientRecord : Entity
    {

        [ForeignKey("Person")]
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }

        [ForeignKey("Restaurant")]
        public Guid RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        private DateTime _registerDate;

        [Required(ErrorMessage = "Input Register Date")]
        [Display(Name = "Register Date")]
        public DateTime RegisterDate
        {
            get => _registerDate;
            set
            {
                _registerDate = value;
                RegisterChange();
            }
        }

        public virtual ICollection<Booking> Bookings { get; set; }

        public ClientRecord(DateTime registerDate, Guid personId) : base()
        {
            _registerDate = registerDate;
            PersonId = personId;
        }

        public ClientRecord(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, DateTime registerDate, Guid personId) : base(id, createdAt, updatedAd, isDeleted)
        {
            _registerDate = registerDate;
            PersonId = personId;
        }
    }
}

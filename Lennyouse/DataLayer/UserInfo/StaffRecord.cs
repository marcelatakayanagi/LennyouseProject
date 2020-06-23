using Recodme.RD.Lennyouse.DataLayer.Base;
using Recodme.RD.Lennyouse.DataLayer.RestaurantInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recodme.RD.Lennyouse.DataLayer.UserInfo
{
    public class StaffRecord : Entity
    {
        [ForeignKey("Restaurant")]
        public Guid RestaurantId { get; set; }

        [ForeignKey("Person")]
        public Guid PersonId { get; set; }

        private DateTime _beginDate;
        private DateTime _endDate;

        [Required(ErrorMessage = "Input begin date")]
        [Display(Name = "Begin date")]
        public DateTime BeginDate
        {
            get => _beginDate;
            set
            {
                _beginDate = value;
                RegisterChange();
            }
        }
        [Required(ErrorMessage = "Input end date")]
        [Display(Name = "End date")]
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                RegisterChange();
            }
        }
        public virtual Restaurant Restaurant { get; set; }
        public virtual Person Person { get; set; }

        public virtual ICollection<StaffTitle> StaffTitles { get; set; }
        public StaffRecord(DateTime beginDate, DateTime endDate, Guid restaurantId, Guid personId)
        {
            _beginDate = beginDate;
            _endDate = endDate;
            RestaurantId = restaurantId;
            PersonId = personId;
        }

        public StaffRecord(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, DateTime beginDate, DateTime endDate, Guid restaurantId, Guid personId) : base(id, createdAt, updatedAd, isDeleted)
        {
            _beginDate = beginDate;
            _endDate = endDate;
            RestaurantId = restaurantId;
            PersonId = personId;
        }
    }
}

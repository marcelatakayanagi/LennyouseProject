using Recodme.RD.Lennyouse.DataLayer.Base;
using Recodme.RD.Lennyouse.DataLayer.UserInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recodme.RD.Lennyouse.DataLayer.RestaurantInfo
{
    public class StaffTitle : Entity
    {
        private DateTime _startDate;
        private DateTime _endDate;

        [Required(ErrorMessage = "Input Start Date")]
        [Display(Name = "Start Date")]
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                RegisterChange();
            }
        }
        
        [Required(ErrorMessage = "Input End Date")]
        [Display(Name = "End Date")]
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                RegisterChange();
            }
        }


        [ForeignKey("Title")]
        public Guid TitleId { get; set; }
        public virtual Title Title { get; set; }

        [ForeignKey("StaffRecord")]
        public Guid StaffRecordId { get; set; }
        public virtual StaffRecord StaffRecord { get; set; }


        public StaffTitle(DateTime startDate, DateTime endDate, Guid titleId, Guid staffRecordId)
        {
            _startDate = startDate;
            _endDate = endDate;
            TitleId = titleId;
            StaffRecordId = staffRecordId;
        }

        public StaffTitle(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, DateTime startDate, DateTime endDate, Guid titleId, Guid staffRecordId) : base(id, createdAt, updatedAd, isDeleted)
        {
            _startDate = startDate;
            _endDate = endDate;
            TitleId = titleId;
            StaffRecordId = staffRecordId;
        }
    }
}

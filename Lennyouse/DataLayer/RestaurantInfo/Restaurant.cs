using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Recodme.RD.Lennyouse.DataLayer.Base;
using Recodme.RD.Lennyouse.DataLayer.MenuInfo;

namespace Recodme.RD.Lennyouse.DataLayer.RestaurantInfo
{
    public class Restaurant : NamedEntity
    {
        private string _address;
        private string _openingHours;
        private string _closingHoours;
        private string _closedDays;
        private int _tableCount;


        [Required(ErrorMessage = "Input address")]
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                RegisterChange();
            }
        }

        [Required(ErrorMessage = "Input opening hours")]
        [Display(Name = "Opening Hours")]
        public string OpeningHours
        {
            get => _openingHours;
            set
            {
                _openingHours = value;
                RegisterChange();
            }
        }

        [Required(ErrorMessage = "Input closing hours")]
        [Display(Name = "Closing hours")]
        public string ClosingHours
        {
            get => _closingHoours;
            set
            {
                _closingHoours = value;
                RegisterChange();
            }
        }

        [Required(ErrorMessage = "Input closed days")]
        [Display(Name = "Closed Days")]
        public string ClosedDays
        {
            get => _closedDays;
            set
            {
                _closedDays = value;
                RegisterChange();
            }
        }

        [Required(ErrorMessage = "Input table count")]
        [Display(Name = "Table Count")]
        public int TableCount
        {
            get => _tableCount;
            set
            {
                _tableCount = value;
                RegisterChange();
            }
        }

        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<StaffRecord> StaffRecords { get; set; }
        public virtual ICollection<ClientRecord> ClientRecords { get; set; }

        public Restaurant(string name, string address, string openingHours, string closingHours, string closedDays, int tableCount) : base(name)
        {
            _address = address;
            _openingHours = openingHours;
            _closingHoours = closingHours;
            _closedDays = closedDays;
            _tableCount = tableCount;
        }

        public Restaurant(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, string name, string address, string openingHours, string closingHours, string closedDays, int tableCount) : base(id, createdAt, updatedAd, isDeleted, name)
        {
            _address = address;
            _openingHours = openingHours;
            _closingHoours = closingHours;
            _closedDays = closedDays;
            _tableCount = tableCount;
        }
    }
}

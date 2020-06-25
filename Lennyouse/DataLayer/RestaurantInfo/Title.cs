using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Recodme.RD.Lennyouse.DataLayer.RestaurantInfo
{
    public class Title : NamedEntity
    {
        private string _openingHours;
        private string _closingHours;
        [Required(ErrorMessage = "Input  Opening Hours")]
        public string OpeningHours
        {
            get => _openingHours;
            set
            {
                _openingHours = value;
                RegisterChange();
            }
        }

        [Required(ErrorMessage = "Input Closing Hours")]
        public string ClosingHours
        {
            get => _closingHours;
            set
            {
                _closingHours = value;
                RegisterChange();
            }
        }
        public virtual ICollection<StaffTitle> StaffTitles { get; set; }
        public Title(string name, string openingHours, string closingHours) : base(name)
        {
            _openingHours = openingHours;
            _closingHours = closingHours;
        }

        public Title(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, string name, string openingHours, string closingHours) : base(id, createdAt, updatedAd, isDeleted, name)
        {
            _openingHours = openingHours;
            _closingHours = closingHours;
        }
    }
}

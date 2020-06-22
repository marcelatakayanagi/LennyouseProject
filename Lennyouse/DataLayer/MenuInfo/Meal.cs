using System;
using System.ComponentModel.DataAnnotations;
using Recodme.RD.Lennyouse.DataLayer.Base;
using System.Collections.Generic;

namespace Recodme.RD.Lennyouse.DataLayer.MenuInfo
{
    public class Meal : NamedEntity
    {
        private string _startingHours;
        private string _endingHours;

        [Required(ErrorMessage = "Input Starting Hours")]
        [Display(Name = "Starting Hours")]
        public string StartingHours
        {
            get => _startingHours;
            set
            {
                value = _startingHours;
                RegisterChange();
            }
        }

        [Required(ErrorMessage = "Input Ending Hours")]
        [Display(Name = "Ending Hours")]
        public string EndingHours
        {
            get => _endingHours;
            set
            {
                value = _endingHours;
                RegisterChange();
            }
        }

        public virtual ICollection<Menu> Menus { get; set; }

        public Meal(string name, string startingHours, string endingHours) :base(name)
        {
            _startingHours = startingHours;
            _endingHours = endingHours;
        }

        public Meal(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, string name, string startingHours, string endingHours) : base(id, createdAt, updatedAd, isDeleted, name)
        {
            _startingHours = startingHours;
            _endingHours = endingHours;
        }
    }
}

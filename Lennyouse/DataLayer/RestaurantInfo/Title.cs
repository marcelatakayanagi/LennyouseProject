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
        private string _position;
        private string _description;
        [Required(ErrorMessage = "Input Position")]
        public string Position
        {
            get => _position;
            set
            {
                _position = value;
                RegisterChange();
            }
        }

        [Required(ErrorMessage = "Input Description")]
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                RegisterChange();
            }
        }
        public virtual ICollection<StaffTitle> StaffTitles { get; set; }
        public Title(string name, string position, string description) : base(name)
        {
            _position = position;
            _description = description;
        }

        public Title(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, string name, string position, string description) : base(id, createdAt, updatedAd, isDeleted, name)
        {
            _position = position;
            _description = description;
        }
    }
}

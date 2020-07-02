using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recodme.RD.Lennyouse.DataLayer.UserInfo
{
    public class Person : Entity
    {
        private long _vatNumber;
        private string _firstName;
        private string _lastName;
        private DateTime _birthDate;
        private long _phoneNumber;

        [Required(ErrorMessage = "Input V.A.T number")]
        [Display(Name = "V.A.T")]
        public long VatNumber
        {
            get => _vatNumber;
            set
            {
                _vatNumber = value;
                RegisterChange();
            }
        }
        [Required(ErrorMessage = "Input first name")]
        [Display(Name = "First Name")]
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                RegisterChange();
            }
        }
        [Required(ErrorMessage = "Input last name")]
        [Display(Name = "Last Name")]
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                RegisterChange();
            }
        }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                RegisterChange();
            }
        }
        [Required(ErrorMessage = "Input phone number")]
        [Display(Name = "Phone number")]
        public long PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                RegisterChange();
            }
        }

        [ForeignKey("LennyouseUser")]
        public Guid LennyouseUserId { get; set; }
        public virtual LennyouseUser LennyouseUser { get; set; }

        public virtual ICollection<StaffRecord> StaffRecords { get; set; }
        public virtual ICollection<ClientRecord> ClientRecords { get; set; }

        public Person(DateTime birthDate, string firstName, string lastName, long phoneNumber, long vatNumber, Guid lennyouseUserId) : base()
        {
            _birthDate = birthDate;
            _firstName = firstName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _vatNumber = vatNumber;
            LennyouseUserId = lennyouseUserId;
        }

        public Person(Guid id, DateTime createAt, DateTime updateAt, bool isDeleted, DateTime birthDate, string firstName, string lastName, 
                      long phoneNumber, long vatNumber, Guid lennyouseUserId) : base(id, createAt, updateAt, isDeleted)
        {
            _birthDate = birthDate;
            _firstName = firstName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _vatNumber = vatNumber;
            LennyouseUserId = lennyouseUserId;
        }
    }
}

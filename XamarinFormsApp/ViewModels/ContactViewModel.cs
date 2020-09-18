using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinFormsApp.Models;

namespace XamarinFormsApp.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string ImageUrl { get; set; }
        public bool IsBlocked { get; set; }

        public ContactViewModel()
        {

        }

        public ContactViewModel(Contact contact)
        {
            Id = contact.Id;
            _firstName = contact.FirstName;
            _lastName = contact.LastName;
            Phone = contact.Phone;
            Email = contact.Email;
            ImageUrl = contact.ImageUrl;
            Status = contact.Status;
            IsBlocked = contact.IsBlocked;
        }


        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                SetValue(ref _firstName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                SetValue(ref _lastName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }



    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsApp.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string ImageUrl { get; set; }
        public bool  IsBlocked { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using XamarinFormsApp.Models;

namespace XamarinFormsApp.Services
{
    public class ContactMethodService
    {
        private IEnumerable<ContactMethod> _contactMethods = new List<ContactMethod>
        {
            new ContactMethod { Id = 1, Name = "Email" },
            new ContactMethod { Id = 2, Name = "SMS" }
        };

        public IEnumerable<ContactMethod> GetContactMethods()
        {
            return _contactMethods;
        }
    }
}

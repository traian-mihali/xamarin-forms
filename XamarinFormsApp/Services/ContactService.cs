using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using XamarinFormsApp.Models;

namespace XamarinFormsApp.Services
{
    public class ContactService
    {
        private IList<Contact> _contacts = new List<Contact>
        {
            new Contact {Id = 1, FirstName = "John", LastName = "Doe"},
            new Contact {Id = 2, FirstName = "Jane", LastName = "Doe"},
        };

        public IEnumerable<Contact> GetContacts()
        {
            return _contacts;
        }

        public Contact GetContact(int contactId)
        {
            return _contacts.SingleOrDefault(c => c.Id == contactId);
        }

        public void AddContact(Contact contact)
        {
            if (contact.Id == 0)
            {
                contact.Id = _contacts.Count + 1;

                _contacts.Add(contact);
            }
            else
            {
               var contactToUpdate = _contacts.SingleOrDefault(c => c.Id == contact.Id);
                contactToUpdate.FirstName = contact.FirstName;
                contactToUpdate.LastName = contact.LastName;
                contactToUpdate.Phone = contact.Phone;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.IsBlocked = contact.IsBlocked;
            }

        }

        public void RemoveContact(Contact contact)
        {
            _contacts.Remove(contact);
        }
    }
}

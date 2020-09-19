using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFormsApp.Models;

namespace XamarinFormsApp.ViewModels
{
    public class ContactDetailViewModel
    {
        private readonly IContactStore _contactStore;
        private readonly IPageService _pageService;

        //public event EventHandler<Contact> ContactAdded;
        //public event EventHandler<Contact> ContactUpdated;

        public Contact Contact { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public ContactDetailViewModel(ContactViewModel viewModel, IContactStore contactStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException();

            _contactStore = contactStore;
            _pageService = pageService;

            SaveCommand = new Command(async () => await Save());

            Contact = new Contact
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Phone = viewModel.Phone,
                Email = viewModel.Email,
                IsBlocked = viewModel.IsBlocked
            };

        }

        private async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Contact.FirstName) && String.IsNullOrWhiteSpace(Contact.LastName))
            {
                await _pageService.DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }

            if (Contact.Id == 0)
            {
                await _contactStore.AddContact(Contact);

                //ContactAdded?.Invoke(this, Contact);
                MessagingCenter.Send(this, Events.ContactAdded, Contact);
            }
            else
            {
                await _contactStore.UpdateContact(Contact);

                //ContactUpdated?.Invoke(this, Contact);
                MessagingCenter.Send(this, Events.ContactUpdated, Contact);
            }

            await _pageService.PopAsync();
        }
    }
}

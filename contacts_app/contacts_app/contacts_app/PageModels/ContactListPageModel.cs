using contacts_app.Models;
using contacts_app.Services;
using FreshMvvm;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace contacts_app.PageModels
{
    public class ContactListPageModel : FreshBasePageModel
    {

        public List<Contact> Contacts { get; set; }

        public Command AddContactCommand { get; }

        public bool ContactListIsNotEmpty { get; set; }

        public Contact SelectedContact
        {
            get { return null; }
            set
            {
                CoreMethods.PushPageModel<ContactPageModel>(value);
            }
        }


        public ContactListPageModel()
        {
            AddContactCommand = new Command(OnAddContactCommand);
        }

        public override void Init (object initData)
        {
            var contactTableService = FreshIOC.Container.Resolve<IContactTableService>();

            Contacts = contactTableService.GetContacts().Result;

            ContactListIsNotEmpty = Contacts.Count > 0;

            RaisePropertyChanged("ContactListIsNotEmpty");
        }

        public override void ReverseInit(object returnedData)
        {
            var contactTableService = FreshIOC.Container.Resolve<IContactTableService>();

            Contacts = contactTableService.GetContacts().Result;

            ContactListIsNotEmpty = Contacts.Count > 0;

            RaisePropertyChanged("Contacts");

            RaisePropertyChanged("ContactListIsNotEmpty");
        }

        private async void OnAddContactCommand()
        {
            await CoreMethods.PushPageModel<AddContactPageModel>();
        }
    }
}






























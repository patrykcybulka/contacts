using contacts_app.Helpers;
using contacts_app.Models;
using contacts_app.Services;
using FreshMvvm;
using System.Text;
using Xamarin.Forms;

namespace contacts_app.PageModels
{
    public class AddContactPageModel : FreshBasePageModel
    {
        public Contact Contact { get; set; }

        public Command BackCommand { get; }

        public Command CreateContact { get; }

        public AddContactPageModel()
        {
            BackCommand = new Command(OnBackCommand);

            CreateContact = new Command(OnCreateContact);

            Contact = new Contact();
        }

        private async void OnCreateContact()
        {
            var validationResult = Validator.ValidateContact(Contact);

            if (validationResult.Length > 0)
            {
                var massage = new StringBuilder();

                foreach (var item in validationResult)
                {
                    massage.AppendLine(item);
                }

                await Application.Current.MainPage.DisplayAlert("Informacja", massage.ToString(), "Ok");
            }
            else
            {
                var contactTableService = FreshIOC.Container.Resolve<IContactTableService>();

                await contactTableService.AddContact(Contact);

                await CoreMethods.PopPageModel();

                PreviousPageModel.ReverseInit(null);

                RaisePageWasPopped();
            }
        }

        private async void OnBackCommand()
        {
            await CoreMethods.PopPageModel();

            RaisePageWasPopped();
        }
    }
}

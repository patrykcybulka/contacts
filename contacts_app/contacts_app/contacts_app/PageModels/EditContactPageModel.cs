using contacts_app.Helpers;
using contacts_app.Models;
using contacts_app.Services;
using FreshMvvm;
using System.Text;
using Xamarin.Forms;

namespace contacts_app.PageModels
{
    public class EditContactPageModel : FreshBasePageModel
    {
        public Contact Contact { get; set; }

        public Command BackCommand { get; }

        public Command EditContact { get; }

        public EditContactPageModel()
        {
            BackCommand = new Command(OnBackCommand);

            EditContact = new Command(OnEditContact);
        }

        public override void Init(object initData)
        {
            base.Init(initData);

            Contact = initData as Contact;
        }

        private async void OnEditContact()
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

                await contactTableService.EditContact(Contact);

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

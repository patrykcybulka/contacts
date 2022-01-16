using contacts_app.Models;
using contacts_app.Services;
using FreshMvvm;
using Xamarin.Forms;

namespace contacts_app.PageModels
{
    public class ContactPageModel : FreshBasePageModel
    {
        private bool contactChanged = false;

        public Contact Contact { get; set; }

        public Command BackCommand { get; }

        public Command EditContactCommand { get; }

        public Command RemoveContactCommand { get; }

        public ContactPageModel()
        {
            BackCommand          = new Command(OnBackCommand);
            EditContactCommand   = new Command(OnEditContactCommand);
            RemoveContactCommand = new Command(OnRemoveContactCommand);
        }

        public override void Init(object initData)
        {
            Contact = initData as Contact;
        }

        public override void ReverseInit(object returnedData)
        {
            contactChanged = true;

            RaisePropertyChanged("Contact");
        }

        private async void OnBackCommand()
        {
            await CoreMethods.PopPageModel();
            
            PreviousPageModel.ReverseInit(null);

            RaisePageWasPopped();
        }

        private async void OnEditContactCommand()
        {
            await CoreMethods.PushPageModel<EditContactPageModel>(Contact);
        }

        private async void OnRemoveContactCommand()
        {
            var contactTableService = FreshIOC.Container.Resolve<IContactTableService>();

            await contactTableService.RemoveContact(Contact);

            await CoreMethods.PopPageModel();

            PreviousPageModel.ReverseInit(null);

            RaisePageWasPopped();
        }
    }
}

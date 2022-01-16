using contacts_app.PageModels;
using contacts_app.Services;
using FreshMvvm;
using Xamarin.Forms;

namespace contacts_app
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            FreshIOC.Container.Register<IConnectionHandlerService, ConnectionHandlerService>();
            FreshIOC.Container.Register<IContactTableService, ContactTableService>();

            var page = FreshPageModelResolver.ResolvePageModel<ContactListPageModel>();

            var basicNavContainer = new FreshNavigationContainer(page);

            MainPage = basicNavContainer;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

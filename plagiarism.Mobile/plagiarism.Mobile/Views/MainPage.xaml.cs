using plagiarism.Mobile.Models;
using plagiarism.Mobile.ViewModels;
using plagiarismModel;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace plagiarism.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainViewModel model = null;
        public MainPage(Users user)
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;
            BindingContext = model = new MainViewModel() { User = user };
        }
        public async Task NavigateFromMenu(int id, Users user)
        {
            user = model.User;
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Menu:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.Profile:
                        MenuPages.Add(id, new NavigationPage(new ProfileDetailPage()));
                        break;
                    case (int)MenuItemType.Documents:
                        MenuPages.Add(id, new NavigationPage(new DocumentsPage()));
                        break;
                    case (int)MenuItemType.AboutUs:
                        MenuPages.Add(id, new NavigationPage(new AboutPage(user)));
                        break;
                    case (int)MenuItemType.Card:
                        MenuPages.Add(id, new NavigationPage(new CardPage()));
                        break;
                    case (int)MenuItemType.Logout:
                        MenuPages.Add(id, new NavigationPage(new LoginPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}
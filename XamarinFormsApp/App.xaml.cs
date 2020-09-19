using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsApp.Pages;

namespace XamarinFormsApp
{
    public partial class App : Application
    {
        private const string NotificationsEnabledKey = "NotificationsEnabled";

        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new ContactsPage());
            //MainPage = new NavigationPage(new ToolbarPage());
            //MainPage = new NavigationPage(new InstagramPage());
            //MainPage = new FormsPage();
            //MainPage = new NavigationPage(new TableViewPage());
            //MainPage = new NavigationPage(new ContactBookPage());
            //MainPage = new RecipesPage();
            //MainPage = new PostsPage();
            //MainPage = new NavigationPage(new MoviesPage());
            //MainPage = new NavigationPage(new PlaylistsPage());

            MainPage = new KeypadPage();

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

        public bool NotificationsEnabled { 
            get
            {
                if (Properties.ContainsKey(NotificationsEnabledKey))
                    return (bool)Properties[NotificationsEnabledKey];

                return false;
            }
            set
            {
                Application.Current.Properties[NotificationsEnabledKey] = value;
            }
        }
    }
}

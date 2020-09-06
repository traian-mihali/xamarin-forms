using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsApp.Pages;

namespace XamarinFormsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new ContactsPage());
            //MainPage = new NavigationPage(new ToolbarPage());
            //MainPage = new NavigationPage(new InstagramPage());
            //MainPage = new FormsPage()
            MainPage = new TableViewPage();

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

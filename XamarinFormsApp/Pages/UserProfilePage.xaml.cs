using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsApp.Models;
using XamarinFormsApp.Services;

namespace XamarinFormsApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfilePage : ContentPage
    {
        private UserService _service = new UserService();
        public UserProfilePage(int userId)
        {
            BindingContext = _service.GetUser(userId);

            InitializeComponent();
        }
    }
}
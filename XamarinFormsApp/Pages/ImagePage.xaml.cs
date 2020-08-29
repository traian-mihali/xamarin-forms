using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        public ImagePage()
        {
            InitializeComponent();

            //SetBackgroundImage();
        }

        private void SetBackgroundImage()
        {
            //var imageSrc = UriImageSource.FromUri(new Uri("http://lorempixel.com/1920/1080/sports/5/"));

            var imageSrc = new UriImageSource { Uri = new Uri("http://lorempixel.com/1920/1080/sports/5/") };

            imageSrc.CacheValidity = TimeSpan.FromHours(1);
            imageSrc.CachingEnabled = false;

            //image.Aspect = Aspect.AspectFill;
            //image.Source = imageSrc;

            //image.Source = UriImageSource.FromResource("XamarinFormsApp.Images.background.jpg");

        }
    }
}
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
    public partial class PhotoGalleryPage : ContentPage
    {
        private int _currentImageId = 1;

        public PhotoGalleryPage()
        {
            InitializeComponent();

            LoadImage();
        }

        private void LoadImage()
        {
            image.Source = new UriImageSource
            {
                Uri = new Uri(String.Format("http://lorempixel.com/1920/1080/city/{0}", _currentImageId)),
                CachingEnabled = false
            };
        }

        private void Previous_Clicked(object sender, EventArgs e)
        {
            _currentImageId--;
            if (_currentImageId < 1)
                _currentImageId = 10;

            LoadImage();

        }

        private void Next_Clicked(object sender, EventArgs e)
        {
            _currentImageId++;
            if (_currentImageId > 10)
                _currentImageId = 1;

            LoadImage();
        }
    }
}
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
    public partial class StackPage : ContentPage
    {
        public StackPage()
        {
            InitializeComponent();

            GenerateStackLayout();
        }

        private void GenerateStackLayout()
        {
            var layout = new StackLayout
            {
                Spacing = 40,
                Padding = 20,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Azure
            };

            layout.Children.Add(new Label { Text = "Label 1" });
            layout.Children.Add(new Label { Text = "Label 2" });
            layout.Children.Add(new Label { Text = "Label 3" });

            Content = layout;
        }
    }
}
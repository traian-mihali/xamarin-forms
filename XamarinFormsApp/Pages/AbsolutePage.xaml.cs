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
    public partial class AbsolutePage : ContentPage
    {
        public AbsolutePage()
        {
            InitializeComponent();

            GenerateAbsoluteLayoutContent();
        }

        private void GenerateAbsoluteLayoutContent()
        {
            var layout = new AbsoluteLayout();

            var aquaBox = new BoxView { Color = Color.Aqua };
            var button = new Button { Text = "Move Box", BackgroundColor = Color.Silver, TextColor = Color.White };
            layout.Children.Add(aquaBox, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            layout.Children.Add(aquaBox, new Rectangle(0.1, 0.1, 100, 100), AbsoluteLayoutFlags.PositionProportional);
            layout.Children.Add(button, new Rectangle(0, 1, 1, 50), AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);

            var left = true;
            var top = true;

            button.Clicked += (object obj, EventArgs args) => 
            {
                var x = top ? 0.9 : 0.1;
                var y = left ? 0.1 : 0.9;

                var previousTop = top;
                top = left;
                left = !previousTop;

                AbsoluteLayout.SetLayoutBounds(aquaBox, new Rectangle(x, y, 100, 100));
            };

            Content = layout;
        }
    }
}
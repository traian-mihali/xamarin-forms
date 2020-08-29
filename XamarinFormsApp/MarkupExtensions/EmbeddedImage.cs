using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsApp.MarkupExtensions
{
    [ContentProperty("ResourceId")]
    class EmbeddedImage : IMarkupExtension
    {
        public string ResourceId { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return UriImageSource.FromResource("XamarinFormsApp.Images.background.jpg");
        }
    }
}

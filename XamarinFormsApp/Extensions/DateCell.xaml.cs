using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsApp.Extensions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateCell : ViewCell
    {
        private static readonly BindableProperty LabelProperty = BindableProperty.Create("Label", typeof(string), typeof(DateCell));

        private static readonly BindableProperty DateProperty = BindableProperty.Create("Date", typeof(string), typeof(DateCell));
        public string Date { 
            get { return (string)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        public string Label { 
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); } 
        }
        public DateCell()
        {
            InitializeComponent();

            BindingContext = this;
        }
    }
}
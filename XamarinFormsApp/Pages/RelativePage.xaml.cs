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
    public partial class RelativePage : ContentPage
    {
        public RelativePage()
        {
            InitializeComponent();

            //GenerateRelativeLayoutView();
        }

        private void GenerateRelativeLayoutView()
        {
            var layout = new RelativeLayout();
            Content = layout;

            var aquaBox = new BoxView { Color = Color.Aquamarine };
            layout.Children.Add(aquaBox, widthConstraint: Constraint.RelativeToParent(parent => parent.Width), heightConstraint: Constraint.RelativeToParent(parent => parent.Height * 0.3));

            var moccasinBox = new BoxView { Color = Color.Moccasin };
            layout.Children.Add(moccasinBox, yConstraint: Constraint.RelativeToView(aquaBox, (RelativeLayout, elem) => elem.Height - 50), 
                                             xConstraint: Constraint.RelativeToParent(parent => parent.Width * 0.3),
                                             widthConstraint: Constraint.RelativeToParent(parent => parent.Width * 0.4),
                                             heightConstraint: Constraint.RelativeToView(aquaBox, (RelativeLayout, elem) => elem.Height * 0.5));
        }
    }
}
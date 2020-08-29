using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GridPage : ContentPage
    {
        public GridPage()
        {
            InitializeComponent();

            GenerateGridContent();
        }

        private void GenerateGridContent()
        {
            var grid = new Grid
            {
                RowSpacing = 20,
                ColumnSpacing = 40
            };

            var label1 = new Label { Text = "Label 1", BackgroundColor = Color.Yellow };
            var label2 = new Label { Text = "Label 2", BackgroundColor = Color.Blue };
            var label3 = new Label { Text = "Label 3", BackgroundColor = Color.Red };
            var label4 = new Label { Text = "Label 4", BackgroundColor = Color.Silver };
            var label5 = new Label { Text = "Label 5", BackgroundColor = Color.Green };
            var label6 = new Label { Text = "Label 6", BackgroundColor = Color.Orange };




            grid.Children.Add(label1, 0, 0);
            grid.Children.Add(label2, 1, 0);
            grid.Children.Add(label3, 0, 1);
            grid.Children.Add(label4, 1, 1);
            grid.Children.Add(label5, 0, 2);
            grid.Children.Add(label6, 1, 2);


            Grid.SetRowSpan(label1, 2);
            Grid.SetColumnSpan(label2, 2);
            //Grid.SetRow(label5, 2);
            //Grid.SetColumn(label6, 2);

            grid.RowDefinitions.Add(new RowDefinition
            {
                Height = new GridLength(100, GridUnitType.Absolute)
            });

            grid.RowDefinitions.Add(new RowDefinition
            {
                Height = new GridLength(2, GridUnitType.Star)
            });

            grid.RowDefinitions.Add(new RowDefinition
            {
                Height = new GridLength(1, GridUnitType.Auto)
            });

            grid.ColumnDefinitions.Add(new ColumnDefinition
            {
                Width = new GridLength(100, GridUnitType.Absolute)
            });

            grid.ColumnDefinitions.Add(new ColumnDefinition
            {
                Width = new GridLength(2, GridUnitType.Star)
            });

            grid.ColumnDefinitions.Add(new ColumnDefinition
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });


            Content = grid;
        }
    }
}
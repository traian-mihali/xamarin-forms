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
    public partial class QuotesPage : ContentPage
    {
        private string[] _quotes = new string[]
        {
            "“Be yourself; everyone else is already taken.” \n― Oscar Wilde",
            "“Two things are infinite: the universe and human stupidity; and I'm not sure about the universe.” \n― Albert Einstein",
            "“So many books, so little time.” \n― Frank Zappa",
            "“Be who you are and say what you feel, because those who mind don't matter, and those who matter don't mind.” \n― Bernard M. Baruch",
            "“A room without books is like a body without a soul.” \n― Marcus Tullius Cicero",
            "“You've gotta dance like there's nobody watching, \nLove like you'll never be hurt, \nSing like there's nobody listening, \nAnd live like it's heaven on earth.” \n― William W. Purkey"
        };

        private int _index = 0;

        public QuotesPage()
        {
            InitializeComponent();

            currentQuote.Text = _quotes[_index];
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _index++;

            if (_index >= _quotes.Length)
                _index = 0;

            currentQuote.Text = _quotes[_index];
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XamarinFormsApp.Models
{
    public class Post : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        public string Body { get; set; }

        private string _title;
        public string Title {
            get { return _title; }
            set
            {
                if (_title == value)
                    return;

                _title = value;

                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string postName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(postName));
        }
    }
}

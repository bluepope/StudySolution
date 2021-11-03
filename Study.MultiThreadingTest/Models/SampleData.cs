using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Study.MultiThreadingTest.Models
{
    public class SampleData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        string _col1;
        public string Col1
        {
            get
            {
                return _col1;
            }
            set
            {
                _col1 = value;
                RaisePropertyChanged();
            }
        }
    }
}

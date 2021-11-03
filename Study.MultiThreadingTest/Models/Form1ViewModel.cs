using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Study.MultiThreadingTest.Models
{
    public class Form1ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //backing field 
        string _percentText;
        public string PercentText 
        {
            get
            {
                return _percentText;
            }
            set
            {
                _percentText = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PercentText")); //인터넷에서 찾아볼수있는 일반적인 예제
                RaisePropertyChanged();
            }
        }


        public BindingList<SampleData> SampleDataList { get; set; } = new BindingList<SampleData>();
    }
}

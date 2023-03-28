using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculatorApp
{
    public class NumberClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _mainInput;
        public NumberClass()
        {
        }
        public string MainInput 
        {
            get { return _mainInput; }
            set { 
                _mainInput = value;
                NotifyPropertyChanged();
                }
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        
        }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace wpf.Viewmodels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        // BaseViewModel wordt gebruikt om interfaces te implementeren die bij elke viewmodel gebruikt moeten worden (hier enkel INotifyPropertyChanged voor databinding)
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
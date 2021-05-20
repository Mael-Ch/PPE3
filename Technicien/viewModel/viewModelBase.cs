using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Technicien.viewModel
{
    class viewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string caller = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}

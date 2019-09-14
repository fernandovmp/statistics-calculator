using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace StatisticsCalculator.ViewModels
{
    public class ViewModelBase : BindableObject
    {
        protected void SetProperty<T>(ref T attribute, T value, [CallerMemberName] string propertyName = "")
        {
            attribute = value;
            OnPropertyChanged(propertyName);
        }
    }
}

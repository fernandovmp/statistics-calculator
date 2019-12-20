using StatisticsCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace StatisticsCalculator.ViewModels
{
    public class SampleItemViewModel : ViewModelBase
    {
        private readonly SampleViewModel _sampleViewModel;
        private ICommand _removeItemCommand;

        public SampleItemViewModel(SampleItem itemValue)
        {
            ItemValue = itemValue;
        }

        public SampleItemViewModel(SampleItem itemValue, SampleViewModel sampleViewModel) : this(itemValue)
        {
            _sampleViewModel = sampleViewModel;
        }

        public SampleItem ItemValue { get; }

        public ICommand RemoveItemCommand
        {
            get
            {
                if(_removeItemCommand == null)
                {
                    _removeItemCommand = new Command(RemoveItem);
                }
                return _removeItemCommand;
            }
            set => SetProperty(ref _removeItemCommand, value);
        }

        public void RemoveItem(object parameter)
        {
            _sampleViewModel?.SampleItems.Remove(this);
        }
    }
}

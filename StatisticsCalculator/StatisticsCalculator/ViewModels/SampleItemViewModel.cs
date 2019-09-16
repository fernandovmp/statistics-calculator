using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace StatisticsCalculator.ViewModels
{
    public class SampleItemViewModel : ViewModelBase
    {
        private double _itemValue;
        private SampleViewModel _sampleViewModel;
        private ICommand _removeItemCommand;

        public SampleItemViewModel(double itemValue)
        {
            _itemValue = itemValue;
        }

        public SampleItemViewModel(double itemValue, SampleViewModel sampleViewModel) : this(itemValue)
        {
            _sampleViewModel = sampleViewModel;
        }

        public double ItemValue
        {
            get => _itemValue;
            set => SetProperty(ref _itemValue, value);
        }
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

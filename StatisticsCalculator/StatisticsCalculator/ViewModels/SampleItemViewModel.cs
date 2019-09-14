using System;
using System.Collections.Generic;
using System.Text;

namespace StatisticsCalculator.ViewModels
{
    public class SampleItemViewModel : ViewModelBase
    {
        private double _itemValue;

        public SampleItemViewModel(double itemValue)
        {
            _itemValue = itemValue;
        }

        public double ItemValue
        {
            get => _itemValue;
            set => SetProperty(ref _itemValue, value);
        }
    }
}

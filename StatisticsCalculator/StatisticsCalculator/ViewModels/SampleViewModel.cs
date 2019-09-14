using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace StatisticsCalculator.ViewModels
{
    public class SampleViewModel : ViewModelBase
    {
        private ObservableCollection<SampleItemViewModel> _sampleItems;

        public SampleViewModel()
        {
            _sampleItems = new ObservableCollection<SampleItemViewModel>
            {
                new SampleItemViewModel(100),
                new SampleItemViewModel(200),
                new SampleItemViewModel(300),
                new SampleItemViewModel(400)
            };
        }

        public ObservableCollection<SampleItemViewModel> SampleItems
        {
            get => _sampleItems;
            set => SetProperty(ref _sampleItems, value);
        }
    }
}

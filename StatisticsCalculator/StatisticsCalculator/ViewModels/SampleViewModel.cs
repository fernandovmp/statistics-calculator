using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace StatisticsCalculator.ViewModels
{
    public class SampleViewModel : ViewModelBase
    {
        private ObservableCollection<SampleItemViewModel> _sampleItems;
        private ICommand _addSampleItemCommand;
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
        public ICommand AddSampleItemCommand
        {
            get
            {
                if(_addSampleItemCommand == null)
                {
                     _addSampleItemCommand = new Command(AddSampleItem);
                }
                return _addSampleItemCommand;
            }
            set => SetProperty(ref _addSampleItemCommand, value);
        }

        public void AddSampleItem(object parameter)
        {
            if(parameter is string valueText 
                && !string.IsNullOrWhiteSpace(valueText) 
                && double.TryParse(valueText, out double value))
            {
                SampleItems.Add(new SampleItemViewModel(value));
            }
        }
    }
}

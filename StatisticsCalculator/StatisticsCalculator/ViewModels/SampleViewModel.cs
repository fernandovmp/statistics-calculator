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
        private ICommand _ClearSampleCommand;

        public SampleViewModel()
        {
            _sampleItems = new ObservableCollection<SampleItemViewModel>();
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
        public ICommand ClearSampleCommand
        {
            get
            {
                if (_ClearSampleCommand == null)
                {
                    _ClearSampleCommand = new Command(ClearSample);
                }
                return _ClearSampleCommand;
            }
            set => SetProperty(ref _ClearSampleCommand, value);
        }

        public void AddSampleItem(object parameter)
        {
            if(parameter is string valueText 
                && !string.IsNullOrWhiteSpace(valueText) 
                && double.TryParse(valueText, out double value))
            {
                SampleItems.Add(new SampleItemViewModel(value));
                MessagingCenter.Send<SampleViewModel, ICollection<SampleItemViewModel>>(this,
                    "SampleUpdated", SampleItems);
            }
        }

        public void ClearSample(object parameter)
        {
            SampleItems.Clear();
            MessagingCenter.Send<SampleViewModel, ICollection<SampleItemViewModel>>(this,
                    "SampleUpdated", SampleItems);
        }
    }
}

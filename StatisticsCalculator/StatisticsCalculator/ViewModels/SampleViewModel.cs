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
        private string _entrySampleText;

        public SampleViewModel()
        {
            _sampleItems = new ObservableCollection<SampleItemViewModel>();
            _sampleItems.CollectionChanged += (sender, e) =>
            {
                MessagingCenter.Send(this,
                    "SampleUpdated", (ICollection<SampleItemViewModel>)sender);
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
        public string EntrySampleText
        {
            get => _entrySampleText;
            set => SetProperty(ref _entrySampleText, value);
        }

        public void AddSampleItem(object parameter)
        {
            if(!string.IsNullOrWhiteSpace(EntrySampleText) 
                && double.TryParse(EntrySampleText, out double value))
            {
                SampleItems.Add(new SampleItemViewModel(value, this));
                EntrySampleText = "";
            }
        }

        public void ClearSample(object parameter)
        {
            SampleItems.Clear();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using StatisticsCalculator.Models;
using StatisticsCalculator.Translation;
using Xamarin.Forms;

namespace StatisticsCalculator.ViewModels
{
    public enum SampleMode { Simple, Pair }
    public class SampleViewModel : ViewModelBase
    {
        private SampleMode _sampleMode;
        private ObservableCollection<SampleItemViewModel> _sampleItems;
        private ICommand _addSampleItemCommand;
        private ICommand _clearSampleCommand;
        private string _entrySampleText;
        private string _entryValueOfYText;
        private readonly string _pairModeText = "PairModeText".Translate();
        private readonly string _simpleModeText = "SimpleModeText".Translate();
        private string _switchModeText;

        public SampleViewModel()
        {
            _sampleItems = new ObservableCollection<SampleItemViewModel>();
            _sampleItems.CollectionChanged += (sender, e) =>
            {
                MessagingCenter.Send(this,
                    "SampleUpdated", (ICollection<SampleItemViewModel>)sender);
            };
            SwitchModeCommand = new Command(SwitchMode);
            _switchModeText = _simpleModeText;
        }

        public ObservableCollection<SampleItemViewModel> SampleItems
        {
            get => _sampleItems;
            set => SetProperty(ref _sampleItems, value);
        }
        public SampleMode SampleMode 
        {
            get => _sampleMode; 
            private set => SetProperty(ref _sampleMode, value); 
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
                if (_clearSampleCommand == null)
                {
                    _clearSampleCommand = new Command(ClearSample);
                }
                return _clearSampleCommand;
            }
            set => SetProperty(ref _clearSampleCommand, value);
        }
        public ICommand SwitchModeCommand { get; private set; }
        public string EntrySampleText
        {
            get => _entrySampleText;
            set => SetProperty(ref _entrySampleText, value);
        }
        public string EntryValueOfYText
        {
            get => _entryValueOfYText;
            set => SetProperty(ref _entryValueOfYText, value);
        }
        public string SwitchModeText
        {
            get => _switchModeText;
            set => SetProperty(ref _switchModeText, value);
        }

        public void AddSampleItem(object parameter)
        {
            double value = 0, valueOfY;
            SampleItem sampleItem = null;
            bool simpleSampleValidation = !string.IsNullOrWhiteSpace(EntrySampleText)
                && double.TryParse(EntrySampleText, out value);

            if (SampleMode == SampleMode.Simple && simpleSampleValidation)
            {
                sampleItem = new SampleItem(value);
            }
            if (SampleMode == SampleMode.Pair 
                && simpleSampleValidation
                && !string.IsNullOrWhiteSpace(EntryValueOfYText)
                && double.TryParse(EntryValueOfYText, out valueOfY))
            {
                sampleItem = new SampleItem(value, valueOfY);
            }

            SampleItems.Add(new SampleItemViewModel(sampleItem ?? new SampleItem(0), this));
            EntrySampleText = "";
            EntryValueOfYText = "";
        }

        public void ClearSample(object parameter)
        {
            SampleItems.Clear();
        }

        public void SwitchMode()
        {
            if(SampleMode == SampleMode.Simple)
            {
                SampleMode = SampleMode.Pair;
                SwitchModeText = _pairModeText;
            } 
            else
            {
                SampleMode = SampleMode.Simple;
                SwitchModeText = _simpleModeText;
            }
            ClearSample(null);
        }

    }
}

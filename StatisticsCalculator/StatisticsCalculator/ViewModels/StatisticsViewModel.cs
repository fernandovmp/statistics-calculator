using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Linq;
using StatisticsCore;
using Xamarin.Forms;

namespace StatisticsCalculator.ViewModels
{
    public class StatisticsViewModel : ViewModelBase
    {
        private string _result;
        private string _resultLabel;
        private SampleMode _sampleMode;

        public StatisticsViewModel()
        {
            MessagingCenter.Subscribe<SampleViewModel,
                ICollection<SampleItemViewModel>>(this, "SampleUpdated", (sender, parameter) =>
                {
                    Sample = parameter;
                    OnPropertyChanged(nameof(Sample));
                    SampleMode = sender.SampleMode;
                });
        }

        public ICollection<SampleItemViewModel> Sample { get; private set; }
        public string Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }
        public string ResultLabel
        {
            get => _resultLabel;
            set => SetProperty(ref _resultLabel, value);
        }
        public SampleMode SampleMode
        {
            get => _sampleMode;
            private set => SetProperty(ref _sampleMode, value);
        }
    }
}

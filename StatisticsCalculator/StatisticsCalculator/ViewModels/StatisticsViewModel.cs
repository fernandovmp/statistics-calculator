using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using StatisticsCore;
using System.Linq;
using Xamarin.Forms;

namespace StatisticsCalculator.ViewModels
{
    public class StatisticsViewModel : ViewModelBase
    {
        private string _result;
        private ICommand _sumCommand;
        private ICommand _sumOfSquareCommand;
        private ICommand _meanCommand;
        private ICommand _medianCommand;
        private ICommand _modeCommand;
        private ICollection<SampleItemViewModel> _sample;
        public StatisticsViewModel()
        {
            MessagingCenter.Subscribe<SampleViewModel, 
                ICollection<SampleItemViewModel>>(this, "SampleUpdated", (sender, parameter) =>
                {
                    _sample = parameter;
                });
        }

        public string Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }
        public ICommand SumCommand
        {
            get
            {
                if(_sumCommand == null)
                {
                    _sumCommand = new Command(Sum);
                }
                return _sumCommand;
            }
            set => SetProperty(ref _sumCommand, value);
        }
        public ICommand SumOfSquareCommand
        {
            get
            {
                if (_sumOfSquareCommand == null)
                {
                    _sumOfSquareCommand = new Command(SumOfSquare);
                }
                return _sumOfSquareCommand;
            }
            set => SetProperty(ref _sumOfSquareCommand, value);
        }
        public ICommand MeanCommand
        {
            get
            {
                if (_meanCommand == null)
                {
                    _meanCommand = new Command(Mean);
                }
                return _meanCommand;
            }
            set => SetProperty(ref _meanCommand, value);
        }
        public ICommand MedianCommand
        {
            get
            {
                if (_medianCommand == null)
                {
                    _medianCommand = new Command(Median);
                }
                return _medianCommand;
            }
            set => SetProperty(ref _medianCommand, value);
        }
        public ICommand ModeCommand
        {
            get
            {
                if (_modeCommand == null)
                {
                    _modeCommand = new Command(Mode);
                }
                return _modeCommand;
            }
            set => SetProperty(ref _modeCommand, value);
        }

        public void Sum(object parameter)
        {
            if (_sample == null) return;
            double[] sampleValues = GetSampleValuesArray();
            double sum = Statistics.SumOfItems(sampleValues);
            Result = sum.ToString();
        }

        public void SumOfSquare(object parameter)
        {
            if (_sample == null) return;
            double[] sampleValues = GetSampleValuesArray();
            double sum = Statistics.SumOfSquareOfItems(sampleValues);
            Result = sum.ToString();
        }

        public void Mean(object parameter)
        {
            if (_sample == null) return;
            double[] sampleValues = GetSampleValuesArray();
            double mean = Statistics.Mean(sampleValues);
            Result = mean.ToString();
        }

        public void Median(object parameter)
        {
            if (_sample == null) return;
            double[] sampleValues = GetSampleValuesArray();
            double median = Statistics.Median(sampleValues);
            Result = median.ToString();
        }

        public void Mode(object parameter)
        {
            if (_sample == null) return;
            double[] sampleValues = GetSampleValuesArray();
            List<double> mode = Statistics.Mode(sampleValues);
            IEnumerable<string> modeString = mode.Select(i => i.ToString());
            Result = $"Moda: {string.Join(", ", modeString.ToArray())}";
        }

        private double[] GetSampleValuesArray()
        {
            List<double> collection = new List<double>();
            foreach (SampleItemViewModel item in _sample)
            {
                collection.Add(item.ItemValue);
            }
            return collection.ToArray();
        }
    }
}

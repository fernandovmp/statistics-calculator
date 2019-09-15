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
        private ICommand _sumCommand;
        private ICommand _sumOfSquareCommand;
        private ICommand _meanCommand;
        private ICommand _medianCommand;
        private ICommand _modeCommand;
        private ICommand _sampleStandardDeviationCommand;
        private ICommand _populationStandardDeviationCommand;
        private ICommand _sampleVarianceCommand;
        private ICommand _populationVarianceCommand;
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
        public ICommand SampleStandardDeviationCommand
        {
            get
            {
                if (_sampleStandardDeviationCommand == null)
                {
                    _sampleStandardDeviationCommand = new Command(SampleStandardDeviation);
                }
                return _sampleStandardDeviationCommand;
            }
            set => SetProperty(ref _sampleStandardDeviationCommand, value);
        }
        public ICommand PopulationStandardDeviationCommand
        {
            get
            {
                if (_populationStandardDeviationCommand == null)
                {
                    _populationStandardDeviationCommand = new Command(PopulationStandardDeviation);
                }
                return _populationStandardDeviationCommand;
            }
            set => SetProperty(ref _populationStandardDeviationCommand, value);
        }
        public ICommand SampleVarianceCommand
        {
            get
            {
                if (_sampleVarianceCommand == null)
                {
                    _sampleVarianceCommand = new Command(SampleVariance);
                }
                return _sampleVarianceCommand;
            }
            set => SetProperty(ref _sampleVarianceCommand, value);
        }
        public ICommand PopulationVarianceCommand
        {
            get
            {
                if (_populationVarianceCommand == null)
                {
                    _populationVarianceCommand = new Command(PopulationVariance);
                }
                return _populationVarianceCommand;
            }
            set => SetProperty(ref _populationVarianceCommand, value);
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

        public void SampleStandardDeviation(object parameter)
        {
            if (_sample == null || _sample.Count < 2) return;
            double[] sampleValues = GetSampleValuesArray();
            double deviation = Statistics.SampleStandardDeviation(sampleValues);
            Result = deviation.ToString();
        }

        public void PopulationStandardDeviation(object parameter)
        {
            if (_sample == null) return;
            double[] sampleValues = GetSampleValuesArray();
            double deviation = Statistics.PopulationStandardDeviation(sampleValues);
            Result = deviation.ToString();
        }

        public void SampleVariance(object parameter)
        {
            if (_sample == null || _sample.Count < 2) return;
            double[] sampleValues = GetSampleValuesArray();
            double variance = Statistics.SampleVariance(sampleValues);
            Result = variance.ToString();
        }

        public void PopulationVariance(object parameter)
        {
            if (_sample == null || _sample.Count < 2) return;
            double[] sampleValues = GetSampleValuesArray();
            double variance = Statistics.PopulationVariance(sampleValues);
            Result = variance.ToString();
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

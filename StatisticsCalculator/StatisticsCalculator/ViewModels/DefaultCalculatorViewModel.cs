using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using StatisticsCore;
using Xamarin.Forms;

namespace StatisticsCalculator.ViewModels
{
    public class DefaultCalculatorViewModel : BaseCalculatorViewModel
    {
        private ICommand _sumCommand;
        private ICommand _sumOfSquareCommand;
        private ICommand _meanCommand;
        private ICommand _medianCommand;
        private ICommand _modeCommand;
        private ICommand _sampleStandardDeviationCommand;
        private ICommand _populationStandardDeviationCommand;
        private ICommand _sampleVarianceCommand;
        private ICommand _populationVarianceCommand;

        public DefaultCalculatorViewModel(StatisticsViewModel statisticsViewModel) : base(statisticsViewModel)
        {
            _sumCommand = new Command(Sum);
            _sumOfSquareCommand = new Command(SumOfSquare);
            _meanCommand = new Command(Mean);
            _medianCommand = new Command(Median);
            _modeCommand = new Command(Mode);
            _sampleStandardDeviationCommand = new Command(SampleStandardDeviation);
            _populationStandardDeviationCommand = new Command(PopulationStandardDeviation);
            _sampleVarianceCommand = new Command(SampleVariance);
            _populationVarianceCommand = new Command(PopulationVariance);
        }

        public ICommand SumCommand
        {
            get => _sumCommand;
            set => SetProperty(ref _sumCommand, value);
        }
        public ICommand SumOfSquareCommand
        {
            get => _sumOfSquareCommand;
            set => SetProperty(ref _sumOfSquareCommand, value);
        }
        public ICommand MeanCommand
        {
            get => _meanCommand;
            set => SetProperty(ref _meanCommand, value);
        }
        public ICommand MedianCommand
        {
            get =>_medianCommand;
            set => SetProperty(ref _medianCommand, value);
        }
        public ICommand ModeCommand
        {
            get => _modeCommand;
            set => SetProperty(ref _modeCommand, value);
        }
        public ICommand SampleStandardDeviationCommand
        {
            get => _sampleStandardDeviationCommand;
            set => SetProperty(ref _sampleStandardDeviationCommand, value);
        }
        public ICommand PopulationStandardDeviationCommand
        {
            get => _populationStandardDeviationCommand;
            set => SetProperty(ref _populationStandardDeviationCommand, value);
        }
        public ICommand SampleVarianceCommand
        {
            get => _sampleVarianceCommand;
            set => SetProperty(ref _sampleVarianceCommand, value);
        }
        public ICommand PopulationVarianceCommand
        {
            get => _populationVarianceCommand;
            set => SetProperty(ref _populationVarianceCommand, value);
        }

        private void Sum(object parameter)
        {
            if (_statisticsViewModel.Sample == null) return;
            double[] sampleValues = GetSampleValuesArray();
            double sum = Statistics.SumOfItems(sampleValues);
            SetLabel(sum.ToString(), parameter);
        }

        private void SumOfSquare(object parameter)
        {
            if (_statisticsViewModel.Sample == null) return;
            double[] sampleValues = GetSampleValuesArray();
            double sum = Statistics.SumOfSquareOfItems(sampleValues);
            SetLabel(sum.ToString(), parameter);
        }

        private void Mean(object parameter)
        {
            if (_statisticsViewModel.Sample == null || _statisticsViewModel.Sample.Count == 0) return;
            double[] sampleValues = GetSampleValuesArray();
            double mean = Statistics.Mean(sampleValues);
            SetLabel(mean.ToString(), parameter);
        }

        private void Median(object parameter)
        {
            if (_statisticsViewModel.Sample == null || _statisticsViewModel.Sample.Count == 0) return;
            double[] sampleValues = GetSampleValuesArray();
            double median = Statistics.Median(sampleValues);
            SetLabel(median.ToString(), parameter);
        }

        private void Mode(object parameter)
        {
            if (_statisticsViewModel.Sample == null) return;
            double[] sampleValues = GetSampleValuesArray();
            List<double> mode = Statistics.Mode(sampleValues);
            IEnumerable<string> modeString = mode.Select(i => i.ToString());
            SetLabel(string.Join(", ", modeString.ToArray()), parameter);
        }

        private void SampleStandardDeviation(object parameter)
        {
            if (_statisticsViewModel.Sample == null || _statisticsViewModel.Sample.Count < 2) return;
            double[] sampleValues = GetSampleValuesArray();
            double deviation = Statistics.SampleStandardDeviation(sampleValues);
            SetLabel(deviation.ToString(), parameter);
        }

        private void PopulationStandardDeviation(object parameter)
        {
            if (_statisticsViewModel.Sample == null || _statisticsViewModel.Sample.Count < 2) return;
            double[] sampleValues = GetSampleValuesArray();
            double deviation = Statistics.PopulationStandardDeviation(sampleValues);
            SetLabel(deviation.ToString(), parameter);
        }

        private void SampleVariance(object parameter)
        {
            if (_statisticsViewModel.Sample == null || _statisticsViewModel.Sample.Count < 2) return;
            double[] sampleValues = GetSampleValuesArray();
            double variance = Statistics.SampleVariance(sampleValues);
            SetLabel(variance.ToString(), parameter);
        }

        private void PopulationVariance(object parameter)
        {
            if (_statisticsViewModel.Sample == null || _statisticsViewModel.Sample.Count < 2) return;
            double[] sampleValues = GetSampleValuesArray();
            double variance = Statistics.PopulationVariance(sampleValues);
            SetLabel(variance.ToString(), parameter);
        }
    }
}

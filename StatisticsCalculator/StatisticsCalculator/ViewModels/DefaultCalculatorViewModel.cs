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

        public DefaultCalculatorViewModel(StatisticsViewModel statisticsViewModel) : base(statisticsViewModel)
        {
            SumCommand = new Command(Sum);
            SumOfSquareCommand = new Command(SumOfSquare);
            MeanCommand = new Command(Mean);
            MedianCommand = new Command(Median);
            ModeCommand = new Command(Mode);
            SampleStandardDeviationCommand = new Command(SampleStandardDeviation);
            PopulationStandardDeviationCommand = new Command(PopulationStandardDeviation);
            SampleVarianceCommand = new Command(SampleVariance);
            PopulationVarianceCommand = new Command(PopulationVariance);
        }

        public ICommand SumCommand { get; private set; }
        public ICommand SumOfSquareCommand { get; private set; }
        public ICommand MeanCommand { get; private set; }
        public ICommand MedianCommand { get; private set; }
        public ICommand ModeCommand { get; private set; }
        public ICommand SampleStandardDeviationCommand { get; private set; }
        public ICommand PopulationStandardDeviationCommand { get; private set; }
        public ICommand SampleVarianceCommand { get; private set; }
        public ICommand PopulationVarianceCommand { get; private set; }

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

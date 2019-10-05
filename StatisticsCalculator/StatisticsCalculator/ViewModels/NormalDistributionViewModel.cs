using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using StatisticsCore;
using Xamarin.Forms;

namespace StatisticsCalculator.ViewModels
{
    public enum NormalDistributionMode { LessThan, Between, GreaterThan }
    public class NormalDistributionViewModel : BaseCalculatorViewModel
    {
        private string _comparerValue;
        private string _optionalComparerValue;
        private string _comparerText;
        private string _mean;
        private string _deviation;
        private bool _isBetweenValue;
        private NormalDistributionMode _normalDistributionMode;

        public NormalDistributionViewModel(StatisticsViewModel statisticsViewModel) : base(statisticsViewModel)
        {
            SetModeCommand = new Command(SetMode);
            CalculateCommand = new Command(Calculate);
            SetModeCommand.Execute(NormalDistributionMode.LessThan);
        }

        public string ComparerValue
        {
            get => _comparerValue;
            set => SetProperty(ref _comparerValue, value);
        }
        public string OptionalComparerValue
        {
            get => _optionalComparerValue;
            set => SetProperty(ref _optionalComparerValue, value);
        }
        public string ComparerText
        {
            get => _comparerText;
            set => SetProperty(ref _comparerText, value);
        }
        public string Mean
        {
            get => _mean;
            set => SetProperty(ref _mean, value);
        }
        public string Deviation
        {
            get => _deviation;
            set => SetProperty(ref _deviation, value);
        }
        public bool IsBetweenValue
        {
            get => _isBetweenValue;
            set => SetProperty(ref _isBetweenValue, value);
        }
        public ICommand SetModeCommand { get; private set; }
        public ICommand CalculateCommand { get; private set; }

        private void SetMode(object parameter)
        {
            if(parameter is NormalDistributionMode mode)
            {
                _normalDistributionMode = mode;
                switch (mode)
                {
                    case NormalDistributionMode.LessThan:
                        ComparerText = "x <=";
                        break;
                    case NormalDistributionMode.Between:
                        ComparerText = "<= x <=";
                        IsBetweenValue = true;
                        break;
                    case NormalDistributionMode.GreaterThan:
                        ComparerText = "x >=";
                        break;
                    default:
                        ComparerText = "";
                        break;
                }
                if(mode != NormalDistributionMode.Between)
                {
                    IsBetweenValue = false;
                }
            }
        }

        private void Calculate(object parameter)
        {
            if (!string.IsNullOrEmpty(ComparerValue) 
                && !string.IsNullOrEmpty(Mean)
                && !string.IsNullOrEmpty(Deviation)
                && double.TryParse(ComparerValue, out double comparer)
                && double.TryParse(Mean, out double mean)
                && double.TryParse(Deviation, out double deviation))
            {
                double result = 0;
                switch (_normalDistributionMode)
                {
                    case NormalDistributionMode.LessThan:
                        result = Statistics.NormalDistributionDensity(comparer, deviation, mean);
                        break;
                    case NormalDistributionMode.Between:
                        if(!string.IsNullOrEmpty(OptionalComparerValue)
                            && double.TryParse(OptionalComparerValue, out double optionalComparer)
                            && optionalComparer < comparer)
                        {
                            result = Statistics.NormalDistributionDensity(optionalComparer, comparer, 
                                deviation, mean);
                        }
                        break;
                    case NormalDistributionMode.GreaterThan:
                        result = Statistics.NormalDistributionDensity(comparer, deviation, mean, true);
                        break;
                    default:
                        result = 0;
                        break;
                }
                SetLabel(result.ToString("P2"), parameter);
            }
        }
    }
}

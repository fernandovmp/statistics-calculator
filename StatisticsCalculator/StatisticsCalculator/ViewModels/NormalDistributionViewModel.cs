using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace StatisticsCalculator.ViewModels
{
    public enum NormalDistributionMode { LessThan, Between, GreaterThan }
    public class NormalDistributionViewModel : BaseCalculatorViewModel
    {
        private string _comparerValue;
        private string _optionalComparerValue;
        private string _comparerText;
        private bool _isBetweenValue;
        private NormalDistributionMode _normalDistributionMode;
        private ICommand _setModeCommand;
        private ICommand _calculateCommand;

        public NormalDistributionViewModel(StatisticsViewModel statisticsViewModel) : base(statisticsViewModel)
        {
            _setModeCommand = new Command(SetMode);
            _calculateCommand = new Command(Calculate);
            _setModeCommand.Execute(NormalDistributionMode.LessThan);
        }

        public string CompararValue
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
        public bool IsBetweenValue
        {
            get => _isBetweenValue;
            set => SetProperty(ref _isBetweenValue, value);
        }
        public ICommand SetModeCommand
        {
            get => _setModeCommand;
            set => SetProperty(ref _setModeCommand, value);
        }
        public ICommand CalculateCommand
        {
            get => _calculateCommand;
            set => SetProperty(ref _calculateCommand, value);
        }

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
            double result = 0;
            SetLabel(result.ToString(), parameter);
        }
    }
}

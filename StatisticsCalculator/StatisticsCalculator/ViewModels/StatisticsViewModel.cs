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
        private ICommand _setCalculatorCommand;
        private ContentView _calculator;

        public StatisticsViewModel()
        {
            MessagingCenter.Subscribe<SampleViewModel,
                ICollection<SampleItemViewModel>>(this, "SampleUpdated", (sender, parameter) =>
                {
                    Sample = parameter;
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
        public ICommand SetCalculatorCommand
        {
            get
            {
                if (_setCalculatorCommand == null)
                {
                    _setCalculatorCommand = new Command(SetCalculator);
                }
                return _setCalculatorCommand;
            }
            set => SetProperty(ref _setCalculatorCommand, value);
        }
        public ContentView Calculator
        {
            get => _calculator;
            private set => SetProperty(ref _calculator, value);
        }

        internal void SetLabel(object parameter)
        {
            if (parameter is string label)
            {
                ResultLabel = label;
                return;
            }
            ResultLabel = "";
        }

        private void SetCalculator(object parameter)
        {
            if(parameter is ContentView calculatorView)
            {
                Calculator = calculatorView;
            }
        }

        public double[] GetSampleValuesArray()
        {
            List<double> collection = new List<double>();
            foreach (SampleItemViewModel item in Sample)
            {
                collection.Add(item.ItemValue);
            }
            return collection.ToArray();
        }
    }
}

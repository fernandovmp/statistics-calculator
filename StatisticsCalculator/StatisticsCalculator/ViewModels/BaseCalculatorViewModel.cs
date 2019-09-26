using System;
using System.Collections.Generic;
using System.Text;
using StatisticsCore;
using Xamarin.Forms;

namespace StatisticsCalculator.ViewModels
{
    public abstract class BaseCalculatorViewModel : ViewModelBase
    {
        protected StatisticsViewModel _statisticsViewModel;

        public BaseCalculatorViewModel(StatisticsViewModel statisticsViewModel)
        {
            _statisticsViewModel = statisticsViewModel;
        }

        protected double[] GetSampleValuesArray()
        {
            return _statisticsViewModel.GetSampleValuesArray();
        }

        protected void SetLabel(object parameter)
        {
            _statisticsViewModel.SetLabel(parameter);
        }

        protected void SetLabel(string result, object label)
        {
            _statisticsViewModel.Result = result;
            SetLabel(label);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using StatisticsCore;
using Xamarin.Forms;

namespace StatisticsCalculator.ViewModels
{
    public class StatisticsViewModel : ViewModelBase
    {
        private string _result;
        private ICommand _sumCommand;
        private ICommand _sumOfSquareCommand;
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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace StatisticsCalculator.Models
{
    public class SampleItem
    {

        private readonly KeyValuePair<double, double?> _valuePair;

        public SampleItem(double valueOfX, double? valueOfY)
        {
            _valuePair = new KeyValuePair<double, double?>(valueOfX, valueOfY);
        }

        public SampleItem(double value) : this(value, null)
        {
        }

        public double Value
        {
            get => _valuePair.Key;
        }
        public double? ValueOfY
        {
            get => _valuePair.Value;
        }

        public KeyValuePair<double, double> GetPairValue() => 
            new KeyValuePair<double, double>(Value, ValueOfY ?? 0);

    }
}

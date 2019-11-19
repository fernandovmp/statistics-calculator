using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StatisticsCalculator.Translation;
using StatisticsCore;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StatisticsCalculator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BinomialView : ContentView
    {
        public BinomialView()
        {
            InitializeComponent();
            SetBinomialRangeCommand = new Command<BinomialRange>(SetBinomialRange);
            BindingContext = this;
        }

        public static readonly BindableProperty ResultFieldProperty = BindableProperty.Create(nameof(ResultField),
            typeof(string), typeof(BinomialView), string.Empty, BindingMode.TwoWay);
        public static readonly BindableProperty ResultLabelProperty = BindableProperty.Create(nameof(ResultLabel),
            typeof(string), typeof(BinomialView), string.Empty, BindingMode.TwoWay);

        public string ResultField
        {
            get => (string)GetValue(ResultFieldProperty);
            set => SetValue(ResultFieldProperty, value);
        }
        public string ResultLabel
        {
            get => (string)GetValue(ResultLabelProperty);
            set => SetValue(ResultLabelProperty, value);
        }
        public BinomialRange BinomialRange { get; private set; }
        public ICommand SetBinomialRangeCommand { get; }

        private void Calculate(object sender, EventArgs e)
        {
            if (!int.TryParse(sampleEntry.Text, out int sample)
                || !int.TryParse(amountOfSuccessEntry.Text, out int successAmount)
                || !float.TryParse(successRateEntry.Text, out float successRate))
            {
                return;
            }
            IEnumerable<double> result = Statistics.Binomial(sample, successAmount, successRate, BinomialRange);
            int startRange = BinomialRange == BinomialRange.Max ? 0 : successAmount;
            ResultLabel = "Binomial";
            ResultField = "";
            for (int i = 0; i < result.Count(); i++)
            {
                ResultField += $"P[X = {startRange + i}] = {result.ElementAt(i)}\n";
            }
        }

        private void SetBinomialRange(BinomialRange range)
        {
            BinomialRange = range;
            OnPropertyChanged(nameof(BinomialRange));
        }
    }
}

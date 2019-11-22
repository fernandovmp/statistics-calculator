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

namespace StatisticsCalculator.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BinomialView : BaseCalculatorView
    {
        public BinomialView()
        {
            InitializeComponent();
            SetBinomialRangeCommand = new Command<BinomialRange>(SetBinomialRange);
            Content.BindingContext = this;
        }

        public BinomialRange BinomialRange { get; private set; }
        public ICommand SetBinomialRangeCommand { get; }

        protected virtual void Calculate(object sender, EventArgs e)
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
            ResultField = $"P[X = {startRange}] = {result.ElementAt(0).ToString("N4")}";
            for (int i = 1; i < result.Count(); i++)
            {
                ResultField += $"\nP[X = {startRange + i}] = {result.ElementAt(i).ToString("N4")}";
            }
        }

        protected void SetBinomialRange(BinomialRange range)
        {
            BinomialRange = range;
            OnPropertyChanged(nameof(BinomialRange));
        }
    }
}

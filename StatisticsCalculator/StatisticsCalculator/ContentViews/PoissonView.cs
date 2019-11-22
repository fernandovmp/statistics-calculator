using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StatisticsCore;

using Xamarin.Forms;

namespace StatisticsCalculator.ContentViews
{
    public class PoissonView : BinomialView
    {
        public PoissonView() : base()
        {

        }

        protected override void Calculate(object sender, EventArgs e)
        {
            if (!int.TryParse(sampleEntry.Text, out int sample)
                || !int.TryParse(amountOfSuccessEntry.Text, out int successAmount)
                || !float.TryParse(successRateEntry.Text, out float successRate))
            {
                return;
            }
            IEnumerable<double> result = Statistics.Poisson(successAmount, sample, successRate, BinomialRange);
            int startRange = BinomialRange == BinomialRange.Max ? 0 : successAmount;
            ResultLabel = "Poisson";
            ResultField = $"P[X = {startRange}] = {result.ElementAt(0).ToString("N4")}";
            for (int i = 1; i < result.Count(); i++)
            {
                ResultField += $"\nP[X = {startRange + i}] = {result.ElementAt(i).ToString("N4")}";
            }
        }
    }
}

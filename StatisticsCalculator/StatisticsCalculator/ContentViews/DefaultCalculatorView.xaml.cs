using StatisticsCalculator.Translation;
using StatisticsCalculator.ViewModels;
using StatisticsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StatisticsCalculator.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefaultCalculatorView : BaseCalculatorView
    {
        public DefaultCalculatorView()
        {
            InitializeComponent();
            SumCommand = new Command(Sum);
            SumOfSquareCommand = new Command(SumOfSquare);
            MeanCommand = new Command(Mean);
            MedianCommand = new Command(Median);
            ModeCommand = new Command(Mode);
            SampleStandardDeviationCommand = new Command(SampleStandardDeviation);
            PopulationStandardDeviationCommand = new Command(PopulationStandardDeviation);
            SampleVarianceCommand = new Command(SampleVariance);
            PopulationVarianceCommand = new Command(PopulationVariance);
            Content.BindingContext = this;
        }


        public static readonly BindableProperty SampleProperty = BindableProperty.Create(nameof(Sample),
            typeof(ICollection<SampleItemViewModel>), typeof(DefaultCalculatorView), null);

        public ICollection<SampleItemViewModel> Sample
        {
            get => (ICollection<SampleItemViewModel>)GetValue(SampleProperty);
            set => SetValue(SampleProperty, value);
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

        private void CalculatorOperation<T>(Func<T> operation, Func<T, string> resultFunc, string label)
        {
            T result = operation();
            ResultField = resultFunc(result);
            ResultLabel = label;
        }

        private void CalculatorOperation<T>(Func<T> operation, string label) =>
            CalculatorOperation(operation, r => r.ToString(), label);

        private double[] GetSampleDoubleArray() => Sample.Select(item => item.ItemValue.Value).ToArray();

        private void Sum()
        {
            if (Sample == null) return;
            CalculatorOperation(() => Statistics.SumOfItems(GetSampleDoubleArray()), 
                StringTranslationExtension.Translate("SumOfItemsLabel"));
        }

        private void SumOfSquare()
        {
            if (Sample == null) return;
            CalculatorOperation(() => Statistics.SumOfSquareOfItems(GetSampleDoubleArray()),
                StringTranslationExtension.Translate("SumOfSquareLabel"));
        }

        private void Mean(object parameter)
        {
            if (Sample == null || Sample.Count == 0) return;
            CalculatorOperation(() => Statistics.Mean(GetSampleDoubleArray()),
                StringTranslationExtension.Translate("MeanLabel"));
        }

        private void Median(object parameter)
        {
            if (Sample == null || Sample.Count == 0) return;
            CalculatorOperation(() => Statistics.Median(GetSampleDoubleArray()),
                StringTranslationExtension.Translate("MedianLabel"));
        }

        private void Mode()
        {
            if (Sample == null) return;
            CalculatorOperation(() => Statistics.Mode(GetSampleDoubleArray()),
                mode =>
                {
                    IEnumerable<string> modeString = mode.Select(i => i.ToString());
                    return string.Join(", ", modeString.ToArray());
                },
                StringTranslationExtension.Translate("ModeLabel"));
        }

        private void SampleStandardDeviation()
        {
            if (Sample == null || Sample.Count < 2) return;
            CalculatorOperation(() => Statistics.SampleStandardDeviation(GetSampleDoubleArray()),
                StringTranslationExtension.Translate("SampleStandardDeviationLabel"));
        }

        private void PopulationStandardDeviation()
        {
            if (Sample == null || Sample.Count < 2) return;
            CalculatorOperation(() => Statistics.PopulationStandardDeviation(GetSampleDoubleArray()),
                StringTranslationExtension.Translate("PopulationStandardDeviationLabel"));
        }

        private void SampleVariance()
        {
            if (Sample == null || Sample.Count < 2) return;
            CalculatorOperation(() => Statistics.SampleVariance(GetSampleDoubleArray()),
                StringTranslationExtension.Translate("SampleVarianceLabel"));
        }

        private void PopulationVariance()
        {
            if (Sample == null || Sample.Count < 2) return;
            CalculatorOperation(() => Statistics.SampleVariance(GetSampleDoubleArray()),
                StringTranslationExtension.Translate("PopulationVarianceLabel"));
        }
    }
}

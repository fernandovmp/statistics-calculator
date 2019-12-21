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
        private readonly string _calculateX;
        private readonly string _calculateY;
        private string _shiftText;
        private bool _isCalculatingX = true;

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

            string calculateLabel = "CalculateLabel".Translate();
            _calculateX = calculateLabel + " X";
            _calculateY = calculateLabel + " Y";
            ShiftText = _calculateX;
            ShiftCommand = new Command<SampleMode>(Shift, mode => mode == SampleMode.Pair);
            
            Content.BindingContext = this;
        }


        public static readonly BindableProperty SampleProperty = BindableProperty.Create(nameof(Sample),
            typeof(ICollection<SampleItemViewModel>), typeof(DefaultCalculatorView), null);
        public static readonly BindableProperty SampleModeProperty = BindableProperty.Create(nameof(SampleMode),
           typeof(SampleMode), typeof(DefaultCalculatorView), SampleMode.Simple, BindingMode.OneWay, null, 
           propertyChanged: OnSampleModeChanged);

        public ICollection<SampleItemViewModel> Sample
        {
            get => (ICollection<SampleItemViewModel>)GetValue(SampleProperty);
            set => SetValue(SampleProperty, value);
        }
        public SampleMode SampleMode
        {
            get => (SampleMode)GetValue(SampleModeProperty);
            set => SetValue(SampleModeProperty, value);
        }
        public string ShiftText
        {
            get => _shiftText;
            set
            {
                _shiftText = value;
                OnPropertyChanged(nameof(ShiftText));
            }
        }
        public bool IsCalculatingX
        {
            get => _isCalculatingX;
            set
            {
                _isCalculatingX = value;
                OnPropertyChanged(nameof(IsCalculatingX));
            }
        }
        public ICommand SumCommand { get; }
        public ICommand SumOfSquareCommand { get; }
        public ICommand MeanCommand { get; }
        public ICommand MedianCommand { get; }
        public ICommand ModeCommand { get; }
        public ICommand SampleStandardDeviationCommand { get; }
        public ICommand PopulationStandardDeviationCommand { get; }
        public ICommand SampleVarianceCommand { get; }
        public ICommand PopulationVarianceCommand { get; }
        public ICommand ShiftCommand { get; }

        private void CalculatorOperation<T>(Func<T> operation, Func<T, string> resultFunc, string label)
        {
            T result = operation();
            ResultField = resultFunc(result);
            ResultLabel = label;
        }

        private void CalculatorOperation<T>(Func<T> operation, string label) =>
            CalculatorOperation(operation, r => r.ToString(), label);

        private double[] GetSampleDoubleArray()
        {
            if (IsCalculatingX)
            {
                return Sample.Select(item => item.ItemValue.Value).ToArray();
            }
            return Sample.Select(item => item.ItemValue.ValueOfY ?? 0).ToArray();
        }

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

        private void Mean()
        {
            if (Sample == null || Sample.Count == 0) return;
            CalculatorOperation(() => Statistics.Mean(GetSampleDoubleArray()),
                StringTranslationExtension.Translate("MeanLabel"));
        }

        private void Median()
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

        private void Shift(SampleMode mode)
        {
            if(IsCalculatingX)
            {
                ShiftText = _calculateY;
            }
            else
            {
                ShiftText = _calculateX;
            }
            IsCalculatingX = !IsCalculatingX;
        }

        private static void OnSampleModeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var calculator = bindable as DefaultCalculatorView;
            var value = (SampleMode) newValue;
            if(value == SampleMode.Simple && !calculator.IsCalculatingX)
            {
                calculator.Shift(SampleMode.Simple);
            }
        }
    }
}

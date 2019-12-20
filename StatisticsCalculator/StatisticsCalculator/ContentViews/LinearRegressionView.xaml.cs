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
    public partial class LinearRegressionView : BaseCalculatorView
    {
        public LinearRegressionView()
        {
            InitializeComponent();
            CalculateCommand = new Command<SampleMode>(Calculate, mode => mode == SampleMode.Pair);
            Content.BindingContext = this;
        }

        public static readonly BindableProperty SampleProperty = BindableProperty.Create(nameof(Sample),
            typeof(ICollection<SampleItemViewModel>), typeof(LinearRegressionView), null);
        public static readonly BindableProperty SampleModeProperty = BindableProperty.Create(nameof(SampleMode),
            typeof(SampleMode), typeof(LinearRegressionView), SampleMode.Simple);

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
        public ICommand CalculateCommand { get; }

        private void Calculate(SampleMode mode)
        {
            IEnumerable<KeyValuePair<double, double>> sample =
                Sample.Select(value => value.ItemValue.GetPairValue());
            Statistics.LinearRegression(sample,
                 out double correlation, out double angularCoefficient, out double linearCoefficient);
            ResultLabel = "LinearRegressionLabel".Translate();
            ResultField = $"r = {correlation.ToString("F4")}" +
                $"\ny = {angularCoefficient.ToString("F2")}x + {linearCoefficient.ToString("F2")}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StatisticsCalculator.Translation;
using StatisticsCalculator.ViewModels;
using StatisticsCalculator.ContentViews;

namespace StatisticsCalculator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticsPage : ContentPage
    {
        public StatisticsPage()
        {
            InitializeComponent();
            var context = new StatisticsViewModel();
            BindingContext = context;

            DefaultCalculatorView defaultCalculator = CreateCalculator<DefaultCalculatorView>();
            defaultCalculator.SetBinding(DefaultCalculatorView.SampleProperty, "Sample");
            defaultCalculator.SetBinding(DefaultCalculatorView.SampleModeProperty, "SampleMode");
            NormalDistributionView normalDistribution = CreateCalculator<NormalDistributionView>();
            BinomialView binomial = CreateCalculator<BinomialView>();
            PoissonView poisson = CreateCalculator<PoissonView>();
            LinearRegressionView linearRegression = CreateCalculator<LinearRegressionView>();
            linearRegression.SetBinding(LinearRegressionView.SampleProperty, "Sample");
            linearRegression.SetBinding(LinearRegressionView.SampleModeProperty, "SampleMode");
            var calculators = new List<CalculatorPickerItem>
            {
                new CalculatorPickerItem
                {
                    Label = StringTranslationExtension.Translate("BaseCalculatorLabel"),
                    Calculator = defaultCalculator
                },
                new CalculatorPickerItem
                {
                    Label = StringTranslationExtension.Translate("NormalDistributionLabel"),
                    Calculator = normalDistribution
                },
                new CalculatorPickerItem
                {
                    Label = "Binomial",
                    Calculator = binomial
                },
                new CalculatorPickerItem
                {
                    Label = "Poisson",
                    Calculator = poisson
                },
                new CalculatorPickerItem
                {
                    Label = StringTranslationExtension.Translate("LinearRegressionLabel"),
                    Calculator = linearRegression
                }
            };
            CalculatorPicker.ItemsSource = calculators;
            CalculatorPicker.SelectedIndex = 0;
        }

        private T CreateCalculator<T>() where T : BaseCalculatorView
        {
            T calculator = Activator.CreateInstance<T>();
            calculator.SetBinding(BaseCalculatorView.ResultFieldProperty, "Result");
            calculator.SetBinding(BaseCalculatorView.ResultLabelProperty, "ResultLabel");
            return calculator;
        }
    }
}

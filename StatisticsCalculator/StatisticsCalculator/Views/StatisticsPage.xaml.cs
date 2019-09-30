using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StatisticsCalculator.Translation;
using StatisticsCalculator.ViewModels;

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
            var defaultCalculator = new DefaultCalculatorView
            {
                BindingContext = new DefaultCalculatorViewModel(context)
            };
            var normalDistribution = new NormalDistributionView
            {
                BindingContext = new NormalDistributionViewModel(context)
            };
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
                }
            };
            CalculatorPicker.ItemsSource = calculators;
            CalculatorPicker.SelectedIndex = 0;
        }
    }
}

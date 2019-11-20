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
    public enum NormalDistributionMode { LessThan, Between, GreaterThan }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NormalDistributionView : BaseCalculatorView
    {
        private NormalDistributionMode _normalDistributionMode;

        public NormalDistributionView()
        {
            InitializeComponent();
            SetModeCommand = new Command<NormalDistributionMode>(SetMode);
            CalculateCommand = new Command(Calculate);
            SetModeCommand.Execute(NormalDistributionMode.LessThan);
            Content.BindingContext = this;
        }

        public bool IsBetweenValue { get; private set; }
        public ICommand SetModeCommand { get; private set; }
        public ICommand CalculateCommand { get; private set; }

        private void SetMode(NormalDistributionMode mode)
        {
            _normalDistributionMode = mode;
            switch (mode)
            {
                case NormalDistributionMode.LessThan:
                    comparerLabel.Text = "x <=";
                    break;
                case NormalDistributionMode.Between:
                    comparerLabel.Text = "<= x <=";
                    IsBetweenValue = true;
                    OnPropertyChanged(nameof(IsBetweenValue));
                    break;
                case NormalDistributionMode.GreaterThan:
                    comparerLabel.Text = "x >=";
                    break;
                default:
                    comparerLabel.Text = "";
                    break;
            }
            if (mode != NormalDistributionMode.Between)
            {
                IsBetweenValue = false;
                OnPropertyChanged(nameof(IsBetweenValue));
            }
        }

        private void Calculate()
        {
            if (double.TryParse(comparerValueEntry.Text, out double comparer)
                && double.TryParse(meanEntry.Text, out double mean)
                && double.TryParse(deviationEntry.Text, out double deviation))
            {
                double result = 0;
                switch (_normalDistributionMode)
                {
                    case NormalDistributionMode.LessThan:
                        result = Statistics.NormalDistributionDensity(comparer, deviation, mean);
                        break;
                    case NormalDistributionMode.Between:
                        if (double.TryParse(optionalComparerValueEntry.Text, out double optionalComparer)
                            && optionalComparer < comparer)
                        {
                            result = Statistics.NormalDistributionDensity(optionalComparer, comparer,
                                deviation, mean);
                        }
                        break;
                    case NormalDistributionMode.GreaterThan:
                        result = Statistics.NormalDistributionDensity(comparer, deviation, mean, true);
                        break;
                    default:
                        result = 0;
                        break;
                }
                ResultField = result.ToString("P2");
                ResultLabel = StringTranslationExtension.Translate("PercentageLabel");
            }
        }
    }
}

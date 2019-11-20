using Xamarin.Forms;

namespace StatisticsCalculator.ContentViews
{
    public abstract class BaseCalculatorView : ContentView
    {
        public static readonly BindableProperty ResultFieldProperty = BindableProperty.Create(nameof(ResultField),
            typeof(string), typeof(BaseCalculatorView), string.Empty, BindingMode.TwoWay);
        public static readonly BindableProperty ResultLabelProperty = BindableProperty.Create(nameof(ResultLabel),
            typeof(string), typeof(BaseCalculatorView), string.Empty, BindingMode.TwoWay);

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
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace StatisticsCalculator.Behaviors
{
    public class NumericEntryValidationBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty AllowNegativeNumberProperty = BindableProperty.Create(
            nameof(AllowNegativeNumber),
            typeof(bool), 
            typeof(NumericEntryValidationBehavior), 
            true);
        public static readonly BindableProperty AllowDecimalNumberProperty = BindableProperty.Create(
            nameof(AllowDecimalNumber),
            typeof(bool),
            typeof(NumericEntryValidationBehavior),
            true);

        public bool AllowNegativeNumber
        {
            get => (bool)GetValue(AllowNegativeNumberProperty);
            set => SetValue(AllowNegativeNumberProperty, value);
        }
        public bool AllowDecimalNumber
        {
            get => (bool)GetValue(AllowDecimalNumberProperty);
            set => SetValue(AllowDecimalNumberProperty, value);
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            int index;
            var entry = (sender as Entry);
            if (!AllowNegativeNumber 
                && (index = e.NewTextValue.IndexOf(CultureInfo.CurrentCulture
                .NumberFormat.NegativeSign)) != -1)
            {
                entry.Text = e.NewTextValue.Remove(index, 1);
                return;
            }
            if (!AllowDecimalNumber 
                && (index = e.NewTextValue.IndexOf(CultureInfo.CurrentCulture
                .NumberFormat.NumberDecimalSeparator)) != -1)
            {
                entry.Text = e.NewTextValue.Remove(index, 1);
                return;
            }
        }
    }
}

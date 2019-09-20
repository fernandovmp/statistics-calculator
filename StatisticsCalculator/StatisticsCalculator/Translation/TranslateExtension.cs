using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StatisticsCalculator.Translation
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public string Text { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Text == null ? null : Text.Translate();
        }
    }
}

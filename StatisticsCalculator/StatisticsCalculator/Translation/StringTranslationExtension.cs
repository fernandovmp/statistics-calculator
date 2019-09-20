using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;

namespace StatisticsCalculator.Translation
{
    public static class StringTranslationExtension
    {
        public static string Translate(this string text)
        {
            if (text == null) return null;
            Assembly assembly = typeof(StringTranslationExtension).Assembly;
            AssemblyName assemblyName = assembly.GetName();
            var resourceManager = new ResourceManager($"{assemblyName.Name}.Resx.AppResources", assembly);
            string culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            return resourceManager.GetString(text, new CultureInfo(culture));
        }
    }
}

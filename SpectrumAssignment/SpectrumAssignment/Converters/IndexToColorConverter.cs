﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace SpectrumAssignment.Converters
{
    public class IndexToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var groupIndex = (int)value;

            var allParams = ((string)parameter).Split((';'));

            return LookupColor(allParams[groupIndex]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public Color LookupColor(string key)
        {
            try
            {
                Application.Current.Resources.TryGetValue(key, out var newColor);
                return (Color)newColor;
            }
            catch
            {
                return Color.White;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpectrumAssignment.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoaderControl : StackLayout
    {
        public LoaderControl()
        {
            InitializeComponent();
        }

        #region BindableProperty
        public static readonly BindableProperty IndicatorColorProperty = BindableProperty.Create(
        propertyName: nameof(IndicatorColor),
        returnType: typeof(Color),
        declaringType: typeof(LoaderControl),
        defaultValue: (Color)Application.Current.Resources["Primary"],
        defaultBindingMode: BindingMode.OneWay);

        public Color IndicatorColor
        {
            get => (Color)GetValue(IndicatorColorProperty);
            set { SetValue(IndicatorColorProperty, value); }
        }

        public static readonly BindableProperty IndicatorTextColorProperty = BindableProperty.Create(
        propertyName: nameof(IndicatorTextColor),
        returnType: typeof(Color),
        declaringType: typeof(LoaderControl),
        defaultValue: (Color)Application.Current.Resources["Primary"],
        defaultBindingMode: BindingMode.OneWay);

        public Color IndicatorTextColor
        {
            get => (Color)GetValue(IndicatorTextColorProperty);
            set { SetValue(IndicatorTextColorProperty, value); }
        }


        public static readonly BindableProperty IndicatorTextProperty = BindableProperty.Create(
        propertyName: nameof(IndicatorText),
        returnType: typeof(string),
        declaringType: typeof(LoaderControl),
        defaultValue: "Please wait...",
        defaultBindingMode: BindingMode.OneWay);
        public string IndicatorText
        {
            get => (string)GetValue(IndicatorTextProperty);
            set { SetValue(IndicatorTextProperty, value); }
        }

        #endregion
    }
}
using SpectrumAssignment.ViewModels;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace SpectrumAssignment.Models
{
    public static class ViewModelLocator
    {
        public static readonly BindableProperty AutoWireViewModelProperty =
           BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".View", ".ViewModel");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            var viewModel = Activator.CreateInstance(viewModelType) as ApplicationBaseViewModel;
            view.BindingContext = viewModel;
        }

        public static readonly BindableProperty IsSubscribeForOnAppearingProperty =
          BindableProperty.CreateAttached("IsSubscribeForOnAppearing", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: IsSubscribeForOnAppearingPropertyChanged);


        public static bool GetIsSubscribeForOnAppearing(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.IsSubscribeForOnAppearingProperty);
        }

        public static void SetIsSubscribeForOnAppearing(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.IsSubscribeForOnAppearingProperty, value);
        }


        private static void IsSubscribeForOnAppearingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var page = bindable as Page;
            page.Appearing -= OnAppearing;
            page.Appearing += OnAppearing;
        }

        private static void OnAppearing(object sender, EventArgs e)
        {
            var viewModel = ((Page)(sender)).BindingContext as ApplicationBaseViewModel;
            viewModel.OnAppearing();
        }
    }
}

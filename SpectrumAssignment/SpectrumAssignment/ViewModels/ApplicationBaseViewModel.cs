using CommunityToolkit.Mvvm.ComponentModel;
using SpectrumAssignment.Models;
using SpectrumAssignment.Services;
using SpectrumAssignment.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpectrumAssignment.ViewModels
{
    public partial class ApplicationBaseViewModel : ExtendedBindableObject
    {
        [ObservableProperty]
        bool _isBusy;

        [ObservableProperty]
        string _title;


        [ObservableProperty]
        bool _isRefreshing;

        [ObservableProperty]
        bool _isInProgress;


        #region Services
        protected IApplicationUserService ApplicationUserService;
        #endregion

        #region Construtor
        public ApplicationBaseViewModel()
        {
            ApplicationUserService = DependencyService.Resolve<IApplicationUserService>();
        }
        #endregion

        #region Methods

        public  virtual void OnAppearing() { }
        protected  virtual void Initialize(object navigationData = null) { }

        public static async Task GoToAsync(ShellNavigationState state, object navigationData = null, bool animate = false)
        {
            await Shell.Current.GoToAsync(state, animate);
            if (Shell.Current.CurrentPage != null)
            {
                var viewModel = Shell.Current.CurrentPage.BindingContext as ApplicationBaseViewModel;
                viewModel.Initialize(navigationData);
            }
        }
        public static T TryGetValue<T>(object navigationData, string propertyName = "") where T : new()
        {
            var returnValue = new T();
            try
            {
                if (navigationData != null)
                {
                    if (string.IsNullOrWhiteSpace(propertyName))
                    {
                        returnValue = (T)navigationData;
                    }
                    else
                    {
                        returnValue = (T)navigationData.GetType().GetProperty(propertyName)?.GetValue(navigationData, null);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return returnValue;
        }

        public static string TryGetValue(object navigationData, string propertyName = "")
        {
            var returnValue = string.Empty;
            try
            {
                if (navigationData != null)
                {
                    if (string.IsNullOrWhiteSpace(propertyName))
                    {
                        returnValue = (string)navigationData;
                    }
                    else
                    {
                        returnValue = (string)navigationData.GetType().GetProperty(propertyName)?.GetValue(navigationData, null);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return returnValue;
        }

        private static void OnNavigated(object sender, EventArgs e)
        {
            var apppShellDetails = (Shell)sender;

            Shell.Current.Navigated -= OnNavigated;

        }
        #endregion
    }
}

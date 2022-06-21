using Newtonsoft.Json;
using SpectrumAssignment.Models;
using SpectrumAssignment.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SpectrumAssignment.ViewModels
{
    public partial class LoadingViewModel : BaseViewModel
    {
        public LoadingViewModel()
        {
            CheckForLoginDetails();
        }

        private async void CheckForLoginDetails()
        {
            string userDetails = await SecureStorage.GetAsync(nameof(Settings.UserDetails));
            if (!string.IsNullOrWhiteSpace(userDetails))
            {
                Settings.UserDetails = JsonConvert.DeserializeObject<UserBasicInfo>(userDetails);
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
            else
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
        }
    }
}

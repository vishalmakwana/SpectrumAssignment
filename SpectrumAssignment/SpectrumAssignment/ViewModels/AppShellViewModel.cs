using SpectrumAssignment.Models;
using SpectrumAssignment.Views;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SpectrumAssignment.ViewModels
{
    public class AppShellViewModel : ApplicationBaseViewModel
    {
        #region Commands

        private ICommand logOutCommand;

        public ICommand LogOutCommand =>
            logOutCommand ?? (logOutCommand = new Command(Logout));


        async void Logout()
        {
            SecureStorage.RemoveAll();
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        #endregion
    }
}

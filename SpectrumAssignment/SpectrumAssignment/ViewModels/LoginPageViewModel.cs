using Newtonsoft.Json;
using SpectrumAssignment.Models;
using SpectrumAssignment.Validations;
using SpectrumAssignment.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SpectrumAssignment.ViewModels
{
    public partial class LoginPageViewModel : ApplicationBaseViewModel
    {
        #region Services

        #endregion Services

        #region Properties
        private ValidatableObject<string> _userName;
        public ValidatableObject<string> UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }

        private ValidatableObject<string> _password;

        public ValidatableObject<string> Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }


        #endregion Properties

        #region Constructor

        public LoginPageViewModel()
        {
            UserName = new ValidatableObject<string>();
            Password = new ValidatableObject<string>();
            AddValidations();
        }

        #endregion Constructor

        #region Commands


        private ICommand loginCommand;

        public ICommand LoginCommand =>
            loginCommand ?? (loginCommand = new Command(ExecuteLoginCommand));



        private ICommand _validateUserNameCommand;

        public ICommand ValidateUserNameCommand =>
            _validateUserNameCommand ?? (_validateUserNameCommand = new Command(() => ExecuteValidateUserNameCommand()));

        private ICommand _validateUserPassword;

        public ICommand ValidateUserPasswordCommand =>
            _validateUserPassword ?? (_validateUserPassword = new Command(() => ExecuteValidateUserPasswordCommand()));


        #endregion Commands

        #region Methods
        private async void ExecuteLoginCommand()
        {
            ValidateFields();
            if (_userName.IsValid && _password.IsValid)
            {
                var userInfo = new UserBasicInfo
                {
                    Email = _userName.Value,
                    FullName = "Spectrum",
                };
                string userInfoJson = JsonConvert.SerializeObject(userInfo);
                await SecureStorage.SetAsync(nameof(Settings.UserDetails), userInfoJson);
                Settings.UserDetails = userInfo;
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }

        }

        public void ValidateFields()
        {
            ValidateUserPasswordCommand.Execute(null);
            ValidateUserNameCommand.Execute(null);
        }

        private bool ExecuteValidateUserNameCommand()
        {
            return _userName.Validate();
        }

        private bool ExecuteValidateUserPasswordCommand()
        {
            return _password.Validate();
        }
        private void AddValidations()
        {
            _userName.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "Login Id is required"
            });
            _userName.Validations.Add(new EmailRule<string>
            {
                ValidationMessage = "Please enter valid email address"
            });
            _password.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "Please enter password"
            });
        }

        #endregion Methods
    }
}

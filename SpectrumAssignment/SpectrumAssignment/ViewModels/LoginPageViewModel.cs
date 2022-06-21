using SpectrumAssignment.Validations;
using SpectrumAssignment.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SpectrumAssignment.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
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
            _password.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "Please enter password"
            });
        }

        #endregion Methods
    }
}

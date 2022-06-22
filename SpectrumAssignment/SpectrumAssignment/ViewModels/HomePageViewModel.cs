using MvvmHelpers;
using SpectrumAssignment.CustomControls;
using SpectrumAssignment.Models;
using SpectrumAssignment.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SpectrumAssignment.ViewModels
{
    public partial class HomePageViewModel : ApplicationBaseViewModel
    {
        public ObservableRangeCollection<UserInfo> UserInfos { get; set; } = new ObservableRangeCollection<UserInfo>();

        private string _search;
        public string Search
        {
            get => _search;
            set
            {
                SetProperty(ref _search, value);
                if (string.IsNullOrWhiteSpace(value) && UserInfos.Count != _allUsers?.Count)
                {
                    FilterUser();
                }
            }

        }

        private string _orderByDerection= "asc";
        public string OrderByDerection
        {
            get => _orderByDerection;
            set
            {
                SetProperty(ref _orderByDerection, value);
            }

        }

        private List<UserInfo> _allUsers;

        public List<UserInfo> AllUsers
        {
            get { return _allUsers; }
            set { SetProperty(ref _allUsers , value); }
        }

        private ICommand logOutCommand;

        public ICommand LogOutCommand =>
            logOutCommand ?? (logOutCommand = new Command(Logout));


       

        private UserInfo _selectedItem;

        public UserInfo SelectedItem
        {
            get { return _selectedItem; } 
            set { SetProperty(ref _selectedItem, value);   }
        }

        private ICommand _itemSelectedCommand;

        public ICommand ItemSelectedCommand =>
            _itemSelectedCommand ?? (_itemSelectedCommand = new Command<UserInfo>(async (item) => await ExecuteItemSelectedCommand()));

        private ICommand _refreshCommand;

        public ICommand RefreshCommand =>
            _refreshCommand ?? (_refreshCommand = new Command(async () => await RefreshAsync()));

        private ICommand _searchCommand;

        public ICommand SearchCommand =>
            _searchCommand ?? (_searchCommand = new Command( () =>  FilterUser()));

        private ICommand _orderByCommand;

        public ICommand OrderByCommand =>
            _orderByCommand ?? (_orderByCommand = new Command(() => OrderByUserData()));

        public HomePageViewModel()
        {
            OrderByDerection = "asc";
        }

        public async Task GetUserList()
        {
            IsBusy = true;
            AllUsers = await ApplicationUserService.GetUserInfos();
            Device.BeginInvokeOnMainThread(() =>
            {
                if (_allUsers?.Count > 0)
                {
                    UserInfos.ReplaceRange(_allUsers.OrderBy(a=>a.name));
                }
                IsBusy = false;
            });
        }

        protected  async Task RefreshAsync()
        {
            IsBusy = true;
            Search = "";
            AllUsers = await ApplicationUserService.GetUserInfos();
            Device.BeginInvokeOnMainThread(() =>
            {
                if (_allUsers?.Count > 0)
                {
                    UserInfos.ReplaceRange(_allUsers);
                }
                IsBusy = false;
            });
            IsBusy = false;
        }


        private async Task ExecuteItemSelectedCommand()
        {
            //await GoToAsync(nameof(UserDetailPage), SelectedItem);
           // await App.Current.MainPage.Navigation.PushAsync(new UserDetailPage())
        }

       
        public async void FilterUser()
        {
            if (_allUsers == null) return;

            IsBusy = true;
            await Task.Delay(100);
            if (!string.IsNullOrWhiteSpace(Search))
            {
                var filterList = _allUsers.Where(f => f.name.ToLower().Contains(Search.ToLower()) || f.email.ToLower().Contains(Search.ToLower()) || f.gender.ToLower().Contains(Search.ToLower())).ToList();
                UserInfos.ReplaceRange(filterList);
            }
            else
            {
                UserInfos.ReplaceRange(_allUsers);
            }
            IsBusy = false;
        }
        
        public async void OrderByUserData()
        {
            OrderByDerection = OrderByDerection == "asc" ? "desc" : "asc";
            IsBusy = true;
            await Task.Delay(100);
            List<UserInfo> filterList = new List<UserInfo>();
            // List<UserInfo> filterList = OrderByDerection == "asc" ? _allUsers.OrderBy(a => a.name).ToList() : _allUsers.OrderBy(a => a.name).ToList();
            if (!string.IsNullOrWhiteSpace(Search))
            {
                filterList = AllUsers.Where(f => f.name.ToLower().Contains(Search.ToLower()) || f.email.ToLower().Contains(Search.ToLower()) || f.gender.ToLower().Contains(Search.ToLower())).ToList();
            }
            else
            {
                filterList = AllUsers;
            }
          
            UserInfos.ReplaceRange(OrderByDerection == "asc" ? filterList.OrderBy(a => a.name).ToList() : filterList.OrderByDescending(a => a.name).ToList());

            IsBusy = false;
        }
        async void Logout()
        {
            SecureStorage.RemoveAll();
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}

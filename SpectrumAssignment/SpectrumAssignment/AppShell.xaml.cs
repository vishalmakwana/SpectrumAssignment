﻿using SpectrumAssignment.ViewModels;
using SpectrumAssignment.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SpectrumAssignment
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            this.BindingContext = new AppShellViewModel();
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
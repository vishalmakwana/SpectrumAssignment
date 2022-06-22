﻿using SpectrumAssignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpectrumAssignment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailPage : ContentPage
    {
       
        public UserDetailPage()
        {
            InitializeComponent();
            BindingContext = new UserDetailPageViewModel();
        }
    }
}
using SpectrumAssignment.Models;
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
    public partial class FlyoutHeaderControl : Grid
    {
        public FlyoutHeaderControl()
        {
            InitializeComponent();

            //if (Settings.UserDetails != null)
            //{
            //    userAvatar.Text = userName.Text = Settings.UserDetails.FullName;
            //    userEmail.Text = Settings.UserDetails.Email;
            //}
        }
    }
}
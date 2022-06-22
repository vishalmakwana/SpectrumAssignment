using SpectrumAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpectrumAssignment.ViewModels
{
    public partial class UserDetailPageViewModel : ApplicationBaseViewModel
    {
        public UserDetailPageViewModel()
        {

        }
        protected  override void Initialize(object navigationData = null)
        {
            base.Initialize(navigationData);
            var doctorDetails = TryGetValue<UserInfo>(navigationData);
        }

    }

    
}

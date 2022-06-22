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
        protected override void Initialize(object navigationData = null)
        {
            base.Initialize(navigationData);
            //var user = TryGetValue<UserInfo>(navigationData);
            //if (user.id > 0)
            //{
            //    //Userdetail.name = user.name;
            //    //Userdetail.email = user.email;
            //    //Userdetail.status = user.status;
            //    //Userdetail.id = user.id;
            //}
        }

    }


}

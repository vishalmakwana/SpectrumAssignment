using SpectrumAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumAssignment.Services
{
    public interface IApplicationUserService
    {
        Task<List<UserInfo>> GetUserInfos();
    }
}

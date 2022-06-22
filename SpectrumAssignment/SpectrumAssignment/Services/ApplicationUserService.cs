using SpectrumAssignment.Models;
using SpectrumAssignment.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumAssignment.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        public async Task<List<UserInfo>> GetUserInfos()
        {
            return await WebAPIRequest.ExecuteAsync<List<UserInfo>>(new RequestBody
            {
                Uri = API.GetUsers,
                ResponseType = HttpResponseType.Generic
            });
        }
    }
}

﻿using Social_network.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Repository
{
    interface UserInfoRepository
    {
        Task<UserInfoResponse> GetUserInfo();
        Task<UserInfoResponse> GetUserById(long id);
    }

}

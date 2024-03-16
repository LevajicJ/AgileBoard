﻿using AgileBoard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileBoard.Domain.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> AuthenticateUser(string email, string password);
        Task<User> GetUserByEmail(string email);
    }
}

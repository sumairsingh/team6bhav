using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News_App_Backend.Models
{
    public interface IUserRepository
    {
        User FindUserByEmail(string email);
        User Register(User user);
        User Login(string email, string password);
    }
}

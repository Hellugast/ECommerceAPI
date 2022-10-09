using ECommerceAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.Services.Authentications
{
    public interface IAuthExternal
    {
        Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifetime);
    }
}

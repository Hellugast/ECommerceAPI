using ECommerceAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.Services.Authentications
{
    public interface IAuthInternal
    {
        Task<Token> LoginAsync(string userName, string password, int accessTokenLifetime);
    }
}

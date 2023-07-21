﻿using LibraryWebApp.Domain.Entities.DataTransferObjects;
using Microsoft.AspNetCore.Identity;

namespace LibraryWebApp.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUseer(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();

    }
}

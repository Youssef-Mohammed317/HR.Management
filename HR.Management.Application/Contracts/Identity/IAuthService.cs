using HR.Management.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest authRequest);
        Task<RegistrationResponse> Register(RegistrationRequest registrationRequest);
    }
}

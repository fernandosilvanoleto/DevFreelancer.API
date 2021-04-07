using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreelancer.Core.Services
{
    public interface IAuthService
    {
        string GenereateJwtToken(string email, string role);
        string ComputeSha256Hash(string password);
    }
}

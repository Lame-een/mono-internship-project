using System;
using Lyre.Model.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Service.Common
{
    public interface IAuthenticator
    {
        Task<IUser> AuthenticateAsync(System.Net.Http.Headers.AuthenticationHeaderValue authHeader);
        Task<IUser> AuthenticateAsync(string token);
        bool Authenticate(string token, ref Guid? id);

        string CreateToken(Guid id);
    }
}

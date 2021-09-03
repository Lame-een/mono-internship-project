using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lyre.Common;
using Lyre.Model.Common;

namespace Lyre.Service.Common
{
    public interface IUserService
    {
        Task<List<IUser>> SelectUsersAsync(QueryStringManager qsManager);
        Task<IUser> SelectUserAsync(Guid guid);
        Task<IUser> SelectUserAsync(string name);

        Task<int> InsertAsync(IUser value);
        Task<int> UpdateAsync(IUser value);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(string name);

        Task<int> RegisterUserAsync(string name, string password, UserRole role = UserRole.USER);

        Task<int> ResetPasswordAsync(string name, string newPassword, UserRole role = UserRole.USER);
        Task<Guid?> LoginUserAsync(string name, string password);
    }
}

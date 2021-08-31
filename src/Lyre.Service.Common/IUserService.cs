using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lyre.Model.Common;

namespace Lyre.Service.Common
{
    public interface IUserService
    {
        //Task<List<IUser>> SelectAsync(Pager pager, Sorter sorter, SongFilter filter);
        Task<IUser> SelectUserAsync(Guid guid);
        Task<IUser> SelectUserAsync(string name);

        Task<int> InsertAsync(IUser value);
        Task<int> UpdateAsync(IUser value);
        Task<int> DeleteAsync(Guid id);

        Task<int> RegisterUserAsync(string name, string password, UserRole role = UserRole.USER);
        Task<int> LoginUserAsync(string name, string password);
    }
}

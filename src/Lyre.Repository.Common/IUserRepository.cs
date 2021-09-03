using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lyre.Model.Common;
using Lyre.Common;

namespace Lyre.Repository.Common
{
    public interface IUserRepository
    {
        Task<List<IUser>> SelectUsersAsync(QueryStringManager qsManager);
        Task<IUser> SelectUserAsync(Guid id);
        Task<IUser> SelectUserAsync(string name);
        //Task<List<IUser>> SelectAsync(Pager pager, Sorter sorter, AlbumFilter filter);
        Task<int> InsertAsync(IUser value);
        Task<int> UpdateAsync(IUser value);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(string name);
    }
}

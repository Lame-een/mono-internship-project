using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lyre.Model.Common;

namespace Lyre.Repository.Common
{
    public interface IUserRepository
    {
        Task<IUser> SelectAsync(Guid id);
        //Task<List<IUser>> SelectAsync(Pager pager, Sorter sorter, AlbumFilter filter);

        Task<int> InsertAsync(IUser value);
        Task<int> UpdateAsync(Guid id, IUser value);
        Task<int> DeleteAsync(Guid id);
    }
}

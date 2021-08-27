﻿using System;
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
        Task<IUser> SelectAsync(Guid guid);

        Task<int> InsertAsync(IUser value);
        Task<int> UpdateAsync<T>(Guid id, IUser value);

        IUser NewUser();
    }
}

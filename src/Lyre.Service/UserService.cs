using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lyre.Model.Common;
using Lyre.Service.Common;
using Lyre.Repository.Common;

namespace Lyre.Service
{
    class UserService : IUserService
    {
        protected IUserRepository Repository { get; }
        public UserService(IUserRepository repository)
        {
            Repository = repository;
        }

        public async Task<IUser> SelectAsync(Guid guid)
        {
            return await Repository.SelectAsync(guid);
        }
        public async Task<int> InsertAsync(IUser value)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync<T>(Guid id, IUser value)
        {
            throw new NotImplementedException();
        }

        public IUser NewUser()
        {
            throw new NotImplementedException();
        }
    }
}

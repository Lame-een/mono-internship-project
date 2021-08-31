using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lyre.Common;
using Lyre.Model.Common;
using Lyre.Service.Common;
using Lyre.Repository.Common;
using Lyre.Model;

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
            return await Repository.InsertAsync(value);
        }

        public async Task<int> UpdateAsync(IUser value)
        {
            return await Repository.UpdateAsync(value);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Repository.DeleteAsync(id);
        }

        //FIX salt shouldn't be generated for every user
        public IUser NewUser(string name)
        {
            return new User(name);
        }

        public IUser NewUser(Guid id, string name)
        {
            return new User(id, name);
        }
    }
}

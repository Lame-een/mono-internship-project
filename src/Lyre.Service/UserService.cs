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

        public async Task<List<IUser>> SelectUsersAsync(QueryStringManager qsManager)
        {
            return await Repository.SelectUsersAsync(qsManager);
        }

        public async Task<IUser> SelectUserAsync(Guid guid)
        {
            return await Repository.SelectUserAsync(guid);
        }
        public async Task<IUser> SelectUserAsync(string name)
        {
            return await Repository.SelectUserAsync(name);
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

        public async Task<int> DeleteAsync(string name)
        {
            return await Repository.DeleteAsync(name);
        }

        public async Task<int> ResetPasswordAsync(string name, string newPassword, UserRole role = UserRole.USER)
        {
            IUser user = await SelectUserAsync(name);
            if (user == null)
            {
                return -1;
            }

            byte[] saltBytes = null;
            user.Salt = CryptoProvider.GenerateSalt(ref saltBytes);
            user.Hash = CryptoProvider.Hash(newPassword, saltBytes);
            user.Role = role;

            return await UpdateAsync(user);
        }

        public async Task<int> RegisterUserAsync(string name, string password, UserRole role = UserRole.USER)
        {
            if((await SelectUserAsync(name)) != null)
            {
                return -2;
            }

            byte[] saltBytes = null;
            string salt = CryptoProvider.GenerateSalt(ref saltBytes);

            string hash = CryptoProvider.Hash(password, saltBytes);

            IUser user = new User(name, hash, salt, role);

            return await InsertAsync(user);
        }

        public async Task<Guid?> LoginUserAsync(string name, string password)
        {
            IUser user = await SelectUserAsync(name);

            if(user == null)
            {
                return null;
            }

            if(CryptoProvider.Verify(password, user.Salt, user.Hash)){
                return user.UserID;
            }
            else
            {
                return null;
            }
        }
    }
}

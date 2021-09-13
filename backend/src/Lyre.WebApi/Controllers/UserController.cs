using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Lyre.Service.Common;
using Lyre.Model.Common;
using Lyre.Common;
using AutoMapper;

namespace Lyre.WebApi.Controllers
{
    public class UserController : ApiController
    {
        protected IUserService Service { get; }
        protected IMapper Mapper { get; }

        protected IAuthenticator Authenticator { get; }
        public UserController(IUserService service, IMapper mapper, IAuthenticator authenticator)
        {
            Service = service;
            Mapper = mapper;
            Authenticator = authenticator;
        }

        //catch all get - used for filtering
        [HttpGet]
        public async Task<HttpResponseMessage> QueryUsersAsync()
        {
            QueryStringManager qsManager = new QueryStringManager(Request.RequestUri.ParseQueryString());

            qsManager.Filter.InitializeSql(typeof(IUser));
            qsManager.Sorter.InitializeSql(typeof(IUser));

            List<IUser> users = await Service.SelectUsersAsync(qsManager);

            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<UserREST>>(users));
        }

        [HttpGet]
        [Route("api/User/id/{id}")]
        public async Task<HttpResponseMessage> GetUserAsync(Guid id)
        {
            UserREST user = Mapper.Map<UserREST>(await Service.SelectUserAsync(id));

            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No entries found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpGet]
        [Route("api/User/name/{name}")]
        public async Task<HttpResponseMessage> GetUserAsync(string name)
        {
            UserREST user = Mapper.Map<UserREST>(await Service.SelectUserAsync(name));

            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No entries found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPost]
        [Route("api/User/register/")]
        public async Task<HttpResponseMessage> RegisterUserAsync([FromBody] UserLoginREST value)
        {
            if (value.Username.Length == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid username value.");
            }
            else if (value.Password.Length == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid password value.");
            }

            int changeCount = await Service.RegisterUserAsync(value.Username, value.Password);


            if (changeCount == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }
            else if (changeCount == -2)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Username already exists.");
            }
            return Request.CreateResponse(HttpStatusCode.Created, $"Registered user: {value.Username}");
        }

        [HttpPost]
        [Route("api/User/login/")]
        public async Task<HttpResponseMessage> UserLoginAsync([FromBody] UserLoginREST value)
        {
            if (value.Username.Length == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid username value.");
            }
            else if (value.Password.Length == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid password value.");
            }

            Guid? userID = await Service.LoginUserAsync(value.Username, value.Password);

            if (userID == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid username or password.");
            }

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "User logged in.");
            response.Headers.Add("Authorization", "Bearer " + Authenticator.CreateToken((Guid)userID));
            return response;
        }

        [HttpPost]
        [Route("api/User/reset/")]
        public async Task<HttpResponseMessage> ResetPasswordAsync([FromBody] UserLoginREST value)
        {
            if (value.Username.Length == 0 || value.Password.Length == 0 || value.NewPassword.Length == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }

            //login instead of authentication as the password needs to be checked
            Guid? userID = await Service.LoginUserAsync(value.Username, value.Password);
            if (userID == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid username or password.");
            }

            int changeCount = await Service.ResetPasswordAsync(value.Username, value.NewPassword);

            if (changeCount == -1)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Error changing password.");
            }
            
            return Request.CreateResponse(HttpStatusCode.Created, "Password changed.");
        }

        [HttpPut]
        [Route("api/User/role/")]
        public async Task<HttpResponseMessage> SetUserRoleAsync([FromBody] UserREST value)
        {
            if ((value.Username.Length == 0) || (value.Role == null))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }

            //authentication code starts here
            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes

            if ((user == null) || (user.Role != UserRole.ADMIN))    //role changes aren't allowed unless you're an admin
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }
            //end of authentication code


            IUser targetUser = await Service.SelectUserAsync(value.Username);
            if(targetUser == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }

            targetUser.Role = (UserRole)value.Role;

            int changeCount = await Service.UpdateAsync(targetUser);

            if (changeCount == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.Created, $"Updated {changeCount} row(s).");
        }

        [HttpDelete]
        [Route("api/User/id/{id}")]
        public async Task<HttpResponseMessage> DeleteUserAsync(Guid id)
        {
            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes

            if ((user == null) || (user.Role != UserRole.ADMIN))    //role changes aren't allowed unless you're an admin
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }
            int changeCount = await Service.DeleteAsync(id);

            return Request.CreateResponse(HttpStatusCode.Created, $"Deleted {changeCount} row(s).");
        }

        [HttpDelete]
        [Route("api/User/name/{name}")]
        public async Task<HttpResponseMessage> DeleteUserAsync(string name)
        {
            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes

            if ((user == null) || (user.Role != UserRole.ADMIN))    //role changes aren't allowed unless you're an admin
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }
            int changeCount = await Service.DeleteAsync(name);

            return Request.CreateResponse(HttpStatusCode.Created, $"Deleted {changeCount} row(s).");
        }

        public class UserREST
        {
            public Guid UserID { get; set; }
            public string Username { get; set; }
            public UserRole? Role { get; set; }
        }

        public class UserLoginREST
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string NewPassword { get; set; }

            //email could be added
        }
    }
}

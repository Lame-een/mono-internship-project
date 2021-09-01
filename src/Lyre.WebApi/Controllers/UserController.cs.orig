using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Lyre.Service.Common;
using Lyre.Model.Common;
using AutoMapper;

namespace Lyre.WebApi.Controllers
{
    public class UserController : ApiController
    {
        protected IUserService Service { get; }
        protected IMapper Mapper { get; }
        public UserController(IUserService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        [HttpGet]
        public Task<HttpResponseMessage> GetAllUsersAsync()
        {
            return default;
            //return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetUserAsync(Guid id)
        {
            UserREST user = Mapper.Map<UserREST>(await Service.SelectUserAsync(id));

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

            int changeCount = await Service.LoginUserAsync(value.Username, value.Password);


            if (changeCount == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid username or password.");
            }
            //auth token should be returned on successful login
            return Request.CreateResponse(HttpStatusCode.OK, $"User logged in.");
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateUserDataAsync([FromBody] UserREST value)
        {
            if (value.Username.Length == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }
            //TEMPORARY TO FIX - HERE FIX
            //nothing to implement passwords as of yet
            //updating probably shouldn't change passwords/hashes/salts
            //seperate put request for passwords???

            //IUser user = Service.FetchUser(value.Username);
            //user.Role = value.Role;
            //
            //int changeCount = await Service.UpdateAsync(user);
            //
            //if (changeCount == -1)
            //{
            //    return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            //}
            //return Request.CreateResponse(HttpStatusCode.Created, $"Updated {changeCount} row(s).");
            return Request.CreateResponse(HttpStatusCode.BadRequest, $"Update temporarily disabled.");
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteUserAsync(Guid id)
        {

            int changeCount = await Service.DeleteAsync(id);

            return Request.CreateResponse(HttpStatusCode.Created, $"Deleted {changeCount} row(s).");
        }

        public class UserREST
        {
            public Guid UserID { get; set; }
            public string Username { get; set; }
            public UserRole Role { get; set; }
        }

        public class UserLoginREST
        {
            public string Username { get; set; }
            public string Password { get; set; }

            //email could be added
        }
    }
}

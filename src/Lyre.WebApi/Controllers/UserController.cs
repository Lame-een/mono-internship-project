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
            UserREST user = Mapper.Map<UserREST>(await Service.SelectAsync(id));

            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No entries found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> RegisterUserAsync([FromBody] UserREST value)
        {
            if (value.Username.Length == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }
            //TEMPORARY TO FIX - HERE FIX
            //nothing to implement passwords as of yet
            IUser user = Service.NewUser(value.Username);
            user.Role = value.Role;

            int changeCount = await Service.InsertAsync(user);

            if (changeCount == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.Created, $"Inserted {changeCount} row(s).");
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

            IUser user = Service.NewUser(value.UserID, value.Username);
            user.Role = value.Role;

            int changeCount = await Service.UpdateAsync(user);

            if (changeCount == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.Created, $"Updated {changeCount} row(s).");
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
    }
}

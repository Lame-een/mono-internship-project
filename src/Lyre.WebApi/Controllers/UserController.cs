using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Lyre.Service.Common;
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
        public Task<HttpResponseMessage> Get()
        {
            return default;
            //return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAsync(Guid id)
        {
            UserREST user = Mapper.Map<UserREST>(await Service.SelectAsync(id));

            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No entries found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPost]
        public async void Post([FromBody] string value)
        {
        }

        [HttpPut]
        public async void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete]
        public async void Delete(int id)
        {
        }

        public class UserREST
        {

        }
    }
}

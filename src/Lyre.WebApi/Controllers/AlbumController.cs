using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Lyre.WebApi.Controllers
{
    public class AlbumController : ApiController
    {
        public class AlbumREST
        {
            //public int album_id { get; set; }

            public string name { get; set; }

            public int number_of_tracks { get; set; }

            public int year { get; set; }

            public string cover { get; set; }

            public int artist_id { get; set; }

            //public DateTime creation_time { get; set; }
        }
        // GET api/<controller>
        [HttpGet]
        [Route("api/album/{id}")]
        public async Task<HttpResponseMessage> Get(int id);

        [HttpGet]
        [Route("api/albums")]
        public async Task<HttpResponseMessage> GetAll();

        [HttpPost]
        [Route("api/album")]
        public async Task<HttpResponseMessage> Post(int id);

        [HttpPut]
        [Route("api/album")]
        public async Task<HttpResponseMessage> Put(int id);

        [HttpDelete]
        [Route("api/album/{id}")]
        public async Task<HttpResponseMessage> Delete(int id);
    }
}
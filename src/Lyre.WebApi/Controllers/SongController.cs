using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Lyre.WebApi.Controllers
{
    public class SongController : ApiController
    {
        public class SongREST
        {
            //public int song_id { get; set; }

            public string name { get; set; }

            public int album_id { get; set; }

            public int genre_id { get; set; }

            //public DateTime creation_time { get; set; }
        }

        [HttpGet]
        [Route("api/song/{id}")]
        public async Task<HttpResponseMessage> Get(int id);

        [HttpGet]
        [Route("api/songs")]
        public async Task<HttpResponseMessage> GetAll();

        [HttpPost]
        [Route("api/song")]
        public async Task<HttpResponseMessage> Post(int id);

        [HttpPut]
        [Route("api/song")]
        public async Task<HttpResponseMessage> Put(int id);

        [HttpDelete]
        [Route("api/song/{id}")]
        public async Task<HttpResponseMessage> Delete(int id);
    }
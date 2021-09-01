using AutoMapper;
using Lyre.Model;
using Lyre.Model.Common;
using Lyre.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;

namespace Lyre.WebApi.Controllers
{
    public class ArtistController: ApiController
    {
        private IArtistService Service { get; set; }
        private IMapper Mapper { get; set; }

        public ArtistController() { }
        public ArtistController(IArtistService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("api/Artist")]
        public async Task<HttpResponseMessage> GetAllArtistsAsync()
        {
            List<ArtistREST> artistList = Mapper.Map<List<ArtistREST>>(await Service.GetAllArtistsAsync());
            if (artistList.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No rows found.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, artistList);
        }

        [HttpGet]
        [Route("api/Artist/{id}")]
        public async Task<HttpResponseMessage> GetArtistByIDAsync(Guid id)
        {
            if(id == Guid.Empty)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid ID.");
            }

            ArtistREST artist = Mapper.Map<ArtistREST>(await Service.GetArtistByIDAsync(id));
            if(artist == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No rows found.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        [HttpPost]
        [Route("api/Artist")]
        public async Task<HttpResponseMessage> PostArtistAsync([FromBody] string newArtistName)
        {
            if(newArtistName.Length == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }

            int status = await Service.PostArtistAsync(newArtistName);
            if(status == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.Created, "Inserted " + status.ToString() + " row(s).");
        }

        [HttpPost]
        [Route("api/Artist/list")]
        public async Task<HttpResponseMessage> PostArtistsAsync([FromBody] List<string> newArtistNames)
        {
            if (newArtistNames.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }

            int status = 0;
            foreach (string artistName in newArtistNames)
            {
                try
                {
                    status += await Service.PostArtistAsync(artistName);
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Error occured.");
                }
            }
            if (status < 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error occured.");
            }
            return Request.CreateResponse(HttpStatusCode.Created, "Inserted " + status.ToString() + " row(s).");
        }

        [HttpPut]
        [Route("api/Artist")]
        public async Task<HttpResponseMessage> PutArtistAsync([FromBody] Artist artist)
        {
            if(artist == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }

            int status = await Service.PutArtistAsync(artist);
            if(status == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Updated " + status.ToString() + " row(s).");
        }

        [HttpDelete]
        [Route("api/Artist/{id}")]
        public async Task<HttpResponseMessage> DeleteArtistByIDAsync(Guid id)
        {
            if(id == Guid.Empty)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No entries found.");
            }

            int status = await Service.DeleteArtistByIDAsync(id);
            if(status == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No entries found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted " + status.ToString() + " row(s).");
        }

        public class ArtistREST
        {
            public Guid ID { get; set; }
            public string Name { get; set; }
            public DateTime CreationTime { get; set; }

            public ArtistREST() { }
            public ArtistREST(Guid id, string name, DateTime creationTime)
            {
                ID = id;
                Name = name;
                CreationTime = creationTime;
            }
        }
    }
}
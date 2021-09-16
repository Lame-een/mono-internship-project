using AutoMapper;
using Lyre.Model;
using Lyre.Model.Common;
using Lyre.Service;
using Lyre.Service.Common;
using Lyre.Common;
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
        private Authenticator Authenticator { get; set; }

        public ArtistController() { }
        public ArtistController(IArtistService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("api/artist")]
        public async Task<HttpResponseMessage> GetAllArtistsAsync()
        {
            QueryStringManager qsManager = new QueryStringManager(Request.RequestUri.ParseQueryString());

            qsManager.Filter.InitializeSql(typeof(IArtist));
            qsManager.Sorter.InitializeSql(typeof(IArtist));

            return Request.CreateResponse(HttpStatusCode.OK, await Service.GetAllArtistsAsync(qsManager));
        }

        [HttpGet]
        [Route("api/artist/{id}")]
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

        [HttpGet]
        [Route("api/Artist/all/{id}")]
        public async Task<HttpResponseMessage> GetSongsInAlbum(Guid id)
        {
            List<ArtistCompositeREST> compositeList = Mapper.Map<List<ArtistCompositeREST>>(await Service.GetArtistComposite(id));

            if (compositeList == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No entries found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, compositeList);
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
            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes
            if (user.Role == UserRole.USER)    //updates aren't allowed unless you're an admin or editor
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }

            if (newArtistNames.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }

            int status = 0;
            foreach (string artistName in newArtistNames)
            {
                if (artistName.Length == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
                }
                try
                {
                    status += await Service.PostArtistAsync(artistName);
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
                }
            }
            if (status < 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error occured.");
            }
            return Request.CreateResponse(HttpStatusCode.Created, "Inserted " + status.ToString() + " row(s).");
        }

        [HttpPut]
        [Route("api/Artist")]
        public async Task<HttpResponseMessage> PutArtistAsync([FromBody] Artist artist)
        {
            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes
            if (user.Role == UserRole.USER)    //updates aren't allowed unless you're an admin or editor
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }

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
            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes
            if (user.Role == UserRole.USER)    //updates aren't allowed unless you're an admin or editor
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }

            if (id == Guid.Empty)
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
            public Guid ArtistID { get; set; }
            public string Name { get; set; }
            public DateTime CreationTime { get; set; }

            public ArtistREST() { }
            public ArtistREST(Guid id, string name, DateTime creationTime)
            {
                ArtistID = id;
                Name = name;
                CreationTime = creationTime;
            }
        }

        public class ArtistCompositeREST
        {
            public string ArtistName { get; set; }
            public string SongName { get; set; }
            public Guid SongID { get; set; }
            public string AlbumName { get; set; }
            public Guid AlbumID { get; set; }

            public ArtistCompositeREST() { }

            public ArtistCompositeREST(string artistName, string songName, Guid songID, string albumName, Guid albumID)
            {
                ArtistName = artistName;
                SongName = songName;
                SongID = songID;
                AlbumName = albumName;
                AlbumID = albumID;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Lyre.Service.Common;
using AutoMapper;
using Lyre.Common;
using Lyre.Model.Common;

namespace Lyre.WebApi.Controllers
{
    public class SongController : ApiController
    {
        [HttpGet]
        [Route("api/song/id/{id}")]
        public async Task<HttpResponseMessage> GetSongAsync(Guid id)
        {
            SongREST Song = Mapper.Map<SongREST>(await Service.GetSong(id));

            if (Song == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No entries found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, Song);
        }

        [HttpGet]
        [Route("api/song/all/{id}")]
        public async Task<HttpResponseMessage> GetSongCompositeAsync(Guid id)
        {
            ISongComposite Song = await Service.GetSongComposite(id);

            if (Song == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No entries found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, Song);
        }

        [HttpGet]
        [Route("api/song/all")]
        public async Task<HttpResponseMessage> GetSongCompositeAsync()
        {
            QueryStringManager qsManager = new QueryStringManager(Request.RequestUri.ParseQueryString());

            qsManager.Filter.InitializeSql(new Type[] { typeof(ISong), typeof(IAlbum), typeof(IArtist), typeof(IGenre) });
            qsManager.Sorter.InitializeSql(new Type[] { typeof(ISong), typeof(IAlbum), typeof(IArtist), typeof(IGenre) });

            return Request.CreateResponse(HttpStatusCode.OK, await Service.GetAllCompositeSongs(qsManager));
        }

        [HttpGet]
        [Route("api/song")]
        public async Task<HttpResponseMessage> QuerySongsAsync()
        {
            QueryStringManager qsManager = new QueryStringManager(Request.RequestUri.ParseQueryString());

            qsManager.Filter.InitializeSql(typeof(ISong));
            qsManager.Sorter.InitializeSql(typeof(ISong));

            return Request.CreateResponse(HttpStatusCode.OK, await Service.GetAllSongs(qsManager));
        }


        [HttpPost]
        [Route("api/song")]
        public async Task<HttpResponseMessage> PostSongAsync([FromBody] SongREST fromBody)
        {
            SongREST song;

            song = fromBody;

            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes

            if (user == null || user.Role == UserRole.USER)     //updates aren't allowed unless you're the user being changed or you're an admin
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }

            if (song.name.Length == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }

            int changeCount;
            if (song.songID != null)
            {
                changeCount = await Service.PostSong
                                    (Service.NewSong((Guid)song.songID, song.name, song.albumID, song.genreID));
            }
            else
            {

                changeCount = await Service.PostSong
                                     (Service.NewSong(Guid.NewGuid(), song.name, song.albumID, song.genreID));
            }

            if (changeCount == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.Created, $"Inserted {changeCount} row(s).");
        }


        [HttpPut]
        [Route("api/song")]
        public async Task<HttpResponseMessage> PutSongAsync([FromBody] SongREST song)
        {

            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes

            if (user == null || user.Role == UserRole.USER)    //updates aren't allowed unless you're the user being changed or you're an admin
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }

            if (song.name == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }

            string action;
            int changeCount;
            if (song.songID != null)
            {
                ISong temp = Service.NewSong((Guid)song.songID, song.name, song.albumID, song.genreID);

                action = "Updated";
                changeCount = await Service.PutSong(temp.SongID, temp);
            }
            else
            {
                action = "Inserted";
                changeCount = await Service.PostSong
                                    (Service.NewSong(Guid.NewGuid(), song.name, song.albumID, song.genreID));
            }

            if (changeCount == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"{action} {changeCount} row(s).");

        }

        [HttpDelete]
        [Route("api/song/id/{id}")]
        public async Task<HttpResponseMessage> DeleteSongAsync([FromUri] Guid id)
        {

            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes

            if (user == null || user.Role == UserRole.USER)    //updates aren't allowed unless you're the user being changed or you're an admin
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }

            int changeCount = await Service.DeleteSongByID(id);
            if (changeCount == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, $"Deleted {changeCount} row(s).");
        }

        public SongController(ISongService service, IMapper mapper, IAuthenticator authenticator)
        {
            Service = service;
            Mapper = mapper;
            Authenticator = authenticator;
        }

        public class SongREST
        {
            public Guid? songID { get; set; }

            public string name { get; set; }

            public Guid albumID { get; set; }

            public Guid? genreID { get; set; }

            //public DateTime creation_time { get; set; }


            public SongREST() { }
            public SongREST(string Name, Guid AlbumGUID, Guid? SongGUID, Guid? GenreGUID = null)
            {
                songID = SongGUID;
                name = Name;
                albumID = AlbumGUID;
                genreID = GenreGUID;
            }
        }

        private ISongService Service { get; }
        private IMapper Mapper { get; }
        private IAuthenticator Authenticator { get; }
    }
}
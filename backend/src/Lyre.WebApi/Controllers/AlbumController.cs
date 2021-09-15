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
using Lyre.Service;

namespace Lyre.WebApi.Controllers
{
    public class AlbumController : ApiController
    {
        [HttpGet]
        [Route("api/album/id/{id}")]
        public async Task<HttpResponseMessage> GetAlbumAsync(Guid id)
        {
            AlbumREST album = Mapper.Map<AlbumREST>(await Service.GetAlbum(id));

            if (album == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No entries found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, album);
        }

        [HttpGet]
        [Route("api/album")]
        public async Task<HttpResponseMessage> QueryAlbumsAsync()
        {
            QueryStringManager qsManager = new QueryStringManager(Request.RequestUri.ParseQueryString());

            qsManager.Filter.InitializeSql(typeof(IAlbum));
            qsManager.Sorter.InitializeSql(typeof(IAlbum));

            return Request.CreateResponse(HttpStatusCode.OK, await Service.GetAllAlbums(qsManager));
        }

        [HttpGet]
        [Route("api/album/all")]
        public async Task<HttpResponseMessage> GetSongsInAlbum()
        {
            QueryStringManager qsManager = new QueryStringManager(Request.RequestUri.ParseQueryString());

            qsManager.Filter.InitializeSql(new Type[] { typeof(ISong), typeof(IAlbum), typeof(IArtist) });
            qsManager.Sorter.InitializeSql(new Type[] { typeof(ISong), typeof(IAlbum), typeof(IArtist) });

            return Request.CreateResponse(HttpStatusCode.OK, await Service.GetSongsInAlbum(qsManager));
        }

        [HttpGet]
        [Route("api/album/artist/all")]
        public async Task<HttpResponseMessage> GetAlbumArtistComposite()
        {

            QueryStringManager qsManager = new QueryStringManager(Request.RequestUri.ParseQueryString());

            qsManager.Filter.InitializeSql(new Type[] { typeof(IAlbum), typeof(IArtist) });
            qsManager.Sorter.InitializeSql(new Type[] { typeof(IAlbum), typeof(IArtist) });

            return Request.CreateResponse(HttpStatusCode.OK, await Service.GetAlbumArtistComposite(qsManager));
        }


        [HttpPost]
        [Route("api/album")]
        public async Task<HttpResponseMessage> PostAlbumsAsync([FromBody] AlbumREST fromBody)
        {
            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes

            if (user == null || user.Role == UserRole.USER)    //updates aren't allowed unless you're the user being changed or you're an admin
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }

            AlbumREST album;

            album = fromBody;

            if (album.name.Length == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }

            int changeCount;
            if (album.albumID != null)
            {
                changeCount = await Service.PostAlbum
                    (Service.NewAlbum((Guid)album.albumID, album.name, album.number_of_tracks, album.year, album.cover, album.artistID));
            }
            else
            {
                
                changeCount = await Service.PostAlbum
                    (Service.NewAlbum(Guid.NewGuid(), album.name, album.number_of_tracks, album.year, album.cover, album.artistID));
            }

            if (changeCount == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.Created, $"Inserted {changeCount} row(s).");
        }


        [HttpPut]
        [Route("api/album")]
        public async Task<HttpResponseMessage> PutAlbumAsync([FromBody] AlbumREST album)
        {

            if (album.name == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }

            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes

            if (user == null || user.Role == UserRole.USER)    //updates aren't allowed unless you're the user being changed or you're an admin
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }

            string action;
            int changeCount;
            if (album.albumID != null)
            {
                IAlbum temp = Service.NewAlbum((Guid)album.albumID, album.name, album.number_of_tracks, album.year, album.cover, album.artistID);

                action = "Updated";
                changeCount = await Service.PutAlbum(temp.AlbumID, temp);
            }
            else
            {
                action = "Inserted";
                changeCount = await Service.PostAlbum
                                    (Service.NewAlbum(Guid.NewGuid(), album.name, album.number_of_tracks, album.year, album.cover, album.artistID));
            }

            if (changeCount == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"{action} {changeCount} row(s).");

        }

        [HttpDelete]
        [Route("api/album/id/{id}")]
        public async Task<HttpResponseMessage> DeleteAlbumAsync([FromUri] Guid id)
        {
            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes

            if (user == null || user.Role == UserRole.USER)     //updates aren't allowed unless you're the user being changed or you're an admin
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }

            int changeCount = await Service.DeleteAlbumByID(id);
            if (changeCount == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, $"Deleted {changeCount} row(s).");
        }

        public class AlbumREST
        {
            public Guid? albumID { get; set; }

            public string name { get; set; }

            public int? number_of_tracks { get; set; }

            public int? year { get; set; }

            public string cover { get; set; }

            public Guid artistID { get; set; }

            //public DateTime creation_time { get; set; }


            public AlbumREST() { }
            public AlbumREST(string Name, string Cover, Guid ArtistID, Guid? albumGUID, int? trackNum = null, int? Year = null)
            {
                albumID = albumGUID;
                name = Name;
                number_of_tracks = trackNum;
                cover = Cover;
                year = Year;
                artistID = ArtistID;
            }
        }

        public class AlbumCompositeREST
        {
            public string AlbumName { get; set; }
            public Guid SongID { get; set; }
            public string SongName { get; set; }

            public AlbumCompositeREST() { }

            public AlbumCompositeREST(string albumName, Guid songID, string songName)
            {
                AlbumName = albumName;
                SongID = songID;
                SongName = songName;
            }
        }

        public class AlbumArtistCompositeREST
        {
            public Guid AlbumID { get; set; }
            public string AlbumName { get; set; }
            public Guid ArtistID { get; set; }
            public string ArtistName { get; set; }

            public AlbumArtistCompositeREST() { }

            public AlbumArtistCompositeREST(Guid albumID, string albumName, Guid artistID, string artistName)
            {
                AlbumID = albumID;
                AlbumName = albumName;
                ArtistID = artistID;
                ArtistName = artistName;
            }
        }

        public AlbumController(IAlbumService service, IMapper mapper, IAuthenticator authenticator)
        {
            Authenticator = authenticator;
            Service = service;
            Mapper = mapper;
        }

        private IAlbumService Service { get; }
        private IMapper Mapper { get; }
        private IAuthenticator Authenticator { get; }
    }
}
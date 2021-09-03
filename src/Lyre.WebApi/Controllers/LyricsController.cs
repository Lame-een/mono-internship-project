using AutoMapper;
using Lyre.Model;
using Lyre.Model.Common;
using Lyre.Service;
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
    public class LyricsController : ApiController
    {
        private ILyricsService Service { get; set; }
        private IMapper Mapper { get; set; }
        private Authenticator Authenticator { get; set; }

        public LyricsController() { }
        public LyricsController(ILyricsService service, IMapper mapper) 
        {
            Service = service;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("api/Lyrics/{id}")]
        public async Task<HttpResponseMessage> GetLyricsByIDAsync(Guid id)
        {
            if(id == Guid.Empty)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No entries found.");
            }

            LyricsREST lyrics = Mapper.Map<LyricsREST>(await Service.GetLyricsByIDAsync(id));
            if(lyrics == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No rows found.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, lyrics);
        }

        [HttpPost]
        [Route("api/Lyrics")]
        public async Task<HttpResponseMessage> PostLyricsAsync([FromBody] LyricsREST newLyrics)
        {
            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes
            if (user.Role == UserRole.USER)    //post isn't allowed unless you're an admin or editor
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }

            if (newLyrics == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }

            int status = await Service.PostLyricsAsync(new Lyrics(newLyrics.Text, newLyrics.UserID, newLyrics.SongID));
            if(status == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.Created, "Inserted " + status.ToString() + " row(s).");
        }

        [HttpPut]
        [Route("api/Lyrics")]
        public async Task<HttpResponseMessage> PutLyricsAsync([FromBody] LyricsREST lyrics)
        {
            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes
            if (user.Role == UserRole.USER)    //updates aren't allowed unless you're an admin or editor
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }

            if (lyrics == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }

            int status = await Service.PutLyricsAsync(new Lyrics(lyrics.ID, lyrics.Text, lyrics.UserID,
                                                        lyrics.SongID, lyrics.CreationTime, lyrics.Verified));
            if (status == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Updated " + status.ToString() + " row(s).");
        }

        [HttpDelete]
        [Route("api/Lyrics/{id}")]
        public async Task<HttpResponseMessage> DeleteLyricsByIDAsync(Guid id)
        {
            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes
            if (user.Role == UserRole.USER)    //delete isn't allowed unless you're an admin or editor
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }

            if (id == Guid.Empty)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No entries found.");
            }

            int status = await Service.DeleteLyricsByIDAsync(id);
            if (status == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted " + status.ToString() + " row(s).");
        }

        public class LyricsREST
        {
            public Guid ID { get; set; }
            public string Text { get; set; }
            public Guid UserID { get; set; }
            public Guid SongID { get; set; }
            public DateTime CreationTime { get; set; }
            public char Verified { get; set; }

            public LyricsREST() { }
            public LyricsREST(string text, Guid userID, Guid songID, char verified = 'n')
            {
                Text = text;
                UserID = userID;
                SongID = songID;
                Verified = verified;
            }
            public LyricsREST(Guid id, string text, Guid userID, Guid songID, DateTime creationTime, char verified = 'n')
            {
                ID = id;
                Text = text;
                UserID = userID;
                SongID = songID;
                CreationTime = creationTime;
                Verified = verified;
            }
        }
    }
}

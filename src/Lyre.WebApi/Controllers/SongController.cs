﻿using System;
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
        [Route("api/song")]
        public async Task<HttpResponseMessage> QuerySongsAsync()
        {
            QueryStringManager qsManager = new QueryStringManager(Request.RequestUri.ParseQueryString());

            qsManager.Filter.InitializeSql(typeof(SongREST));

            return Request.CreateResponse(HttpStatusCode.OK, await Service.GetAllSongs(qsManager));
        }


        [HttpPost]
        [Route("api/song")]
        public async Task<HttpResponseMessage> PostSongAsync([FromBody] SongREST fromBody)
        {
            SongREST song;

            song = fromBody;

            if (song.name.Length == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }

            int changeCount;
            if (song.song_id != null)
            {
                changeCount = await Service.PostSong
                                    (Service.NewSong((Guid)song.song_id, song.name, song.album_id, song.genre_id));
            }
            else
            {

                changeCount = await Service.PostSong
                                     (Service.NewSong(Guid.NewGuid(), song.name, song.album_id, song.genre_id));
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
            if (song.name == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }

            string action;
            int changeCount;
            if (song.song_id != null)
            {
                ISong temp = Service.NewSong((Guid)song.song_id, song.name, song.album_id, song.genre_id);

                action = "Updated";
                changeCount = await Service.PutSong(temp.song_id, temp);
            }
            else
            {
                action = "Inserted";
                changeCount = await Service.PostSong
                                    (Service.NewSong(Guid.NewGuid(), song.name, song.album_id, song.genre_id));
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
            int changeCount = await Service.DeleteSongByID(id);
            if (changeCount == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, $"Deleted {changeCount} row(s).");
        }

        public class SongREST
        {
            public Guid? song_id { get; set; }

            public string name { get; set; }

            public Guid album_id { get; set; }

            public Guid? genre_id { get; set; }

            //public DateTime creation_time { get; set; }


            public SongREST() { }
            public SongREST(string Name, Guid AlbumGUID, Guid? SongGUID, Guid? GenreGUID = null)
            {
                song_id = SongGUID;
                name = Name;
                album_id = AlbumGUID;
                genre_id = GenreGUID;
            }
        }

        public SongController(ISongService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        private ISongService Service { get; }
        private IMapper Mapper { get; }
    }
}
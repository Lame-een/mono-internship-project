﻿using AutoMapper;
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
    public class GenreController : ApiController
    {
        private IGenreService Service { get; set; }
        private IMapper Mapper { get; set; }
        private Authenticator Authenticator { get; set; }

        public GenreController() { }
        public GenreController(IGenreService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("api/Genre")]
        public async Task<HttpResponseMessage> GetAllGenresAsync()
        {
            List<GenreREST> genreList = Mapper.Map<List<GenreREST>>(await Service.GetAllGenresAsync());
            if (genreList.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No rows found.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, genreList);
        }

        [HttpGet]
        [Route("api/Genre")]
        public async Task<HttpResponseMessage> GetGenreByIDAsync(Guid id)
        {
            GenreREST genre = Mapper.Map<GenreREST>(await Service.GetGenreByIDAsync(id));
            if (genre == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No rows found.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, genre);
        }

        [HttpGet]
        [Route("api/Genre/{id}")]
        public async Task<HttpResponseMessage> GetGenreByNameAsync([FromBody] string genreName)
        {
            GenreREST genre = Mapper.Map<GenreREST>(await Service.GetGenreByNameAsync(genreName));
            if (genre == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No rows found.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, genre);
        }

        [HttpPost]
        [Route("api/Genre")]
        public async Task<HttpResponseMessage> PostGenresAsync([FromBody] string newGenreName)
        {
            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes
            if (user.Role == UserRole.USER)    //post isn't allowed unless you're an admin or editor
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }

            if (newGenreName.Length == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }

            int status = await Service.PostGenreAsync(newGenreName);
            if (status == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.Created, "Inserted " + status.ToString() + " row(s).");
        }

        [HttpPost]
        [Route("api/Genre/list")]
        public async Task<HttpResponseMessage> PostGenreAsync([FromBody] List<string> newGenreNames)
        {
            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes
            if (user.Role == UserRole.USER)    //post isn't allowed unless you're an admin or editor
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }

            if (newGenreNames.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }

            int status = 0;
            foreach (string genreName in newGenreNames)
            {
                if (genreName.Length == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
                }
                try
                {
                    status += await Service.PostGenreAsync(genreName);
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
                }
            }
            if (status == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.Created, "Inserted " + status.ToString() + " row(s).");
        }

        [HttpPut]
        [Route("api/Genre")]
        public async Task<HttpResponseMessage> PutGenreAsync([FromBody] GenreREST genre)
        {
            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes
            if (user.Role == UserRole.USER)    //delete isn't allowed unless you're an admin or editor
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }

            if (genre == null || genre.Name.Length == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }

            int status;

            IGenre selectedGenre = null;
            if (genre.GenreID != Guid.Empty)
            {
                selectedGenre = await Service.GetGenreByIDAsync(genre.GenreID);
                selectedGenre.Name = genre.Name;
            }
            else
            {
                selectedGenre = new Genre() { Name = genre.Name };
            }

            status = await Service.PutGenreAsync(selectedGenre);
            if (status == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Updated " + status + " row(s).");
        }

        [HttpDelete]
        [Route("api/Genre/{id}")]
        public async Task<HttpResponseMessage> DeleteGenreByIDAsync(Guid id)
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

            int status = await Service.DeleteGenreByIDAsync(id);
            if (status == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted " + status.ToString() + " row(s).");
        }

        [HttpDelete]
        [Route("api/Genre")]
        public async Task<HttpResponseMessage> DeleteGenreByNameAsync([FromBody] string genreName)
        {
            IUser user = await Authenticator.AuthenticateAsync(Request.Headers.Authorization);  //get the current user making changes
            if (user.Role == UserRole.USER)    //updates aren't allowed unless you're an admin or editor
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized for this action.");
            }

            if (genreName.Length == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }

            int status = await Service.DeleteGenreByNameAsync(genreName);
            if (status == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error occured.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted " + status.ToString() + " row(s).");
        }

        public class GenreREST
        {
            public Guid GenreID { get; set; }
            public string Name { get; set; }

            public GenreREST() { }
            public GenreREST(Guid id, string name)
            {
                GenreID = id;
                Name = name;
            }
        }
    }
}

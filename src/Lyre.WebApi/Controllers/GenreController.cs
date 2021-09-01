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
            if (newGenreName.Length == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }

            int status = await Service.PostGenreAsync(newGenreName);
            if (status == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error occured.");
            }
            return Request.CreateResponse(HttpStatusCode.Created, "Inserted " + status.ToString() + " row(s).");
        }

        [HttpPost]
        [Route("api/Genre/list")]
        public async Task<HttpResponseMessage> PostGenreAsync([FromBody] List<string> newGenreNames)
        {
            if (newGenreNames.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }

            int status = 0;
            foreach(string genreName in newGenreNames)
            {
                try
                {
                    status += await Service.PostGenreAsync(genreName);
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Error occured.");
                }
            }
            if (status == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error occured.");
            }
            return Request.CreateResponse(HttpStatusCode.Created, "Inserted " + status.ToString() + " row(s).");
        }

        [HttpPut]
        [Route("api/Genre")]
        public async Task<HttpResponseMessage> PutGenreAsync([FromBody] Genre genre)
        {
            if (genre == null || genre.ID == Guid.Empty || genre.Name.Length == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body has invalid data.");
            }

            int status = await Service.PutGenreAsync(genre);
            if (status == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error occured.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Updated " + status + " row(s).");
        }

        [HttpDelete]
        [Route("api/Genre/{id}")]
        public async Task<HttpResponseMessage> DeleteGenreByIDAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No entries found.");
            }

            int status = await Service.DeleteGenreByIDAsync(id);
            if (status == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error occured.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted " + status.ToString() + " row(s).");
        }

        [HttpDelete]
        [Route("api/Genre")]
        public async Task<HttpResponseMessage> DeleteGenreByNameAsync([FromBody] string genreName)
        {
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
            public Guid ID { get; set; }
            public string Name { get; set; }

            public GenreREST() { }
            public GenreREST(Guid id, string name)
            {
                ID = id;
                Name = name;
            }
        }
    }
}

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
    public class AlbumController : ApiController
    {
        [HttpGet]
        [Route("api/album/id/{id}")]
        public async Task<HttpResponseMessage> GetAsync(Guid id)
        {
            AlbumREST album = Mapper.Map<AlbumREST>(await Service.GetAlbum(id));

            if (album == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No entries found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, album);
        }

        [HttpGet]
        [Route("api/Album/{pageNum?}")]
        public async Task<HttpResponseMessage> GetAsync([FromUri] FilterCompositeREST metaArg, int pageNum = 1)
        {
            Pager pager;
            Sorter sorter;
            AlbumFilter filter;

            if (metaArg == null)
            {
                pager = new Pager(pageNum);
                sorter = new Sorter();
                filter = new AlbumFilter();
            }
            else
            {
                pager = metaArg.GetPager(pageNum);
                sorter = metaArg.GetSorter();
                filter = metaArg.GetFilter();
            }



            List<AlbumREST> albumList = Mapper.Map<List<AlbumREST>>(await Service.GetAllAlbums(pager, sorter, filter));

            if (albumList.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No entries found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, albumList);
        }


        [HttpPost]
        [Route("api/Album")]
        public async Task<HttpResponseMessage> PostAsync([FromUri] AlbumREST fromUri, [FromBody] AlbumREST fromBody)
        {
            AlbumREST album;
            if (fromBody != null)
            {
                album = fromBody;
            }
            else if (fromUri.name != null)
            {
                album = fromUri;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }

            if (album.name.Length == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }

            int changeCount;
            if (album.album_id != null)
            {
                changeCount = await Service.PostAlbum
                    (Service.NewAlbum((Guid)album.album_id, album.name, album.number_of_tracks, album.year, album.cover, album.artist_id));
            }
            else
            {
                
                changeCount = await Service.PostAlbum
                    (Service.NewAlbum(Guid.NewGuid(), album.name, album.number_of_tracks, album.year, album.cover, album.artist_id));
            }

            if (changeCount == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.Created, $"Inserted {changeCount} row(s).");
        }


        [HttpPut]
        [Route("api/album")]
        public async Task<HttpResponseMessage> PutAsync([FromBody] AlbumREST album)
        {
            if (album.name == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Body is empty or has invalid data.");
            }

            string action;
            int changeCount;
            if (album.album_id != null)
            {
                IAlbum temp = Service.NewAlbum((Guid)album.album_id, album.name, album.number_of_tracks, album.year, album.cover, album.artist_id);

                action = "Updated";
                changeCount = await Service.PutAlbum(temp.album_id, temp);
            }
            else
            {
                action = "Inserted";
                changeCount = await Service.PostAlbum
                                    (Service.NewAlbum(Guid.NewGuid(), album.name, album.number_of_tracks, album.year, album.cover, album.artist_id));
            }

            if (changeCount == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, $"{action} {changeCount} row(s).");

        }

        [HttpDelete]
        [Route("api/album/id/{id}")]
        public async Task<HttpResponseMessage> DeleteByIDAsync([FromUri] Guid id)
        {
            int changeCount = await Service.DeleteAlbumByID(id);
            if (changeCount == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, $"Deleted {changeCount} row(s).");
        }

        [HttpDelete]
        [Route("api/album/name/{name}")]
        public async Task<HttpResponseMessage> DeleteByIDAsync([FromUri] string name)
        {
            int changeCount = await Service.DeleteAlbumByName(name);
            if (changeCount == -1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, $"Deleted {changeCount} row(s).");
        }

        public class AlbumREST
        {
            public Guid? album_id { get; set; }

            public string name { get; set; }

            public int? number_of_tracks { get; set; }

            public int? year { get; set; }

            public string cover { get; set; }

            public Guid artist_id { get; set; }

            //public DateTime creation_time { get; set; }


            public AlbumREST() { }
            public AlbumREST(string Name, string Cover, Guid Artist_id, Guid? albumGUID, int? trackNum = null, int? Year = null)
            {
                album_id = albumGUID;
                name = Name;
                number_of_tracks = trackNum;
                cover = Cover;
                year = Year;
                artist_id = Artist_id;
            }
        }

        public class FilterCompositeREST
        {
            public string Filter { get; set; }

            public string Sort { get; set; }
            public Sorter.OrderType Order { get; set; }

            public int Page { get; set; }
            public int PageSize { get; set; }

            public Pager GetPager(int pageNum = 0)
            {
                if (Page != 0)
                    return new Pager(Page, PageSize);
                else
                    return new Pager(pageNum, PageSize);
            }

            public Sorter GetSorter()
            {
                return new Sorter(Sort, Order);
            }

            public AlbumFilter GetFilter()
            {
                return new AlbumFilter(Filter);
            }

        }

        public AlbumController(IAlbumService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        private IAlbumService Service { get; }
        private IMapper Mapper { get; }
    }
}
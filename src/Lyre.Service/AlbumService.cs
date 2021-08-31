using Lyre.Common;
using Lyre.Model;
using Lyre.Model.Common;
using Lyre.Repository.Common;
using Lyre.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Service
{
    public class AlbumService : IAlbumService
    {
        public AlbumService(IAlbumRepository repository)
        {
            Repository = repository;
        }
        protected IAlbumRepository Repository { get; private set; }

        public async Task<IAlbum> GetAlbum(Guid albumGuid)
        {
            return await Repository.GetAlbum(albumGuid);
        }

        public async Task<List<IAlbum>> GetAllAlbums(Pager pager, Sorter sorter, AlbumFilter filter)
        {
            return await Repository.GetAllAlbums(pager, sorter, filter);
        }

        public async Task<int> PostAlbum(IAlbum album)
        {
            return await Repository.PostAlbum(album);
        }
        public async Task<int> PutAlbum(Guid albumGuid, IAlbum value)
        {
            return await Repository.PutAlbum(albumGuid, value);
        }
        public async Task<int> DeleteAlbumByID(Guid albumGuid)
        {
            return await Repository.DeleteAlbumByID(albumGuid);
        }

        public async Task<int> DeleteAlbumByName(string name)
        {
            return await Repository.DeleteAlbumByName(name);
        }



        public IAlbum NewAlbum()
        {
            return new Album();
        }

        public IAlbum NewAlbum(Guid album_id, string name, int? number_of_tracks, int? year, string cover, Guid artist_id)
        {
            return new Album(album_id, name, number_of_tracks, year, cover, artist_id);
        }
    }
}

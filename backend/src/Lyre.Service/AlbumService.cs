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

        public async Task<List<IAlbumComposite>> GetSongsInAlbum(QueryStringManager qsManager)
        {
            return await Repository.GetSongsInAlbum(qsManager);
        }

        public async Task<List<IAlbumComposite>> GetSongsInAlbumByID(Guid albumGuid)
        {
            return await Repository.GetSongsInAlbumByID(albumGuid);
        }

        public async Task<List<IAlbumArtistComposite>> GetAlbumArtistComposite(QueryStringManager qsManager)
        {
            return await Repository.GetAlbumArtistComposite(qsManager);
        }

        public async Task<List<IAlbum>> GetAllAlbums(QueryStringManager qsManager)
        {
            return await Repository.GetAllAlbums(qsManager);
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

        public IAlbum NewAlbum()
        {
            return new Album();
        }

        public IAlbum NewAlbum(Guid albumID, string name, int? number_of_tracks, int? year, string cover, Guid artistID)
        {
            return new Album(albumID, name, cover, artistID, number_of_tracks, year);
        }
    }
}

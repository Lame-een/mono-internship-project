using Lyre.Common;
using Lyre.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Service.Common
{
    public interface IAlbumService
    {
        Task<IAlbum> GetAlbum(Guid albumGuid);

        Task<List<IAlbum>> GetAllAlbums(Pager pager, Sorter sorter, AlbumFilter filter);

        Task<int> PostAlbum(IAlbum song);

        Task<int> PutAlbum(Guid albumGuid, IAlbum value);

        Task<int> DeleteAlbumByID(Guid albumGuid);

        Task<int> DeleteAlbumByName(string name);

        IAlbum NewAlbum();

        IAlbum NewAlbum(Guid album_id, string name, int? number_of_tracks, int? year, string cover, Guid artist_id);
    }
}

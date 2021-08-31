using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lyre.Model.Common;
using Lyre.Common;

namespace Lyre.Repository.Common
{
    public interface IAlbumRepository
    {
        Task<IAlbum> GetAlbum(Guid albumGuid);

        Task<List<IAlbum>> GetAllAlbums(Pager pager, Sorter sorter, AlbumFilter filter);

        Task<int> PostAlbum(IAlbum A);

        Task<int> PutAlbum(Guid albumGuid, IAlbum album);

        Task<int> DeleteAlbumByID(Guid albumGuid);

        Task<int> DeleteAlbumByName(string name);
    }
}

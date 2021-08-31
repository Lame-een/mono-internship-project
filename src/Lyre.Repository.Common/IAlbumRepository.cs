using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lyre.Model.Common;

namespace Lyre.Repository.Common
{
    public interface IAlbumRepository
    {
        Task<IAlbum> GetAlbum(Guid albumGuid);

        Task<List<IAlbum>> GetAllAlbums();

        Task<int> PostAlbum(IAlbum A);

        Task<int> PutAlbum(Guid albumGuid, IAlbum album);

        Task<int> DeleteAlbum(Guid albumGuid);
    }
}

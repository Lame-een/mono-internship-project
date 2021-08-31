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

        Task<List<IAlbum>> GetAllAlbums();

        Task<int> PostAlbum(IAlbum song);

        Task<int> PutAlbum(Guid albumGuid, IAlbum value);

        Task<int> DeleteAlbum(Guid albumGuid);
    }
}

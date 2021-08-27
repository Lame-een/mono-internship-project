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
        Task<IAlbum> GetAlbum(int id);

        Task<List<IAlbum>> GetAllAlbums();

        Task<int> PostAlbum(IAlbum A);

        Task<int> PutAlbum(int id, string name);

        Task<int> DeleteAlbum(IAlbum A);
    }
}

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

        Task<List<IAlbum>> GetAllAlbums(QueryStringManager qsManager);

        Task<List<IAlbumComposite>> GetSongsInAlbum(QueryStringManager qsManager);

        Task<int> PostAlbum(IAlbum song);

        Task<int> PutAlbum(Guid albumGuid, IAlbum value);

        Task<int> DeleteAlbumByID(Guid albumGuid);

        IAlbum NewAlbum();

        IAlbum NewAlbum(Guid albumID, string name, int? number_of_tracks, int? year, string cover, Guid artistID);
    }
}

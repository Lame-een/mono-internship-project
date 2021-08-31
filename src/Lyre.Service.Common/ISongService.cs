using Lyre.Common;
using Lyre.Model;
using Lyre.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Service.Common
{
    public interface ISongService
    {
        Task<ISong> GetSong(Guid songGuid);

        Task<List<ISong>> GetAllSongs(Pager pager, Sorter sorter, SongFilter filter);

        Task<int> PostSong(ISong song);

        Task<int> PutSong(Guid songGuid, ISong value);

        Task<int> DeleteSongByID(Guid songGuid);

        Task<int> DeleteSongByName(string name);

        ISong NewSong();

        ISong NewSong(Guid Song_id, string Name, Guid Album_id, Guid? Genre_id = null);
    }
}

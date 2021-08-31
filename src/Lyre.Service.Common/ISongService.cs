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

        Task<List<ISong>> GetAllSongs();

        Task<int> PostSong(ISong song);

        Task<int> PutSong(Guid songGuid, ISong value);

        Task<int> DeleteSong(Guid songGuid);
    }
}

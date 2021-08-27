using Lyre.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Repository.Common
{
    public interface ISongRepository
    {
        Task<ISong> GetSong(int id);

        Task<List<ISong>> GetAllSongs();

        Task<int> PostSong(ISong S);

        Task<int> PutSong(int id, string name);

        Task<int> DeleteSong(ISong S);
    }
}

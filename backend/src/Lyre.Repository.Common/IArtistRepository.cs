using Lyre.Model.Common;
using Lyre.Common;
using Lyre.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Repository.Common
{
    public interface IArtistRepository
    {
        Task<int> PostArtistAsync(IArtist newArtist);
        Task<List<IArtist>> GetAllArtistsAsync(QueryStringManager qsManager);
        Task<List<IArtist>> GetAllArtistsAsync();
        Task<IArtist> GetArtistByIDAsync(Guid id);
        Task<int> PutArtistAsync(IArtist artist);
        Task<int> DeleteArtistByIDAsync(Guid id);
    }
}

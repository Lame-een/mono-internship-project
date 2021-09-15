using Lyre.Model.Common;
using Lyre.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Service.Common
{
    public interface IArtistService
    {
        Task<int> PostArtistAsync(string newArtistName);
        Task<List<IArtist>> GetAllArtistsAsync(QueryStringManager qsManager);
        Task<List<IArtist>> GetAllArtistsAsync();
        Task<List<IArtistComposite>> GetArtistComposite(Guid artistGuid);
        Task<IArtist> GetArtistByIDAsync(Guid id);
        Task<int> PutArtistAsync(IArtist artist);
        Task<int> DeleteArtistByIDAsync(Guid id);
    }
}

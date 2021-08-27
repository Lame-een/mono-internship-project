using Lyre.Model.Common;
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
        Task<List<IArtist>> GetAllArtistsAsync();
        Task<IArtist> GetArtistByIDAsync(Guid id);
        Task<int> PutArtistAsync(IArtist artist);
        Task<int> DeleteArtistByIDAsync(Guid id);
    }
}

using Lyre.Model;
using Lyre.Model.Common;
using Lyre.Repository.Common;
using Lyre.Service.Common;
using Lyre.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Service
{
    public class ArtistService: IArtistService
    {
        protected IArtistRepository ArtistRepo { get; set; }
        public ArtistService(IArtistRepository artistRepo)
        {
            ArtistRepo = artistRepo;
        }

        public async Task<int> PostArtistAsync(string newArtistName)
        {
            IArtist newArtist = new Artist(Guid.NewGuid(), newArtistName, DateTime.Now);
            return await ArtistRepo.PostArtistAsync(newArtist);
        }

        public async Task<List<IArtist>> GetAllArtistsAsync(QueryStringManager qsManager)
        {
            return await ArtistRepo.GetAllArtistsAsync(qsManager);
        }
        public async Task<List<IArtist>> GetAllArtistsAsync()
        {
            return await ArtistRepo.GetAllArtistsAsync();
        }
        public async Task<IArtist> GetArtistByIDAsync(Guid id)
        {
            return await ArtistRepo.GetArtistByIDAsync(id);
        }
        public async Task<int> PutArtistAsync(IArtist artist)
        {
            return await ArtistRepo.PutArtistAsync(artist);
        }
        public async Task<int> DeleteArtistByIDAsync(Guid id) 
        {
            return await ArtistRepo.DeleteArtistByIDAsync(id);
        }
    }
}

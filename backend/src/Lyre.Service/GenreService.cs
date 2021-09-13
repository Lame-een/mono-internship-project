using Lyre.Model.Common;
using Lyre.Model;
using Lyre.Repository;
using Lyre.Repository.Common;
using Lyre.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Service
{
    public class GenreService: IGenreService
    {
        protected IGenreRepository GenreRepo { get; set; }
        public GenreService(IGenreRepository genreRepo)
        {
            GenreRepo = genreRepo;
        }

        public async Task<int> PostGenreAsync(string newGenreName)
        {
            IGenre newGenre = new Genre(Guid.NewGuid(), newGenreName);
            return await GenreRepo.PostGenreAsync(newGenre);
        }
        public async Task<List<IGenre>> GetAllGenresAsync()
        {
            return await GenreRepo.GetAllGenresAsync();
        }
        public async Task<IGenre> GetGenreByIDAsync(Guid id)
        {
            return await GenreRepo.GetGenreByIDAsync(id);
        }
        public async Task<IGenre> GetGenreByNameAsync(string genreName)
        {
            return await GenreRepo.GetGenreByNameAsync(genreName);
        }
        public async Task<int> PutGenreAsync(IGenre genre)
        {
            return await GenreRepo.PutGenreAsync(genre);
        }
        public async Task<int> DeleteGenreByIDAsync(Guid id)
        {
            return await GenreRepo.DeleteGenreByIDAsync(id);
        }
        public async Task<int> DeleteGenreByNameAsync(string genreName)
        {
            return await GenreRepo.DeleteGenreByNameAsync(genreName);
        }
    }
}
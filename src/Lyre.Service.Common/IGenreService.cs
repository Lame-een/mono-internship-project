using Lyre.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Service.Common
{
    public interface IGenreService
    {
        Task<int> PostGenreAsync(string newGenreName);
        Task<List<IGenre>> GetAllGenresAsync();
        Task<IGenre> GetGenreByIDAsync(Guid id);
        Task<int> PutGenreAsync(IGenre genre);
        Task<int> DeleteGenreByIDAsync(Guid id);
    }
}

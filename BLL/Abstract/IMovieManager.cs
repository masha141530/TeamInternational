using System.Collections.Generic;
using TeamProject.DAL.Entities;

namespace BLL.Abstract
{
    public interface IMovieManager
    {
        IEnumerable<Movie> GetMovies(int v);
    }
}
using BLL.Abstract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject.DAL;
using TeamProject.DAL.Entities;

namespace BLL.Managers
{
    public class MovieManager : IMovieManager
    {
        [Inject]
        ICinemaWork work;
        public MovieManager(ICinemaWork work)
        {
            this.work = work;
        }
        public IEnumerable<Movie> GetMovies(int count)
        {
            return work.Movies.Items.Take(count);
        }
    }
}

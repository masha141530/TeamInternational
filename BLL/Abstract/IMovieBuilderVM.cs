
using Bll.ViewModels;
using System.Collections.Generic;
using TeamProject.DAL.Entities;

namespace BLL.Abstract
{
    public interface IMovieBuilderVM
    {
        IEnumerable<MovieModel> GetVMList(IEnumerable<Movie> resultList);
    }
}
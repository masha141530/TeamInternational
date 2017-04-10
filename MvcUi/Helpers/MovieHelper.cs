using BLL.ViewModels.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamProject.DAL.Entities;

namespace MvcUi.Helpers
{
    public class MovieHelper
    {
        public static Movie GetByModel(MovieModel model)
        {
            return new Movie
            {
                Name = model.Name,
                ReleaseYear = model.ReleaseYear,
                AgeLimit = 0
            };
        }
    }
}
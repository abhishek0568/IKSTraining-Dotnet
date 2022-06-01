using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public interface IMovie
    {
        string Register(MovieModel movieModel);
        object SelectMovies();

        string Update(MovieModel movie);

        string Delete(int movieId);

        object Login(MovieModel movieModel);

        object SelectMovieById(int movieId);

    }
}

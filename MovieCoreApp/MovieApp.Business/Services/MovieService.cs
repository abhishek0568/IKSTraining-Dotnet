using MovieApp.Data.Repositories;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Services
{
    public class MovieService
    {
        IMovie _imovie;

        public MovieService(IMovie movie)
        {
            _imovie = movie;
            
        }

        public string Register(MovieModel movieModel)
        {
            return _imovie.Register(movieModel);
        }

        public object SelectMovies()
        {
            return _imovie.SelectMovies();
        }

        public object Login(MovieModel movieModel)
        {
            return _imovie.Login(movieModel);
        }

        public object SelectMovieById(int movieId)
        {
            return _imovie.SelectMovieById(movieId);
        }

        public string UpdateMovie(MovieModel movieModel)
        {
            return _imovie.Update(movieModel);
            
        }

        public string DeleteMovie(int movieId)
        {
            return _imovie.Delete(movieId);
        }
    }
}

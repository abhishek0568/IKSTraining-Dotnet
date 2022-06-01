using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System.Linq;

namespace MovieApp.Data.Repositories
{
    public class Movie : IMovie
    {
        MovieDbContext _movieDbContext;

        public Movie(MovieDbContext movieDbContext)
        { 
            _movieDbContext = movieDbContext;
        }
        

        public string Delete(int movieId)
        {
            var movie = _movieDbContext.movieModel.Find(movieId);
            if (movie == null)
                return " ";
            // _movieDbContext.Entry(movie).State = EntityState.Modified;
            _movieDbContext.movieModel.Remove(movie);

            _movieDbContext.SaveChanges();
            return "movie deleted";
        }

        public object Login(MovieModel movieModel)
        {
            MovieModel movieData = null;
            var movie= _movieDbContext.movieModel.Where(m => m.MovieId == movieModel.MovieId && m.Moviename == movieModel.Moviename).ToList();
            if (movie.Count > 0)
                movieData = movie[0];
            return movieData;
        }

       

        public string Register(MovieModel movieModel)
        {
            string msg= "";
            _movieDbContext.movieModel.Add(movieModel);
            _movieDbContext.SaveChanges();
            msg = "Inserted movie ";
            return msg;

        }

        public object SelectMovieById(int movieId)
        {
            var movie = _movieDbContext.movieModel.Find(movieId);
            if (movie == null)
                return " ";
            return movie;
        }

        public object SelectMovies()
        {
            List<MovieModel> movieList = _movieDbContext.movieModel.ToList();
            return movieList;
        }

        public string Update(MovieModel movieModel)
        {
            _movieDbContext.Entry(movieModel).State =EntityState.Modified;

            _movieDbContext.SaveChanges();
            return " movie details updated";

        }

        
    }
}

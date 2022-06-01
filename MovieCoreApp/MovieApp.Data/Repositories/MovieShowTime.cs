using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public class MovieShowTime : IMovieShowTime
    {
        MovieDbContext _movieDbContext;


        public MovieShowTime(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;

        }

        public string DeleteMovieShowTime(int ShowId)
        {

            string msg = "";
            MovieShowTimeModel movieShowTimeModel = _movieDbContext.movieShowTimeModel.Find(ShowId);
            _movieDbContext.movieShowTimeModel.Remove(movieShowTimeModel);
            _movieDbContext.SaveChanges();
            msg = "MovieShowTime Deleted!";
            return msg;

        }

        public string InsertMovieShowTime(MovieShowTimeModel movieShowTimeModel)
        {
            _movieDbContext.movieShowTimeModel.Add(movieShowTimeModel);
            _movieDbContext.SaveChanges();
            return "Inserted Movie Time";
        }

      
        public List<MovieShowTimeModel> ShowMovieShowTime()
        {
            return _movieDbContext.movieShowTimeModel.ToList();
        }

        public string UpdateMovieShowTime(MovieShowTimeModel movieShowTimeModel)
        {

            string msg = "";
            _movieDbContext.Entry(movieShowTimeModel).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
            msg = "MovieShowTime Succesfully Updated";
            return msg;
        }

        MovieShowTimeModel IMovieShowTime.SelectMovieShowTimeById(int ShowId)
        {
            return _movieDbContext.movieShowTimeModel.Find(ShowId);
        }
    }
}


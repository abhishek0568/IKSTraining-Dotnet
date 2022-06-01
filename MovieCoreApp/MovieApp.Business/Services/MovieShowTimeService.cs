using MovieApp.Data.Repositories;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Services
{
    public class MovieShowTimeService
    {
        IMovieShowTime _movieShowTime; 
        public MovieShowTimeService(IMovieShowTime movieShowTime)

        { 
            _movieShowTime = movieShowTime;

        }

        public string InsertMovieShowTime(MovieApp.Entity.MovieShowTimeModel movieShowTimeModel)
        {
            return _movieShowTime.InsertMovieShowTime(movieShowTimeModel);
        }
        public List<MovieApp.Entity.MovieShowTimeModel> ShowMovieShowTimeList()
        {
            return _movieShowTime.ShowMovieShowTime();
        }

        public MovieShowTimeModel SelectMovieShowTimeById(int ShowId)
        {
            return _movieShowTime.SelectMovieShowTimeById(ShowId);
        }

        public string UpdateMovieShowTime(MovieShowTimeModel movieShowTimeModel)
        {
            return _movieShowTime.UpdateMovieShowTime(movieShowTimeModel);
        }

        public string DeleteMovieShowTime(int ShowId)
        {
            return _movieShowTime.DeleteMovieShowTime(ShowId);
        }
    }
}

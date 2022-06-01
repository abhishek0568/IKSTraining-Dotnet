using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieApp.Entity;

namespace MovieApp.Data.DataConnection
{
    public class MovieDbContext: DbContext // DbContext is bridge betwwen sql tables and model and perform sql opearation

    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options):base(options)
        {

        }

        public DbSet<UserModel> userModel { get; set; }

        public DbSet<MovieModel> movieModel { get; set; }

        public DbSet<TheatreModel> theatreModel { get; set; }

        public DbSet<MovieShowTimeModel> movieShowTimeModel { get; set; }

        public DbSet<BookingModel> bookingModel { get; set; }

    }
}

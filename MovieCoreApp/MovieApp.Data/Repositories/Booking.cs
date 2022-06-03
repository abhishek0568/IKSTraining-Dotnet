using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public class Booking : IBooking
    {
        MovieDbContext _movieDbContext;

        public Booking(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public List<BookingModel> GetAllBooking()
        {
                return _movieDbContext.bookingModel.ToList();
            
        }

        public string RegisterBooking(BookingModel bookingModel)
        {

            string msg = "";
            _movieDbContext.bookingModel.Add(bookingModel);
            _movieDbContext.SaveChanges();
            msg = "Booking Rgistered Succesfully";
            return msg;
        }
    }
}

using MovieApp.Data.Repositories;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Services
{
    public class BookingService
    {
        IBooking _ibooking;

        //here we are accessing data layer by using IBooking refernece from repositories
        public BookingService(IBooking ibooking)
        {
            _ibooking = ibooking;
        }
        public string AddBooking(BookingModel bookingModel)
        {
            return _ibooking.RegisterBooking(bookingModel);
        }
    }
}

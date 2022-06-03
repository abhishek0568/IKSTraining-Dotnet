﻿using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public  interface IBooking
    {
        public string RegisterBooking (BookingModel bookingModel);

        public List<BookingModel> GetAllBooking();
    }
}

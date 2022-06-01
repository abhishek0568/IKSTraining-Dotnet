using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositories;
using MovieApp.Entity;

namespace MovieApp.Business.Services
{
    public class TheatreService
    {
        ITheatre _itheatre;

        public TheatreService(ITheatre theatre)
        {
            _itheatre = theatre;
        }

        public string Register(TheatreModel theatreModel)
        {
            return _itheatre.Register(theatreModel);
        }

        public object SelectTheatres()
        {
            return _itheatre.SelectTheatres();
        }

        public string DeleteTheatre(int theatreId)
        {
            return (_itheatre.DeleteTheatre(theatreId));
        }

        public string UpdateTheatre(TheatreModel theatreModel)
        {

            return _itheatre.UpdateTheatre(theatreModel);
        }

        public object SelectTheatreById(int theatreId)
        {
            return _itheatre.SelectTheatreById(theatreId);
        }

    }
}

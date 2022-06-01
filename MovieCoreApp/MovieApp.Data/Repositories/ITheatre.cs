using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public interface ITheatre
    {
        string Register(TheatreModel theatreModel);

        string UpdateTheatre(TheatreModel theatre);

        string DeleteTheatre(int theatreId);

        object SelectTheatres();

        object SelectTheatreById(int movieId);

       
    }
}

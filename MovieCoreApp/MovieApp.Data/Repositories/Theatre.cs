using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.Data.Repositories
{
    public class Theatre : ITheatre
    {
        MovieDbContext _movieDbContext;

        public Theatre(MovieDbContext movieDbContext)
        { 
            _movieDbContext = movieDbContext;
        
        }
        public string Register(TheatreModel theatreModel)
        {
            string msg = "";
            _movieDbContext.theatreModel.Add(theatreModel);
            _movieDbContext.SaveChanges();
            msg = "Theatre Inserted";
            return msg;

        }
        public string UpdateTheatre(TheatreModel theatreModel)
        {
            _movieDbContext.Entry(theatreModel).State = EntityState.Modified;
            
            _movieDbContext.SaveChanges();
            return "Theatre updated";

        }  
        public string DeleteTheatre(int theatreId)
        {

            var theatre = _movieDbContext.theatreModel.Find(theatreId);
            if (theatre == null)
                return " ";
            // _movieDbContext.Entry(theatre).State = EntityState.Modified;
            _movieDbContext.theatreModel.Remove(theatre);

            _movieDbContext.SaveChanges();
            return "Theatre deleted";

        }
        public object SelectTheatres()
        { 
            List<TheatreModel> theatreList = _movieDbContext.theatreModel.ToList();
            return theatreList;

        
        }
        public object SelectTheatreById(int theatreId)
        {
            var theatre= _movieDbContext.theatreModel.Find(theatreId);
            if (theatre == null)
                return " ";
            return theatre;

        }
       
    }
}

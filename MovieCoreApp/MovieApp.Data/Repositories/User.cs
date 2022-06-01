using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System.Linq; //mainly do select operation and also crud operation(do sql query)

namespace MovieApp.Data.Repositories
{
    public class User : IUser
    {
        MovieDbContext _movieDbContext;

        public User(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;

        }

        public string Delete(int userId)
        {

            var user = _movieDbContext.userModel.Find(userId);
            if (user == null)
                return " ";
           // _movieDbContext.Entry(user).State = EntityState.Modified;
            _movieDbContext.userModel.Remove(user);
           
            _movieDbContext.SaveChanges();
            return "user deleted";
        }

        public object Login(UserModel userModel)
        {
            // linq concept
            // var result=from table in userModel
            // select table
            // select * from userModel wre email=userModel.email and password=userModel.password
            UserModel userData = null;
            var user = _movieDbContext.userModel.Where(u => u.Email == userModel.Email && u.Password == userModel.Password).ToList();
            if (user.Count > 0)
                userData = user[0];
                return userData;
        }

        public string Register(UserModel userModel)
        {
            string msg = "";
            // insert into userModel values(userModel.id, userModel.fname, userModel.lname)
            _movieDbContext.userModel.Add(userModel);
            _movieDbContext.SaveChanges(); // execute sql statement
            msg = "Inserted";
            return msg;
        }

        public object SelectUserById(int userId)
        {
           var user= _movieDbContext.userModel.Find(userId);
            if (user == null)
                return " ";
            return user;
        }

        public object SelectUsers()
        {
            // select * from userModel
            List<UserModel> userList = _movieDbContext.userModel.ToList();
            return userList;
        }

        public string Update(UserModel userModel)
        {
            
            _movieDbContext.Entry(userModel).State = EntityState.Modified;
            
            _movieDbContext.SaveChanges();
            return "user updated";

        }
    }
}

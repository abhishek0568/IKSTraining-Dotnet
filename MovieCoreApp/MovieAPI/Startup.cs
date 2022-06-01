using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MovieApp.Business.Services;
using MovieApp.Data.DataConnection;
using MovieApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)

        {
            string sqlConnection = Configuration.GetConnectionString("SqlConnection"); // reading connection string value from upsetting file
           
            services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(sqlConnection));// registering MovieDbContext & making connection establishement
            services.AddTransient<IUser, User>();
            services.AddTransient<UserService, UserService>();
            services.AddTransient<IMovie, Movie>();
            services.AddTransient<MovieService, MovieService>();
            services.AddTransient<ITheatre, Theatre>();
            services.AddTransient<TheatreService, TheatreService>();
            services.AddTransient<IMovieShowTime, MovieShowTime>();
            services.AddTransient<MovieShowTimeService, MovieShowTimeService>();
            services.AddTransient<IBooking, Booking>();
            services.AddTransient<BookingService, BookingService>();
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddSwaggerGen(c =>
            {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1"});
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();

            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyMovieAPi");
            });// same as apostman we can see output in UI in json format

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class MovieShowTimeController : Controller
    {

        IConfiguration _configuration;
        public MovieShowTimeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> ShowMovieTime()
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
               
                string endPoint = _configuration["WebAPiURL"] + "MovieShowTime/ShowMovieShowTimeList";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieShowTimeModel = JsonConvert.DeserializeObject<List<MovieShowTimeModel>>(result);

                        return View(movieShowTimeModel);
                       
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "No entries found!";
                    }
                }
            }

            return View();
        }



        public async Task<IActionResult> InsertMovieShowTimes()
        {

            List<MovieModel> movieModel = null;
            List<SelectListItem> movieList = new List<SelectListItem>();

            SelectListItem item1 = new SelectListItem();


            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Movie/SelectMovies";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        movieModel = JsonConvert.DeserializeObject<List<MovieModel>>(result);

                    }
                }
            }

            item1.Text = "Select";
            item1.Value = "0";
            movieList.Add(item1);
            foreach (var movie in movieModel)
            {
                item1 = new SelectListItem();
                item1.Text = movie.Moviename;
                item1.Value = movie.MovieId.ToString();
                movieList.Add(item1);
            }

            ViewBag.movieShowList = movieList;
            /*TempData["movieShowList"] = movieList;*/

            List<TheatreModel> theatreModel = null;
            List<SelectListItem> theatrelist = new List<SelectListItem>();

            SelectListItem item2 = new SelectListItem();


            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Theatre/SelectTheatres";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        theatreModel = JsonConvert.DeserializeObject<List<TheatreModel>>(result);

                    }
                }
            }

            item2.Text = "Select";
            item2.Value = "0";
            theatrelist.Add(item2);
            foreach (var theatre in theatreModel)
            {
                item2 = new SelectListItem();
                item2.Text = theatre.TheatreName;
                item2.Value = theatre.TheatreId.ToString();
                theatrelist.Add(item2);
            }

            ViewBag.theatreShowList = theatrelist;
            /* TempData["theatreShowList"] = theatrelist;*/

            return View();

        }


        [HttpPost]
        public async Task<IActionResult> InsertMovieShowTimes( MovieShowTimeModel movieShowTimeModel)
        {

            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieShowTimeModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebAPiURL"] + "MovieShowTime/InsertMovieShowTimeList";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Inserted successfully!";

                        return RedirectToAction("InsertMovieShowTimes", "MovieShowTime");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> UpdateMovieshowTimes(int ShowId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "MovieShowTime/SelectMovieShowTimeById?ShowId=" + ShowId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieShowTimes = JsonConvert.DeserializeObject<MovieShowTimeModel>(result);
                        return View(movieShowTimes);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "No Data Found!";
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMovieshowTimes(MovieShowTimeModel movieShowTimeModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieShowTimeModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "MovieShowTime/UpdateMovieShowTime";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "MovieShowTime-Updated-Successfuly!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong-Entries!!";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> DeleteMovieshowTimes(int ShowId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "MovieShowTime/SelectMovieShowTimeById?id=" + ShowId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieShowTimes = JsonConvert.DeserializeObject<MovieShowTimeModel>(result);
                        return View(movieShowTimes);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "No Data Found!";
                    }
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteMovieshowTimes(MovieShowTimeModel movieShowTimeModel)
        {
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiURL"] + "MovieShowTime/DeleteMovieShowTime?ShowId=" + movieShowTimeModel.ShowId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "MovieShowTime-Deleted-Successfuly!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong-Entries!!";
                    }
                }
            }
            return View();
        }

    }
}


using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class MovieController : Controller
    {
        IConfiguration _configuration;
        public MovieController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> ShowMovieDetails()
        {
            //Fetch API,Axios Api, HTTPClient
            //HTTP Req/response

            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                // api url- http://localhost:5000/api/Movie/SelectMovies // (endpoint url)congigure this api url in upsetting file in MovieApp.UI
                // StringContent content = new StringContent(JsonConvert.SerializeObject(userInfo), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebAPiURL"] + "Movie/SelectMovies";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieModel = JsonConvert.DeserializeObject<IEnumerable<MovieModel>>(result);

                        //var userModel= JsonSerializer.Deserialize<List<MovieModel>>(result);
                        //  MovieModel movieModel = result;
                        //object->JSON->http POST
                        //object<-JSON<-HTTP GET
                        // ViewBag.Status = "Ok";
                        //ViewBag.message = " movie details succesfully";

                        return View(movieModel);
                        // return RedirectToAction("Index", "Movies");
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong movie entries!";
                    }
                }
            }

            return View();
        }

        public IActionResult MovieRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MovieRegister(MovieModel movieModel)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebAPiURL"] + "Movie/Register";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Movie register successfully!";
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

        public IActionResult MovieLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MovieLogin(MovieModel movieModel)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebAPiURL"] + "Movie/Login";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Movie entry Present";
                    }
                    // return RedirectToAction("Index", "Movies");
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "No such movie present!";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> EditMovie(int movieId)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                
                //  StringContent content = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebAPiURL"] + "Movie/SelectMovieById?movieId=" + movieId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieModel = JsonConvert.DeserializeObject<MovieModel>(result); 

                        return View(movieModel);
                    
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong movie entries!";
                    }
                }
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> EditMovie(MovieModel movieModel)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebAPiURL"] + "Movie/UpdateMovie";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //var result = await response.Content.ReadAsStringAsync();
                        //var movieModel = JsonConvert.DeserializeObject<MovieModel>(result); // getting only single record of usermodel

                        //var movieModel= JsonSerializer.Deserialize<List<MovieModel>>(result);
                        // MovieModel movieModel = result;
                        //object->JSON->http POST
                        //object<-JSON<-HTTP GET
                        ViewBag.Status = "Ok";
                        ViewBag.message = " Movie updated! ";

                        //return View(movieModel);
                        // return RedirectToAction("Index", "Movies");
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong movie entries!";
                    }
                }
            }

            return View();
        }

        public async Task<IActionResult> Delete(int movieId)
        {

            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebAPiURL"] + "Movie /SelectMovieById?movieId=" + movieId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieModel = JsonConvert.DeserializeObject<MovieModel>(result);


                        // UserModel userModel = result;

                        //ViewBag.Status = "Ok";
                        //ViewBag.message = " user Deleted! ";

                        return View(movieModel);

                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong user entries!";
                    }
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MovieModel movieModel)
        {


            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebAPiURL"] + "Movie/DeleteMovie?movieId=" + movieModel.MovieId;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TempData["token"].ToString());
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //var result = await response.Content.ReadAsStringAsync();
                        //var movieModel = JsonConvert.DeserializeObject<MovieModel>(result); // getting only single record of movieModel

                        //var movieModel= JsonSerializer.Deserialize<List<MovieModel>>(result);
                        // MovieModel movieModel = result;

                        ViewBag.Status = "Ok";
                        ViewBag.message = " Movie Deleted! ";

                        //return View(movieModel);

                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Movie entries!";
                    }
                }
            }

            return View();
        }

    }
}

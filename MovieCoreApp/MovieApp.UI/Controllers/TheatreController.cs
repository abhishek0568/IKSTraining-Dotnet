using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class TheatreController : Controller
    {

        IConfiguration _configuration;
        public TheatreController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> ShowTheatreDetails()
        {

            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
              
                // StringContent content = new StringContent(JsonConvert.SerializeObject(theatreInfo), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebAPiURL"] + "Theatre/SelectTheatres";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var theatreModel = JsonConvert.DeserializeObject<IEnumerable<TheatreModel>>(result);

                        return View(theatreModel);
                     
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Theatre entries!";
                    }
                }
            }

            return View();
        }

        public IActionResult TheatreRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TheatreRegister(TheatreModel theatreModel)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theatreModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebAPiURL"] + "Theatre/Register";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Register successfully!";  
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

        [HttpGet]
        public async Task<IActionResult> EditTheatre(int theatreId)
        {
           
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                
                //  StringContent content = new StringContent(JsonConvert.SerializeObject(theatreModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebAPiURL"] + "Theatre/SelectTheatreById?theatreId=" + theatreId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var theatreModel = JsonConvert.DeserializeObject<TheatreModel>(result); // getting only single record of usermodel

                        return View(theatreModel);
                       
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong theatre entries!";
                    }
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditTheatre(TheatreModel theatreModel)
        {
            
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
               
                StringContent content = new StringContent(JsonConvert.SerializeObject(theatreModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebAPiURL"] + "Theatre/UpdateTheatre";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                       
                        ViewBag.Status = "Ok";
                        ViewBag.message = " Theatre updated! ";

                        //return View(theatreModel);
                        // return RedirectToAction("Index", "Movies");
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong theatre entries!";
                    }
                }
            }

            return View();
        }

        public async Task<IActionResult> Delete(int theatreId)
        {

            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebAPiURL"] + "Theatre/SelectTheatreById?theatreId="+theatreId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var theatreModel = JsonConvert.DeserializeObject<TheatreModel>(result);


                        // UserModel userModel = result;

                        //ViewBag.Status = "Ok";
                        //ViewBag.message = " user Deleted! ";

                        return View(theatreModel);

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
        public async Task<IActionResult> Delete(TheatreModel theatreModel)
        {


            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebAPiURL"] + "Theatre/DeleteTheatre?theatreId="+theatreModel.TheatreId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        

                        ViewBag.Status = "Ok";
                        ViewBag.message = " Theatre Deleted! ";

                        return View(theatreModel);

                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong theatre entries!";
                    }
                }
            }

            return View();
        }


    }
}

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
    public class UserController : Controller
    {
        IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> ShowUserDetails()
        {
            //Fetch API,Axios Api, HTTPClient
            //HTTP Req/response

            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                // api url- http://localhost:5000/api/User/SelectUsers // (endpoint url)congigure this api url in upsetting file in MovieApp.UI
                // StringContent content = new StringContent(JsonConvert.SerializeObject(userInfo), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebAPiURL"] + "User/SelectUsers";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<IEnumerable<UserModel>>(result);

                        //var userModel= JsonSerializer.Deserialize<List<UserModel>>(result);
                        // UserModel userModel = result;
                        //object->JSON->http POST
                        //object<-JSON<-HTTP GET
                        // ViewBag.Status = "Ok";
                        //ViewBag.message = " user details succesfully";

                        return View(userModel);
                        // return RedirectToAction("Index", "Movies");
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

        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserModel userModel)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebAPiURL"] + "User/Register";
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

        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(UserModel userModel)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebAPiURL"] + "User/Login";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = " Login Successfully";
                    }
                    // return RedirectToAction("Index", "Movies");
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong credentials!";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> EditUser(int userId)
        {
            //Fetch API,Axios Api, HTTPClient
            //HTTP Req/response

            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                // api url- http://localhost:5000/api/User/SelectUsers // (endpoint url)congigure this api url in upsetting file in MovieApp.UI
                //  StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebAPiURL"] + "User/SelectUserById?userId=" + userId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<UserModel>(result); // getting only single record of usermodel

                        //var userModel= JsonSerializer.Deserialize<List<UserModel>>(result);
                        // UserModel userModel = result;
                        //object->JSON->http POST
                        //object<-JSON<-HTTP GET
                        // ViewBag.Status = "Ok";
                        //ViewBag.message = " user details succesfully";

                        return View(userModel);
                        // return RedirectToAction("Index", "Movies");
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
        public async Task<IActionResult> EditUser(UserModel userModel)
        {
            //Fetch API,Axios Api, HTTPClient
            //HTTP Req/response

            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                // api url- http://localhost:5000/api/User/SelectUsers // (endpoint url)congigure this api url in upsetting file in MovieApp.UI
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebAPiURL"] + "User/UpdateUser";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //var result = await response.Content.ReadAsStringAsync();
                        //var userModel = JsonConvert.DeserializeObject<UserModel>(result); // getting only single record of usermodel

                        //var userModel= JsonSerializer.Deserialize<List<UserModel>>(result);
                        // UserModel userModel = result;
                        //object->JSON->http POST
                        //object<-JSON<-HTTP GET
                        ViewBag.Status = "Ok";
                        ViewBag.message = " user updated! ";

                        //return View(userModel);
                        // return RedirectToAction("Index", "Movies");
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

      
        public async Task<IActionResult> Delete(int userId)
        {

            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {

              string endPoint = _configuration["WebAPiURL"] + "User/SelectUserById?userId="+ userId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<UserModel>(result);


                        // UserModel userModel = result;

                        //ViewBag.Status = "Ok";
                        //ViewBag.message = " user Deleted! ";

                        return View(userModel);

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
        public async Task<IActionResult> Delete(UserModel userModel)
        {
            

            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                
                string endPoint = _configuration["WebAPiURL"] + "User/DeleteUser?userId="+userModel.UserId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //var result = await response.Content.ReadAsStringAsync();
                        //var userModel = JsonConvert.DeserializeObject<UserModel>(result); // getting only single record of usermodel

                        //var userModel= JsonSerializer.Deserialize<List<UserModel>>(result);
                        // UserModel userModel = result;
                      
                        ViewBag.Status = "Ok";
                        ViewBag.message = " user Deleted! ";

                        //return View(userModel);
                       
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

        
    }
}
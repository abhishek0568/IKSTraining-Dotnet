using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class BookingController : Controller
    {
        IConfiguration _configuration;

        public BookingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //public async Task<IActionResult> BookingRegistration(int movieId)
        //{
        //    ViewBag.MovieId = movieId;
        //    using (HttpClient client = new HttpClient())
        //    {
        //        string endpoint = _configuration["WebApiURL"] + "User/SelectUsers";
        //        using (var response = await client.GetAsync(endpoint))
        //        {
        //            if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                var result = await response.Content.ReadAsStringAsync();
        //                // var userModels = Newtonsoft.Json.JsonSerializer.Deserialize<List<UserModel>>(result);
        //                var userModels = JsonConvert.DeserializeObject<IEnumerable<UserModel>>(result);
        //                List<SelectListItem> selectListItems = new List<SelectListItem>();
        //                foreach (var item in userModels)
        //                {
        //                    SelectListItem selectListItem2 = new SelectListItem();
        //                    selectListItem2.Text = item.Firstname;
        //                    selectListItem2.Value = item.UserId.ToString();
        //                    selectListItems.Add(selectListItem2);
        //                    ViewBag.UserData = selectListItems;
                            
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
        
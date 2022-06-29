using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmpTravelBookingUI.Models;
using Newtonsoft.Json;
using System.Text;

namespace EmpTravelBookingUI.Controllers
{
    public class UsersController : Controller
    {
        // GET: UserController
        public async Task<ActionResult> Index()
        {
            List<User> userList = new List<User>();
            HttpClient clientObj = new HttpClient();
            string url = "https://localhost:7058/api/Users";

            var response = clientObj.GetAsync(url);
            string apiResponse = await response.Result.Content.ReadAsStringAsync();


            userList = JsonConvert.DeserializeObject<List<User>>(apiResponse);
            return View(userList);

        }


        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        [HttpPost]
        public async Task<IActionResult> Create(User userObj)
        {
            User usr = new User();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userObj), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7058/api/Users/add", content))
                {


                }

            }
            return RedirectToAction(nameof(Index));
        }


        // GET: UserController/Edit/5
 

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id)
        {
            User userObj = new User();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44325/api/Users/update/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userObj = JsonConvert.DeserializeObject<User>(apiResponse);
                }
            }
            return View(userObj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, User prodObj)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44325/api/Users/update/");
            string data = JsonConvert.SerializeObject(prodObj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + prodObj.UserId.ToString(), content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

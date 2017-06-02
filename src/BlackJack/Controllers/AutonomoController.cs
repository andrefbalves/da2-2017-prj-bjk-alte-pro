using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackJack.Models;
using System.Net.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BlackJack.Controllers
{
    public class AutonomoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(NewGameApiRequest novoJogador)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        HttpClient client = MyHTTPClientNewGame.Client;
        //        string path = "/api/NewGame";
        //        HttpResponseMessage response = client.PostAsJsonAsync(path, novoJogador).Result;
        //        if (!response.IsSuccessStatusCode)
        //        {
        //            return View("Index");
        //        }

        //        PlayApiResponse ng = response.Content.ReadAsAsync<PlayApiResponse>().Result;
                
        //    }
            
        //}
    }
}

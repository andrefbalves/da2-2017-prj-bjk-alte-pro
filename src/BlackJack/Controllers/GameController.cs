using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackJack.Models;
using System.Net.Http;

namespace BlackJack.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(NewGameApiRequest novoJogador)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = MyHTTPClientNewGame.Client;
                string path = "/api/NewGame";
                HttpResponseMessage response = client.PostAsJsonAsync(path, novoJogador).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return View();
                }

                PlayApiResponse ng = response.Content.ReadAsAsync<PlayApiResponse>().Result;
                return View("PlayGame", ng);
            }
            else
                return View();
        }

        [HttpPost]
        public IActionResult PlayGame(int id, int playerAction, double initialBet)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = MyHTTPClientNewGame.Client;
                string path = "/api/Play";
                PlayApiRequest req = new PlayApiRequest(id, playerAction, initialBet);
                HttpResponseMessage response = client.PostAsJsonAsync(path, req).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return View();
                }

                PlayApiResponse nr = response.Content.ReadAsAsync<PlayApiResponse>().Result;
                return View(nr);
            }
            else
                return View();
        }



    }
}

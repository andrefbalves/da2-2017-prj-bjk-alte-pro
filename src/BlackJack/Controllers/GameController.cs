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
        public IActionResult PlayGame(int id, PlayerAction playerAction, int initialBet)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = MyHTTPClientNewGame.Client;
                string path = "/api/Play";
                PlayApiRequest req = new PlayApiRequest(id, (int)playerAction, initialBet);
                HttpResponseMessage response = client.PostAsJsonAsync(path, req).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return View();
                }

                PlayApiResponse nr = response.Content.ReadAsAsync<PlayApiResponse>().Result;
                if (playerAction == PlayerAction.Double)
                    nr.Bet = initialBet * 2;
                else
                    nr.Bet = initialBet;
                

                return View(nr);
            }
            else
                return View();
        }

        [HttpPost]
        public IActionResult QuitGame(int id)
        {
            HttpClient client = MyHTTPClientNewGame.Client;
            string path = "/api/Play/rGAUUmCfk3vUgfSF/" + id;           
            HttpResponseMessage resp = client.GetAsync(path).Result;
            if (!resp.IsSuccessStatusCode)
            {
                return View();
            }
            PlayApiResponse nr = resp.Content.ReadAsAsync<PlayApiResponse>().Result;
            Player newplayer = new Player(nr);
            Repository.AddPlayer(newplayer);

            string pathq = "/api/Quit";
            QuitApiRequest reqq = new QuitApiRequest(id);
            HttpResponseMessage response = client.PostAsJsonAsync(pathq, reqq).Result;
            if (!response.IsSuccessStatusCode)
            {
                return View();
            }

            return Redirect("/Home/HighScores");
        }


    }
}

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

        [HttpPost]
        public IActionResult Index(NewGameApiRequest novoJogador)
        {
            if (ModelState.IsValid)
            {
                //Novo Jogo
                HttpClient client = MyHTTPClientNewGame.Client;
                string path = "/api/NewGame";
                HttpResponseMessage response = client.PostAsJsonAsync(path, novoJogador).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return View("Index");
                }

                PlayApiResponse ng = response.Content.ReadAsAsync<PlayApiResponse>().Result;

                //Nova Ronda
                if (ng.PlayingRound == false)
                {
                    PlayApiRequest req = new PlayApiRequest(ng.GameId, (int)PlayerAction.NewRound, 10);
                    response = client.PostAsJsonAsync("/api/Play", req).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        return View("Index");
                    }

                    PlayApiResponse nr = response.Content.ReadAsAsync<PlayApiResponse>().Result;

                    // 1 Ronda
                    if (nr.PlayerName == "auto1")  
                    {
                        PlayerAction playerAction;

                        CardMethods card = new CardMethods();

                        if (card.ValueHands(nr.Dealerhand) >= 8 && card.ValueHands(ng.Dealerhand) <= 11)
                            playerAction = PlayerAction.Double;
                        else if (card.ValueHands(nr.Dealerhand) <= 18)
                            playerAction = PlayerAction.Hit;
                        else if (card.ValueHands(nr.Dealerhand) > 19)
                            playerAction = PlayerAction.Stand;                       
                        else
                            playerAction = PlayerAction.Surrender;

                        req = new PlayApiRequest(ng.GameId, (int)playerAction, 10);
                        response = client.PostAsJsonAsync("/api/Play", req).Result;
                        if (!response.IsSuccessStatusCode)
                        {
                            return View("Index");
                        }

                        PlayApiResponse res = response.Content.ReadAsAsync<PlayApiResponse>().Result;

                        return View("Result", res);
                    }
                    else
                        return View();
                }
                else
                    return View();
            }
            else
                return View();
        }
    }
}
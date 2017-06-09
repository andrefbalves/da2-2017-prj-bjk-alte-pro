﻿using System;
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
                Game game = new Game();

                HttpClient client = MyHTTPClientNewGame.Client;
                string path = "/api/NewGame";
                HttpResponseMessage response = client.PostAsJsonAsync(path, novoJogador).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return View("Index");
                }

                PlayApiResponse ng = response.Content.ReadAsAsync<PlayApiResponse>().Result;
                game.GameId = ng.GameId;
                Repository.AddPlayer(game);

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
                CardMethods card = new CardMethods();
                HttpClient client = MyHTTPClientNewGame.Client;
                string path = "/api/Play";
                PlayApiRequest req = new PlayApiRequest(id, (int)playerAction, initialBet);
                HttpResponseMessage response = client.PostAsJsonAsync(path, req).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return View("Index");
                }

                PlayApiResponse nr = response.Content.ReadAsAsync<PlayApiResponse>().Result;

                if (playerAction == PlayerAction.Double)
                    ViewBag.Bet = initialBet * 2;
                else
                    ViewBag.Bet = initialBet;

                if (nr.PlayingRound == false)
                {

                    if (nr.RoundFinalResult == (int)RoundFinalResult.Win)
                        Repository.Wins = Repository.Wins + 1;
                    else if (nr.RoundFinalResult == (int)RoundFinalResult.Lose)
                        Repository.Loses = Repository.Loses + 1;
                    else if (nr.RoundFinalResult == (int)RoundFinalResult.Empate)
                        Repository.Ties = Repository.Ties + 1;
                    else if (nr.RoundFinalResult == (int)RoundFinalResult.BlackJack)
                    {
                        Repository.BlackJack = Repository.BlackJack + 1;
                        Repository.Wins = Repository.Wins + 1;
                        ViewBag.Result = ViewBag.Bet * 1.5;
                    }
                    else if (nr.RoundFinalResult == (int)RoundFinalResult.Surrender)
                        ViewBag.Result = ViewBag.Bet / 2;
                }

                ViewBag.DealerHand = card.ValueHands(nr.Dealerhand);
                ViewBag.PlayerHand = card.ValueHands(nr.PlayerHand);

                return View(nr);

            }
            else
                return View();
        }

        [HttpPost]
        public IActionResult QuitGame(int id)
        {
            Game game = new Game();
            HttpClient client = MyHTTPClientNewGame.Client;
            string path = "/api/Play/rGAUUmCfk3vUgfSF/" + id;
            HttpResponseMessage resp = client.GetAsync(path).Result;
            if (!resp.IsSuccessStatusCode)
            {
                return View("Index");
            }
            PlayApiResponse nr = resp.Content.ReadAsAsync<PlayApiResponse>().Result;

            game.PlayerName = nr.PlayerName;
            game.Rounds = nr.RoundCount;
            game.Credits = nr.PlayerCredits;
            game.Wins = Repository.Wins;
            game.Ties = Repository.Ties;
            game.Loses = Repository.Loses;
            game.BlackJack = Repository.BlackJack;
            Repository.AddPlayer(game);

            string pathq = "/api/Quit";
            QuitApiRequest reqq = new QuitApiRequest(id);
            HttpResponseMessage response = client.PostAsJsonAsync(pathq, reqq).Result;
            if (!response.IsSuccessStatusCode)
            {
                return View("Index");
            }

            return Redirect("/Home/HighScores");
        }


    }
}

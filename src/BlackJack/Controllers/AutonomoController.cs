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
                    RoundSummary rs = new RoundSummary();
                    rs.InitialCredits = ng.PlayerCredits;
                    rs.Bet = req.InitialBet;


                    // 1 Ronda
                    if (nr.PlayerName == "auto1")
                    {
                        PlayerAction playerAction;

                        CardMethods card = new CardMethods();

                        if (card.ValueHands(nr.PlayerHand) >= 8 && card.ValueHands(ng.PlayerHand) <= 11)
                        {
                            playerAction = PlayerAction.Double;
                            rs.Double = true;
                            rs.Bet = rs.Bet + rs.Bet;
                        }
                        else if (card.ValueHands(nr.PlayerHand) <= 18)
                            playerAction = PlayerAction.Hit;
                        else if (card.ValueHands(nr.PlayerHand) > 19)
                            playerAction = PlayerAction.Stand;
                        else
                            playerAction = PlayerAction.Surrender;

                        if (nr.RoundFinalResult == (int)RoundFinalResult.BlackJack)
                            rs.Blackjack = true;

                        req = new PlayApiRequest(ng.GameId, (int)playerAction, 10);
                        response = client.PostAsJsonAsync("/api/Play", req).Result;
                        if (!response.IsSuccessStatusCode)
                        {
                            return View("Index");
                        }

                        PlayApiResponse res = response.Content.ReadAsAsync<PlayApiResponse>().Result;

                        if (card.ValueHands(res.Dealerhand) == 21)
                            rs.DealerBlackjack = true;

                        rs.Rounds = res.RoundCount;
                        rs.RoundResult = res.RoundFinalResult;
                        rs.FinalCredits = res.PlayerCredits;
                        Repository.AddRound(rs);
                        List<RoundSummary> rounds = Repository.Rounds;

                        return View("Result", rounds);
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
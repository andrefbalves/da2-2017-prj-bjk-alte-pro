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

                PlayApiResponse nr = response.Content.ReadAsAsync<PlayApiResponse>().Result;


                //Nova Ronda                                 
                int rd = 0;
                if (nr.PlayerName == "auto1")
                    rd = 1;
                else if (nr.PlayerName == "auto3")
                    rd = 3;
                else if (nr.PlayerName == "auto10")
                    rd = 10;
                              
             

                // Ronda
                while (nr.RoundCount < rd)
                {
                    RoundSummary rs = new RoundSummary(); 

                    if (nr.PlayingRound == false)
                    {                       
                        PlayApiRequest rq = new PlayApiRequest(nr.GameId, (int)PlayerAction.NewRound, 10);
                        response = client.PostAsJsonAsync("/api/Play", rq).Result;
                        if (!response.IsSuccessStatusCode)
                        {
                            return View("Index");
                        }

                        nr = response.Content.ReadAsAsync<PlayApiResponse>().Result;
                        rs.Rounds = nr.RoundCount;
                        rs.InitialCredits = nr.PlayerCredits;
                        rs.Bet = rq.InitialBet;
                    }

                    PlayerAction playerAction;

                    CardMethods card = new CardMethods();

                    if (card.ValueHands(nr.PlayerHand) >= 8 && card.ValueHands(nr.PlayerHand) <= 11)
                    {
                        playerAction = PlayerAction.Double;
                        rs.Double = true;
                        rs.Bet = rs.Bet + rs.Bet;
                    }
                    else if (card.ValueHands(nr.PlayerHand) <= 18)
                        playerAction = PlayerAction.Hit;
                    else if (card.ValueHands(nr.PlayerHand) >= 19)
                        playerAction = PlayerAction.Stand;
                    else
                        playerAction = PlayerAction.Surrender;

                    if (nr.RoundFinalResult == (int)RoundFinalResult.BlackJack)
                        rs.Blackjack = true;

                    PlayApiRequest req = new PlayApiRequest(nr.GameId, (int)playerAction, 10);
                    response = client.PostAsJsonAsync("/api/Play", req).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        return View("Index");
                    }

                    nr = response.Content.ReadAsAsync<PlayApiResponse>().Result;

                    if (nr.PlayingRound == false)
                    {
                        if (card.ValueHands(nr.Dealerhand) == 21)
                            rs.DealerBlackjack = true;
                                               
                        rs.RoundResult = nr.RoundFinalResult;
                        rs.FinalCredits = nr.PlayerCredits;
                        Repository.AddRound(rs);                        
                    }
                }
                return View("Result", Repository.Rounds);
            }
            else
                return View();
        }
    }
}


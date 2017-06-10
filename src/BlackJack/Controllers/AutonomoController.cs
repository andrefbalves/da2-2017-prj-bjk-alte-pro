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



                int rd = 0;
                if (nr.PlayerName == "auto1")
                    rd = 1;
                else if (nr.PlayerName == "auto3")
                    rd = 3;
                else if (nr.PlayerName == "auto10")
                    rd = 10;
                else if (nr.PlayerName == "auto0")
                    rd = 100;

                Repository.ClearRounds();



                // Ciclo de rondas
                while (nr.RoundCount < rd && nr.PlayerCredits >= 10)
                {
                    RoundSummary rs = new RoundSummary();
                    rs.Blackjack = false;

                    int initialBet = 0;
                    if (nr.PlayerCredits > 200)
                        initialBet = 50;
                    else if (nr.PlayerCredits > 100)
                        initialBet = 25;
                    else
                        initialBet = 10;

                    rs.InitialCredits = nr.PlayerCredits;

                    PlayApiRequest rq = new PlayApiRequest(nr.GameId, (int)PlayerAction.NewRound, initialBet);
                    response = client.PostAsJsonAsync("/api/Play", rq).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        return View("Index");
                    }

                    nr = response.Content.ReadAsAsync<PlayApiResponse>().Result;

                    rs.Rounds = nr.RoundCount + 1;

                    if (nr.RoundFinalResult == (int)RoundFinalResult.BlackJack)
                        rs.Blackjack = true;


                    //Jogadas
                    while (nr.PlayingRound == true && nr.PlayerCredits >= 10)
                    {
                        PlayerAction playerAction;

                        CardMethods card = new CardMethods();

                        int playerHand = card.ValueHands(nr.PlayerHand);
                        int dealerHand = card.ValueHands(nr.Dealerhand);

                        //if (card.ValueHands(nr.PlayerHand) >= 5 && card.ValueHands(nr.PlayerHand) <= 10)
                        //{
                        //    playerAction = PlayerAction.Double;
                        //    rs.Double = true;
                        //    rs.Bet = rs.Bet + rs.Bet;
                        //}
                        //else if (card.ValueHands(nr.PlayerHand) < 5 && card.ValueHands(nr.Dealerhand) == 11)
                        //    playerAction = PlayerAction.Surrender;
                        //else if (card.ValueHands(nr.PlayerHand) <= 16)
                        //    playerAction = PlayerAction.Hit;
                        //else if (card.ValueHands(nr.PlayerHand) >= 17)
                        //    playerAction = PlayerAction.Stand;
                        //else
                        //    playerAction = PlayerAction.Surrender;

                        if (dealerHand >= 9 && playerHand == 16)
                            playerAction = PlayerAction.Surrender;
                        else if (dealerHand == 10 && playerHand == 15)
                            playerAction = PlayerAction.Surrender;
                        else if (playerHand >= 17 && playerHand <= 21)
                            playerAction = PlayerAction.Stand;
                        else if (playerHand == 16 && dealerHand >= 7 && dealerHand <= 8)
                            playerAction = PlayerAction.Hit;
                        else if (playerHand == 16 && dealerHand >= 2 && dealerHand <= 6)
                            playerAction = PlayerAction.Stand;
                        else if (playerHand == 15 && dealerHand == 11)
                            playerAction = PlayerAction.Hit;
                        else if (playerHand == 15 && dealerHand >= 7 && dealerHand <= 9)
                            playerAction = PlayerAction.Hit;
                        else if (playerHand == 15 && dealerHand >= 2 && dealerHand <= 6)
                            playerAction = PlayerAction.Stand;
                        else if (playerHand >= 12 && playerHand <= 14 && dealerHand >= 7)
                            playerAction = PlayerAction.Hit;
                        else if (playerHand >= 13 && playerHand <= 14 && dealerHand >= 2 && dealerHand <= 6)
                            playerAction = PlayerAction.Stand;
                        else if (playerHand == 12 && dealerHand >= 4 && dealerHand <= 6)
                            playerAction = PlayerAction.Stand;
                        else if (playerHand == 12 && dealerHand >= 2 && dealerHand <= 3)
                            playerAction = PlayerAction.Hit;
                        else if (playerHand == 11 && dealerHand == 11)
                            playerAction = PlayerAction.Hit;
                        else if (playerHand == 11)
                        {
                            if (nr.PlayerCredits >= 10)
                            {
                                playerAction = PlayerAction.Double;
                                rs.Double = true;
                                rs.Bet = rs.Bet + rs.Bet;
                            }
                            else
                                playerAction = PlayerAction.Hit;
                        }
                        else if (playerHand == 10 && dealerHand >= 10)
                            playerAction = PlayerAction.Hit;
                        else if (playerHand == 10)
                        {
                            if (nr.PlayerCredits >= 10)
                            {
                                playerAction = PlayerAction.Double;
                                rs.Double = true;
                                rs.Bet = rs.Bet + rs.Bet;
                            }
                            else
                                playerAction = PlayerAction.Hit;
                        }
                        else if (playerHand == 9 && dealerHand >= 7)
                            playerAction = PlayerAction.Hit;
                        else if (playerHand == 9 && dealerHand >= 3)
                        {
                            if (nr.PlayerCredits >= 10)
                            {
                                playerAction = PlayerAction.Double;
                                rs.Double = true;
                                rs.Bet = rs.Bet + rs.Bet;
                            }
                            else
                                playerAction = PlayerAction.Hit;
                        }
                        else if (playerHand == 9)
                            playerAction = PlayerAction.Hit;
                        else
                            playerAction = PlayerAction.Hit;

                        PlayApiRequest req = new PlayApiRequest(nr.GameId, (int)playerAction, initialBet);
                        response = client.PostAsJsonAsync("/api/Play", req).Result;
                        if (!response.IsSuccessStatusCode)
                        {
                            return View("Index");
                        }

                        nr = response.Content.ReadAsAsync<PlayApiResponse>().Result;

                        if (playerAction == PlayerAction.Double)
                            rs.Bet = rs.Bet + rs.Bet;
                        else
                            rs.Bet = initialBet;

                        if (card.ValueHands(nr.Dealerhand) == 21 && nr.Dealerhand.Count == 2)
                            rs.DealerBlackjack = true;
                        else
                            rs.DealerBlackjack = false;
                    }

                    rs.RoundResult = nr.RoundFinalResult;
                    rs.FinalCredits = nr.PlayerCredits;
                    Repository.AddRound(rs);
                }

                path = "/api/Play/rGAUUmCfk3vUgfSF/" + nr.GameId;
                HttpResponseMessage resp = client.GetAsync(path).Result;
                if (!resp.IsSuccessStatusCode)
                {
                    return View("Index");
                }
                nr = resp.Content.ReadAsAsync<PlayApiResponse>().Result;

                path = "/api/Quit";
                QuitApiRequest reqq = new QuitApiRequest(nr.GameId);
                response = client.PostAsJsonAsync(path, reqq).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return View("Index");
                }

                List<RoundSummary> rounds = Repository.Rounds;

                GameSummary g = new GameSummary();
                g.Rounds = nr.RoundCount;
                g.Credits = nr.PlayerCredits;
                foreach (RoundSummary r in rounds)
                {
                    g.AvgBet = r.Bet + g.AvgBet;
                    if (r.Bet > g.MaxBet)
                        g.MaxBet = r.Bet;
                    if (r.Bet < g.MinBet)
                        g.MinBet = r.Bet;
                    else
                        g.MinBet = 10;
                    if (r.RoundResult == (int)RoundResult.BlackJack)
                        g.PlayerBlackjack = g.PlayerBlackjack + 1;
                    if (r.DealerBlackjack == true)
                        g.DealerBlackjack = g.DealerBlackjack + 1;
                }
                g.AvgBet = g.AvgBet / rounds.Count();

                ViewBag.Game = g;

                return View("Result", rounds);
            }
            else
                return View();
        }




        //xxxxx


    }
}


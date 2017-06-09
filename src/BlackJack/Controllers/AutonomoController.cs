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

                    if (nr.PlayerCredits > 200)
                        rs.Bet = 50;
                    else if (nr.PlayerCredits > 100)
                        rs.Bet = 25;
                    else if (nr.PlayerCredits >= 10)
                        rs.Bet = 10;                    

                    rs.InitialCredits = nr.PlayerCredits;

                    PlayApiRequest rq = new PlayApiRequest(nr.GameId, (int)PlayerAction.NewRound, rs.Bet);
                    response = client.PostAsJsonAsync("/api/Play", rq).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        return View("Index");
                    }

                    nr = response.Content.ReadAsAsync<PlayApiResponse>().Result;

                    rs.Rounds = nr.RoundCount + 1;

                    if (nr.RoundFinalResult == (int)RoundFinalResult.BlackJack)
                        rs.Blackjack = true;
                    else
                        rs.Blackjack = false;
                    
                    //Jogadas
                    while (nr.PlayingRound == true)
                    {
                        PlayerAction playerAction;

                        CardMethods card = new CardMethods();

                        if (card.ValueHands(nr.PlayerHand) >= 5 && card.ValueHands(nr.PlayerHand) <= 10 && nr.PlayerCredits >= rs.Bet)
                        {
                            playerAction = PlayerAction.Double;
                            rs.Double = true;
                            rs.Bet = rs.Bet + rs.Bet;
                        }
                        else if (card.ValueHands(nr.PlayerHand) < 5 && card.ValueHands(nr.Dealerhand) == 11 && nr.PlayerCredits >= 30)
                            playerAction = PlayerAction.Surrender;
                        else if (card.ValueHands(nr.PlayerHand) <= 18)
                            playerAction = PlayerAction.Hit;
                        else if (card.ValueHands(nr.PlayerHand) >= 19)
                            playerAction = PlayerAction.Stand;
                        else
                            playerAction = PlayerAction.Surrender;


                        PlayApiRequest req = new PlayApiRequest(nr.GameId, (int)playerAction, rs.Bet);
                        response = client.PostAsJsonAsync("/api/Play", req).Result;
                        if (!response.IsSuccessStatusCode)
                        {
                            return View("Index");
                        }

                        nr = response.Content.ReadAsAsync<PlayApiResponse>().Result;

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


                return View("Result", rounds);
            }
            else
                return View();
        }
    }
}


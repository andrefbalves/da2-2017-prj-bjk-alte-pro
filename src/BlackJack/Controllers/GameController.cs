using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackJack.Models;

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
        public IActionResult Index(Player novoJogador)
        {
            if (ModelState.IsValid)
            {
                Game novojogo = new Game(novoJogador.Nome);
                return View("PlayGame", novojogo);
            }
            else
                return View();
        }

        [HttpPost]
        public IActionResult PlayGame(Game  novojogo)
        {
            novojogo.EmRonda = true;
            return View(novojogo);
        }


    }
}

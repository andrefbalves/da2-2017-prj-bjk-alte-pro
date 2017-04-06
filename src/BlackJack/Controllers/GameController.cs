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
                return View("Game", novoJogador);
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult Game()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Game(Player novojogo) //perguntar ao stor se pode ser assim!!!
        {   
            novojogo.Ronda = true;
            return View(novojogo);
        }


    }
}

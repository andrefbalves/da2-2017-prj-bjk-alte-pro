using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.Models;


namespace BlackJack.Controllers
{
    [Route("api/[controller]")]
    public class HiScoresController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] HiScores p)
        {
            HiScores hs = new HiScores();
            
            //foreach (Game high in Repository.Games.Take(hs.Id))
            {
                //if (hs.PlayerName == high.PlayerName)
                    //return high;
            }
            int x;
            if (hs.Bool == true)
                x = hs.Id;

            else
                x = 3;
            
            return  Ok(Repository.HiScores(p));
            
        }
    }
}

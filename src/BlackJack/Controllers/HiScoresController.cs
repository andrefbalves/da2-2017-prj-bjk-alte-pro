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
           return  Ok(Repository.HiScores(p));
            
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.Models;

namespace BlackJack.Controllers
{
    [Route("api/controller]")]
    public class WebApiController : Controller
    {

        [HttpGet]
        public IEnumerable<TeamMember> Get()
        {
            return new TeamMember [] { Repository.Identificacao.ToList };
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }






    }

}

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
    public List<TeamMember> Get()
        {
            return Repository.identificacao;
        }
        
    }
}

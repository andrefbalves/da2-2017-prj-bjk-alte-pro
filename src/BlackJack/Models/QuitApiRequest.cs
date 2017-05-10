using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class QuitApiRequest
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public QuitApiRequest(int id)
        {
            Id = id;
            Key = "rGAUUmCfk3vUgfSF";
        }
    }
}

using FinBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinBet_Web_API.Dtos
{
    public class LexiconDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Rating { get; set; }
    }
}

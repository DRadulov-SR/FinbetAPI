using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinBet.Models
{
    public class Lexicon
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Rating { get; set; }

    }
}

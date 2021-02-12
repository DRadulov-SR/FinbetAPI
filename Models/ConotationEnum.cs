using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinBet.Models
{
    public enum ConotationEnum
    {
        [Display(Name = "Negative")]
        Negative,

        [Display(Name = "Neutral")]
        Neutral,

        [Display(Name = "Positive")]
        Positive
        
        
    }
}

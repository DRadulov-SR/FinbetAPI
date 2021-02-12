using AutoMapper;
using FinBet.Models;
using FinBet_Web_API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinBet_Web_API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Lexicon, LexiconDto>();
            CreateMap<AddLexiconDto, Lexicon>();
        }
    }
}

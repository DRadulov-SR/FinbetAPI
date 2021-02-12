using FinBet.Models;
using FinBet_Web_API.Dtos;
using FinBet_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinBet_Web_API.Services
{
    public interface ILexiconService
    {
        Task<ServiceResponse<List<LexiconDto>>> GetLexicons();
        Task<ServiceResponse<LexiconDto>> GetLexiconById(int id);
        Task<ServiceResponse<List<LexiconDto>>> AddLexicon(AddLexiconDto lexicon);
        Task<ServiceResponse<LexiconDto>> UpdateLexicon(LexiconDto updateLexicon);

        Task<ServiceResponse<List<LexiconDto>>> DeleteLexicon(int id);

        Task<List<EnumValue>> GetConotations();
    }
}

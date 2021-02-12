using AutoMapper;
using FinBet.Models;
using FinBet_Web_API.Data;
using FinBet_Web_API.Dtos;
using FinBet_Web_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinBet_Web_API.Services
{
    public class LexiconService : ILexiconService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        List<Lexicon> lexicons = new List<Lexicon>();

        public LexiconService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        
        public async Task<List<EnumValue>> GetConotations()
        {
            return EnumExtensions.GetValues<ConotationEnum>();
        }

        public async Task<ServiceResponse<List<LexiconDto>>> AddLexicon(AddLexiconDto addedLexicon)
        {
            ServiceResponse<List<LexiconDto>> serviceResponse = new ServiceResponse<List<LexiconDto>>();
           
            if(_dataContext.Lexicons.Any(l => l.Name.ToLower().Equals(addedLexicon.Name.ToLower())))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Name already exists!!!";
                return serviceResponse;
            }
            Lexicon lexicon = _mapper.Map<Lexicon>(addedLexicon);
         
            await _dataContext.Lexicons.AddAsync(lexicon);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = (_dataContext.Lexicons.Select(l => _mapper.Map<LexiconDto>(l))).ToList();
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<LexiconDto>>> DeleteLexicon(int id)
        {
            ServiceResponse<List<LexiconDto>> serviceResponse = new ServiceResponse<List<LexiconDto>>();
            try
            {
                Lexicon lexicon = await _dataContext.Lexicons.FirstOrDefaultAsync(l => l.Id == id);
                _dataContext.Lexicons.Remove(lexicon);
                await _dataContext.SaveChangesAsync();

                serviceResponse.Data = (_dataContext.Lexicons.Select(l => _mapper.Map<LexiconDto>(l))).ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<LexiconDto>> GetLexiconById(int id)
        {
            ServiceResponse<LexiconDto> serviceResponse = new ServiceResponse<LexiconDto>();
            Lexicon lexicon = await _dataContext.Lexicons.FirstOrDefaultAsync(l => l.Id == id);
            serviceResponse.Data = _mapper.Map<LexiconDto>(lexicon);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<LexiconDto>>> GetLexicons()
        {
            ServiceResponse<List<LexiconDto>> serviceResponse = new ServiceResponse<List<LexiconDto>>();
            List<Lexicon> dbLexicon = await _dataContext.Lexicons.ToListAsync();
            serviceResponse.Data = (dbLexicon.Select(l => _mapper.Map<LexiconDto>(l))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<LexiconDto>> UpdateLexicon(LexiconDto updateLexicon)
        {
            ServiceResponse<LexiconDto> serviceResponse = new ServiceResponse<LexiconDto>();
            try
            {   
                Lexicon lexicon = await _dataContext.Lexicons.FirstOrDefaultAsync(l => l.Id == updateLexicon.Id);
                lexicon.Name = updateLexicon.Name;
                lexicon.Rating = updateLexicon.Rating;
                _dataContext.Lexicons.Update(lexicon);
                await _dataContext.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<LexiconDto>(lexicon);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;
        }
    }
}

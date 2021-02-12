using FinBet.Models;
using FinBet_Web_API.Dtos;
using FinBet_Web_API.Models;
using FinBet_Web_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinBet_Web_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LexiconController : ControllerBase
    {
        private readonly ILexiconService _lexiconService;

        public LexiconController(ILexiconService lexiconService)
        {
            this._lexiconService = lexiconService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetLexicons()
        {
            
            return Ok(await _lexiconService.GetLexicons());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLexicon(int id)
        {
            return Ok(await _lexiconService.GetLexiconById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddLexicon(AddLexiconDto newLexicon)
        {
            ServiceResponse<List<LexiconDto>> serviceResponse = await _lexiconService.AddLexicon(newLexicon);
            if (serviceResponse.Data == null)
            {
                return BadRequest(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLexicon(LexiconDto updateLexicon)
        {
            ServiceResponse<LexiconDto> response = await _lexiconService.UpdateLexicon(updateLexicon);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLexicon(int id)
        {
            ServiceResponse<List<LexiconDto>> response = await _lexiconService.DeleteLexicon(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetConotations")]
        public async Task<List<EnumValue>> GetConotations()
        {
            return await _lexiconService.GetConotations();
        }
    }
}

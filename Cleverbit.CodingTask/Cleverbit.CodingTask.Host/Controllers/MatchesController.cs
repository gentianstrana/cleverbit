using Cleverbit.CodingTask.Host.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MatchesController : ControllerBase
    {
        public MatchesController(IMatchService matchService)
        {
            MatchService = matchService;
        }

        private IMatchService MatchService { get; }

        [HttpGet("played")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPlaydMatches()
        {
            var matches = await MatchService.GetPlayedMatches();
            return Ok(matches);
        }

        [HttpPost("{matchId}/play-now")]
        public async Task<IActionResult> PlayNow([Range(1, Int32.MaxValue)] int matchId)
        {
            var match = await MatchService.PlayNow(matchId, Int32.Parse(User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value));
            return Ok(match);
        }
    }
}

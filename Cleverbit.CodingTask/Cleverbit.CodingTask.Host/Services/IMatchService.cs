using Cleverbit.CodingTask.Host.DTO.Match;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Services
{
    public interface IMatchService
    {
        Task<MatchListDto> PlayNow(int matchId, int userId);
        Task<List<MatchListDto>> GetPlayedMatches();
    }
}

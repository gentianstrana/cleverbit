using AutoMapper;
using Cleverbit.CodingTask.Data;
using Cleverbit.CodingTask.Data.Models;
using Cleverbit.CodingTask.Host.DTO.Match;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Services.Implementations
{
    public class MatchService : IMatchService
    {
        public MatchService(CodingTaskContext context,
            IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        private CodingTaskContext Context { get; }
        private IMapper Mapper { get; }

        public async Task<MatchListDto> PlayNow(int matchId, int userId)
        {
            Random rand = new Random();
            int number = rand.Next(0, 101);
            var match = Context.Matches.FirstOrDefault(m => m.Id == matchId && (m.PlayerOneId == userId || m.PlayerTwoId == userId) && m.ExpireTimeStamp > DateTime.Now);

            if(match != null)
            {
                if(match.PlayerOneId == userId && match.ScoreOne == null)
                {
                    match.ScoreOne = number;
                }
                else if(match.PlayerTwoId == userId && match.ScoreTwo == null)
                {
                    match.ScoreTwo = number;
                }

                Context.Update(match);
                await Context.SaveChangesAsync();
                return Mapper.Map<MatchListDto>(match);
            }
            return null;
        }

        public async Task<List<MatchListDto>> GetPlayedMatches()
        {
            var matches = await Context.Matches.Where(m => m.ExpireTimeStamp < DateTime.Now)
                .Include(m => m.PlayerOne)
                .Include(m => m.PlayerTwo)
                .ToListAsync();
            return Mapper.Map<List<MatchListDto>>(matches);
        }
    }
}

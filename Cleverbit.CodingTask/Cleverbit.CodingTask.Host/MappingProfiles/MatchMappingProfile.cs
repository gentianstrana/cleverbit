using AutoMapper;
using Cleverbit.CodingTask.Data.Models;
using Cleverbit.CodingTask.Host.DTO.Match;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.MappingProfiles
{
    public class MatchMappingProfile : Profile
    {
        public MatchMappingProfile()
        {
            CreateMap<Match, MatchListDto>()
                .ForMember(dest => dest.Winner, 
                    src => src.MapFrom(m => m.ExpireTimeStamp < DateTime.Now ? ((m.ScoreOne ?? 0) > (m.ScoreTwo ?? 0) ? m.PlayerOne : m.PlayerTwo) : null));
        }
    }
}

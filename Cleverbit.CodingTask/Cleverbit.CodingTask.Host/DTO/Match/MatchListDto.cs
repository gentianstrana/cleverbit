using Cleverbit.CodingTask.Host.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.DTO.Match
{
    public class MatchListDto
    {
        public int Id { get; set; }
        public string MatchName { get; set; }
        public int? ScoreOne { get; set; }
        public int? ScoreTwo { get; set; }
        public DateTime ExpireTimeStamp { get; set; }

        public virtual UserListDto PlayerOne { get; set; }
        public virtual UserListDto PlayerTwo { get; set; }
        public virtual UserListDto Winner { get; set; }
    }
}

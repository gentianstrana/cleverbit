using System;
using System.Collections.Generic;
using System.Text;

namespace Cleverbit.CodingTask.Data.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string MatchName { get; set; }
        public int PlayerOneId { get; set; }
        public int PlayerTwoId { get; set; }
        public int? ScoreOne { get; set; }
        public int? ScoreTwo { get; set; }
        public DateTime ExpireTimeStamp { get; set; }

        public virtual User PlayerOne { get; set; }
        public virtual User PlayerTwo { get; set; }
    }
}

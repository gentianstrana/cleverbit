using System.Collections;
using System.Collections.Generic;

namespace Cleverbit.CodingTask.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual IEnumerable<Match> MatchesAsPlayerOne  { get; set; }
        public virtual IEnumerable<Match> MatchesAsPlayerTwo { get; set; }
    }
}

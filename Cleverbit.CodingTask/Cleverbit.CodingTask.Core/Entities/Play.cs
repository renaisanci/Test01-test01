using System;
using System.Collections.Generic;
using System.Text;

namespace Cleverbit.CodingTask.Core.Entities
{
    public class Play
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public Guid MatchId { get; set; } 
        public int Score { get; set; }
        public long DateTimestamp { get; set; }


    }
}

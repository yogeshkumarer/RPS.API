using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPS.Api.Enums;

namespace RPS.Api.Model
{
    public class GameModel
    {
        public Guid Id { get; set; }

        public Outcome Outcome { get; set; }

        public int NumOfTurns { get; set; }

        public int NumOfDynamites { get; set; }
    }
}

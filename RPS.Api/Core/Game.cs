using System;
using RPS.Api.Enums;
using RPS.Api.ExceptionHandling;

namespace RPS.Api.Core
{
    public class Game
    {
        public Game(IRPSPlayer firstPlayer, IRPSPlayer secondPlayer)
        {
            if(firstPlayer == null || secondPlayer == null)
            {
                throw new GameCreationFailureException();
            }

            this.Id = Guid.NewGuid();
            this.FirstPlayer = firstPlayer;
            this.SecondPlayer = secondPlayer;
        }

        public Guid Id { get; set; }

        public IRPSPlayer FirstPlayer { get; set; }

        public IRPSPlayer SecondPlayer { get; set; }

        public Outcome Outcome { get; set; }

        public int NumOfTurns { get; set; }

        public int NumOfDynamites { get; set; }

        public int FirstPlayerWinCount { get; set; }

        public int SecondPlayerWinCount { get; set; }
    }
}

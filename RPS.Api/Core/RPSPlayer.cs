using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPS.Api.Enums;

namespace RPS.Api.Core
{
    public class RPSPlayer : IRPSPlayer
    {
        private readonly IGameService gameService;

        public Guid PlayerId { get; set; }

        public bool IsDefault { get; set; }

        public Move CurrentMove { get; set; }

        public RPSPlayer(IGameService gameService)
        {
            this.gameService = gameService;
        }        

        public Game GetReady(int numGames, int numDynamite)
        {
            this.PlayerId = Guid.NewGuid();

            return this.gameService.CreateGame(this, CreateDefaultPlayer(), numGames, numDynamite);
        }

        public Outcome GameResult(Guid gameId, Move opponentMove)
        {
            this.CurrentMove = opponentMove;
            return this.gameService.BattleResult(gameId);
        }

        public Move MakeMove(Guid gameId)
        {
            if (this.IsDefault)
            {
                this.CurrentMove = this.gameService.GetRandomMove(gameId);
            }
            else
            {
                this.CurrentMove = Move.Rock;
            }

            return this.CurrentMove;
        }

        public string Result(Guid gameId)
        {
            var finalOutcome = this.gameService.FindFinalOutcome(gameId);
            var result = string.Empty;
            switch(finalOutcome)
            {
                case Outcome.Win:
                    result = "Hurray!! You won the game";
                    break;
                case Outcome.Lose:
                    result = "You lost the game this time. Better luck next time.";
                    break;
                case Outcome.Draw:
                    result = "Match tied! Well played.";
                    break;
            }

            return result;
        }

        private IRPSPlayer CreateDefaultPlayer()
        {
            var defaultPlayer = new RPSPlayer(this.gameService)
            {
                PlayerId = Guid.NewGuid(),
                IsDefault = true
            };
            return defaultPlayer;
        }
    }
}

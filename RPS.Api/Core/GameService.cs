using System;
using System.Collections.Generic;
using System.Linq;
using RPS.Api.Core;
using RPS.Api.Enums;

namespace RPS.Api.Core
{
    public class GameService : IGameService
    {
        private static Random randomGen = new Random();

        private readonly IList<Game> games;

        public GameService()
        {
            this.games = new List<Game>();
        }

        public Game CreateGame(IRPSPlayer player1, IRPSPlayer player2, int numGames, int numDynamite)
        {
            var currentGame = new Game(player1, player2) { NumOfTurns = numGames, NumOfDynamites = numDynamite };
            var existingGame = this.games.FirstOrDefault(g => g.Id == currentGame.Id);
            if (existingGame == null)
            {
                this.games.Add(currentGame);
                return currentGame;
            }

            return existingGame;
        }

        public Game GetGameInfo(Guid gameId)
        {
            return this.games.FirstOrDefault(g => g.Id == gameId);
        }

        public void ReduceGameTurn(Guid gameId)
        {
            var existingGame = this.games.FirstOrDefault(g => g.Id == gameId);
            if (existingGame != null)
            {
                existingGame.NumOfTurns--;
            }
        }

        public Move GetRandomMove(Guid gameId)
        {
            var existingGame = this.games.FirstOrDefault(g => g.Id == gameId);
            if (existingGame != null)
            {
                switch (existingGame.NumOfDynamites)
                {
                    case 2:
                        var arrayWith2 = new[] { Move.Rock, Move.Paper };
                        return (Move)arrayWith2.GetValue(randomGen.Next(arrayWith2.Length));
                    case 3:
                        var arrayWith3 = new[] { Move.Rock, Move.Paper, Move.Scissors };
                        return (Move)arrayWith3.GetValue(randomGen.Next(arrayWith3.Length));
                    case 4:
                        var arrayWith4 = new[] { Move.Rock, Move.Paper, Move.Scissors };
                        return (Move)arrayWith4.GetValue(randomGen.Next(arrayWith4.Length));
                    case 5:
                        var array = Enum.GetValues(typeof(Move));
                        return (Move)array.GetValue(randomGen.Next(array.Length));
                    default:
                        return Move.Rock;
                }
            }

            return Move.Rock;
        }

        public Outcome BattleResult(Guid gameId)
        {
            var existingGame = this.games.FirstOrDefault(g => g.Id == gameId);
            if (existingGame != null && existingGame.FirstPlayer != null && existingGame.SecondPlayer != null)
            {
                Move secondPlayerMove = existingGame.SecondPlayer.CurrentMove;

                switch (existingGame.FirstPlayer.CurrentMove)
                {
                    case Move.Paper when secondPlayerMove == Move.Rock:
                    case Move.Scissors when secondPlayerMove == Move.Paper:
                    case Move.Rock when secondPlayerMove == Move.Scissors:
                    case Move.Dynamite when (secondPlayerMove == Move.Rock || secondPlayerMove == Move.Paper || secondPlayerMove == Move.Scissors):
                    case Move.Warterbomb when secondPlayerMove == Move.Dynamite:
                        existingGame.FirstPlayerWinCount++;
                        return Outcome.Win;
                    case Move.Paper when secondPlayerMove == Move.Scissors:
                    case Move.Scissors when secondPlayerMove == Move.Rock:
                    case Move.Rock when secondPlayerMove == Move.Paper:
                    case Move.Dynamite when secondPlayerMove == Move.Warterbomb:
                    case Move.Warterbomb when (secondPlayerMove == Move.Rock || secondPlayerMove == Move.Paper || secondPlayerMove == Move.Scissors):
                        existingGame.SecondPlayerWinCount++;
                        return Outcome.Lose;
                    default:
                        return Outcome.Draw;
                }
            }

            return Outcome.Draw;
        }

        public Outcome FindFinalOutcome(Guid gameId)
        {
            var existingGame = this.games.FirstOrDefault(g => g.Id == gameId);
            if (existingGame != null && existingGame.FirstPlayer != null && existingGame.SecondPlayer != null)
            {
                return existingGame.FirstPlayerWinCount > existingGame.SecondPlayerWinCount ? Outcome.Win :
                    existingGame.SecondPlayerWinCount > existingGame.FirstPlayerWinCount ? Outcome.Lose :
                    Outcome.Draw;
            }

            return Outcome.Draw;
        }
    }
}

using System;
using RPS.Api.Enums;
using RPS.Api.Model;

namespace RPS.Api.BL
{
    public interface IRpsBusinessLayer
    {
        GameModel CreateGame(int numGames, int numDynamite = 3);
        Outcome GameResult(Guid gameId, Move opponentMove);
        Move MakeMove(Guid gameId);
        string Result(Guid gameId);
    }
}
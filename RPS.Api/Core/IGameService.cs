using System;
using RPS.Api.Core;
using RPS.Api.Enums;

namespace RPS.Api.Core
{
    public interface IGameService
    {
        Game CreateGame(IRPSPlayer player1, IRPSPlayer player2, int numGames, int numDynamite);

        Game GetGameInfo(Guid gameId);

        Move GetRandomMove(Guid gameId);

        Outcome BattleResult(Guid gameId);

        Outcome FindFinalOutcome(Guid gameId);
    }
}
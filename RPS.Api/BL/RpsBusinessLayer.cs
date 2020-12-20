using System;
using AutoMapper;
using RPS.Api.Core;
using RPS.Api.Enums;
using RPS.Api.Model;

namespace RPS.Api.BL
{
    public class RpsBusinessLayer : IRpsBusinessLayer
    {
        private readonly IRPSPlayer player;

        private readonly IGameService gameService;

        private readonly IMapper mapper;

        public RpsBusinessLayer(IMapper mapper, IRPSPlayer player, IGameService gameService)
        {
            this.mapper = mapper;
            this.player = player;
            this.gameService = gameService;
        }

        public GameModel CreateGame(int numGames, int numDynamite = 3)
        {
            var game = this.player.GetReady(numGames, numDynamite);
            return this.mapper.Map<GameModel>(game);
        }

        public Move MakeMove(Guid gameId)
        {
            var game = this.gameService.GetGameInfo(gameId);
            if (game != null && game.SecondPlayer != null)
            {
                return game.SecondPlayer.MakeMove(gameId);
            }

            return Move.Rock;
        }

        public Outcome GameResult(Guid gameId, Move opponentMove)
        {
            return this.player.GameResult(gameId, opponentMove);
        }

        public string Result(Guid gameId)
        {
            return this.player.Result(gameId);
        }
    }
}

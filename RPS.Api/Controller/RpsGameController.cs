using System;
using Microsoft.AspNetCore.Mvc;
using RPS.Api.BL;
using RPS.Api.Enums;
using RPS.Api.Model;

namespace RPS.Api.Controller
{
    [ApiController]
    public class RpsGameController : ControllerBase
    {
        private readonly IRpsBusinessLayer rpsBusinessLayer;

        public RpsGameController(IRpsBusinessLayer rpsBusinessLayer)
        {
            this.rpsBusinessLayer = rpsBusinessLayer;
        }

        [HttpPost]
        [Route("api/[controller]/NewGame/{numGames}/{numDynamite}")]
        public GameModel CreateGame(int numGames, int numDynamite = 3)
        {
            return this.rpsBusinessLayer.CreateGame(numGames, numDynamite);
        }

        [HttpGet]
        [Route("api/[controller]/MakeMove")]
        public Move MakeMove(Guid gameId)
        {
            return this.rpsBusinessLayer.MakeMove(gameId);
        }

        [HttpPut]
        [Route("api/[controller]/GameResult/{gameId}/{opponentMove}")]
        public Outcome GameResult(Guid gameId, Move opponentMove)
        {
            return this.rpsBusinessLayer.GameResult(gameId, opponentMove);
        }

        [HttpGet]
        [Route("api/[controller]/Result/{gameId}")]
        public string Result(Guid gameId)
        {
            return this.rpsBusinessLayer.Result(gameId);
        }
    }
}

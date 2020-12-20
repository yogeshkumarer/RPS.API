using System;
using RPS.Api.Enums;

namespace RPS.Api.Core
{
    // For a match the sequence will follow the pattern
    // GetReady(); to set parameters for the match such as how many games will be played
    // Foreach game the next two methods will be call in turn
    //  MakeMove(); your turn
    //  GameResult(); result of the game including what my move was
    // End of foreach game
    // Result(); to give final result for match
    public interface IRPSPlayer
    {
        Guid PlayerId { get; }

        bool IsDefault { get; }

        Move CurrentMove { get; }

        //get ready to play numGames games and in each game you will have numDynamite dynamites
        //return any comments you want to make to your opponent
        Game GetReady(int numGames, int numDynamite);

        //return the move you want to make for this game
        Move MakeMove(Guid gameId);

        //result of the current game along with opponents move
        Outcome GameResult(Guid gameId, Move opponentMove);

        //result of all of the games
        //return any comment you want to make about the outcome
        string Result(Guid gameId);
    }
}

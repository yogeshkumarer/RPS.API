using System;

namespace RPS.Api.ExceptionHandling
{
    public class GameCreationFailureException : Exception
    {
        public GameCreationFailureException() : base("Unable to create the game as the first player doest not exist")
        {
        }

        public GameCreationFailureException(string message) : base(message)
        {
        }
    }
}

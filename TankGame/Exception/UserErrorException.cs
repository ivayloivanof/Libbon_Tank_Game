namespace TankGame.Exception
{
    using System;

    public class UserErrorException : Exception
    {
        public UserErrorException(string message) : base(message)
        {
        }
    }
}

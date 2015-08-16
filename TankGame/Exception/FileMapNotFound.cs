namespace TankGame.Exception
{
    using System;

    public class FileMapNotFound : Exception
    {
        public FileMapNotFound(string message) : base(message)
        {
        }
    }
}

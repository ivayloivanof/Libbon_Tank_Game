namespace TankGame
{
    using System;

    using Exception;

    public class Engine
    {
        private Player playerOne;
        private Player playerTwo;
        private MapFile map;

        public Engine()
        {
        }

        public Player PlayerOne
        {
            get
            {
                return this.playerOne;
            }

            private set
            {
                this.playerOne = new Player(value.ToString(), 1);
            }
        }

        public Player PlayerTwo
        {
            get
            {
                return this.playerTwo;
            }

            private set
            {
                this.playerTwo = new Player(value.ToString(), 2);
            }
        }

        public MapFile Map
        {
            get
            {
                return this.map;
            }

            set
            {
                this.map = new MapFile(value.ToString());
            }
        }

        public void SetPlayers(string nameOne, string nameTwo)
        {
            try
            {
                this.PlayerOne = new Player(nameOne, 1);
                this.PlayerTwo = new Player(nameTwo, 1);
            }
            catch (UserErrorException userError)
            {
                Console.WriteLine(userError.Message);
            }
        }

    }
}

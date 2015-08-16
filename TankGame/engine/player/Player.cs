namespace TankGame
{
    using System.Text;

    using TankGame.Exception;

    public class Player
    {
        private string name;
        private int playerID;
        private int tanksLost;
        private GameConstants gameConstants = new GameConstants();
        
        public Player(string name, int i)
        {
            this.Name = name;
            this.PlayerID = i;
            this.TanksLost = 0;
        }

        // Property for name
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new UserErrorException("Name of this user cannot be empty!");
                }

                this.name = value;
            }
        }
        
        public int PlayerID
        {
            get
            {
                return this.playerID;
            }

            set
            {
                // TODO Validation
                this.playerID = value;
            }
        }
        
        public int TanksLost
        {
            get
            {
                return this.tanksLost;
            }

            set
            {
                // TODO Validation
                this.tanksLost = value;
            }
        }

        // Method to track tanks lost
        public void LostTank()
        {
            this.TanksLost++; // Decrements tanks
        }

        // Method to tell if player has lost
        public bool GameLost()
        {
            return this.TanksLost >= this.gameConstants.MaxLives;
        }

        // toString
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Name: ");
            stringBuilder.Append(this.Name);
            stringBuilder.Append(" Id: ");
            stringBuilder.Append(this.PlayerID);
            stringBuilder.Append(" Tanks Lost: ");
            stringBuilder.Append(this.TanksLost);

            return stringBuilder.ToString();
        }
    }
}

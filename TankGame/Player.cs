namespace TankGame
{
    using System.Text;

    public class Player
    {
        private string charName;
        private int playerID;
        private int tanksLost;
        private GameConstants gc = new GameConstants();
        
        public Player(string name, int i)
        {
            this.CharName = name;
            this.PlayerID = i;
            this.TanksLost = 0;
        }

        // Property for charName
        public string CharName
        {
            get
            {
                return this.charName;
            }

            set
            {
                // TODO Validation
                this.charName = value;
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
            return this.TanksLost >= this.gc.MaxLives;
        }

        // toString
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Name: ");
            stringBuilder.Append(this.CharName);
            stringBuilder.Append(" Id: ");
            stringBuilder.Append(this.PlayerID);
            stringBuilder.Append(" Tanks Lost: ");
            stringBuilder.Append(this.TanksLost);

            return stringBuilder.ToString();
        }
    }
}

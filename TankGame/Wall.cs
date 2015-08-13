namespace TankGame
{
    using System.Text;

    public class Wall
    {
        private int vertical;
        private int horizontal;
        
        public Wall(int h, int v)
        {
            this.Horizontal = h;
            this.Vertical = v;
        }

        // Property for vertical position
        public int Vertical
        {
            get
            {
                return this.vertical;
            }

            set
            {
                // TODO Validation
                this.vertical = value;
            }
        }

        // Property for horizontal position
        public int Horizontal
        {
            get
            {
                return this.horizontal;
            }

            set
            {
                // TODO Validation
                this.horizontal = value;
            }
        }

        // Override toString
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Wall - Location: ");
            stringBuilder.Append(this.Horizontal);
            stringBuilder.Append(",");
            stringBuilder.Append(this.Vertical);

            return  stringBuilder.ToString();
        }
    }
}

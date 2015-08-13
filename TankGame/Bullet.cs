namespace TankGame
{
    using System.Text;

    public class Bullet
    {
        private GameConstants gc = new GameConstants();

        // Attributes
        private int vertical;
        private int horizontal;
        private int direction;
        private bool isActive;

        // Constructor for bullet
        public Bullet(int h, int v, int d)
        {
            this.vertical = v;
            this.horizontal = h;
            this.direction = d;
            this.isActive = true;
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

        // Property for direction
        public int Direction
        {
            get
            {
                return this.direction;
            }

            set
            {
                // TODO Validation
                this.direction = value;
            }
        }

        // Property for isActive
        public bool IsActive
        {
            get
            {
                return this.isActive;
            }
        }
        
        // Method to Move bullet
        public void Move()
        {
            switch (this.direction)
            {
                case 0: // Bullet moves up
                    this.Vertical -= this.gc.BulletSpeed;
                    break;
                case 1: // Bullet moves right
                    this.Horizontal += this.gc.BulletSpeed;
                    break;
                case 2: // Bullet moves down
                    this.Vertical += this.gc.BulletSpeed;
                    break;
                case 3: // Bullet moves left
                    this.Horizontal -= this.gc.BulletSpeed;
                    break;
            }
        }

        // Override toString
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Bullet - Location: ");
            stringBuilder.Append(this.Horizontal);
            stringBuilder.Append(",");
            stringBuilder.Append(this.Vertical);
            stringBuilder.Append(" Direction: ");
            stringBuilder.Append(this.Direction);
            stringBuilder.Append(" Is Active: ");
            stringBuilder.Append(this.IsActive);

            return stringBuilder.ToString();
        }
    }
}

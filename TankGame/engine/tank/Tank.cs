namespace TankGame
{
    using System;
    using System.Text;

    public class Tank
    {
        private Player owner;
        private int vertical;
        private int horizontal;
        private int direction;
        private int hits;
        private Bullet bullet = null;
        private bool canFire;
        private GameConstants gc = new GameConstants();

        // Constructor to set Tank
        public Tank(Player p, int d, int h, int v)
        {
            this.Owner = p;
            this.Vertical = v;
            this.Horizontal = h;
            this.Direction = d;
            this.CanFire = true;
            this.Hits = 0;
        }

        // Property for owner
        public Player Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                // TODO Validation
                this.owner = value;
            }
        }

        // Property for vertical
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

        // Property for horizontal
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

            // Property for hits
        public int Hits
        {
            get
            {
                return this.hits;
            }

            set
            {
                // TODO Validation
                this.hits = value;
            }
        }

        // Property for canFire
        public bool CanFire
        {
            get
            {
                return this.canFire;
            }

            set
            {
                // TODO Validation
                this.canFire = value;
            }
        }

        // Property for bullet
        public Bullet TankBullet
        {
            get
            {
                return this.bullet;
            }
        }

        // Method to adjust health
        public void TakeHit()
        {
            this.hits++;
        }

        // Method to indicate if tank is dead
        public bool IsDead()
        {
            if (this.hits > 1)
            {
                return true;
            }

            return false;
        }

        // Method to Move tank
        public void Move(ConsoleKeyInfo[] array)
        {
            // Reads each key in array
            for (int i = 0; i < array.Length; i++)
            {
                if (this.owner.PlayerID == 1)
                {
                    // Determines movement and direction of tank
                    switch (array[i].Key)
                    {
                        // Move tank 1 up
                        case ConsoleKey.W:
                            this.vertical -= this.gc.TankSpeed;
                            break;
                        // Move tank 1 right
                        case ConsoleKey.D:
                            this.horizontal += this.gc.TankSpeed;
                            break;
                        // Move tank 1 down
                        case ConsoleKey.S:
                            this.vertical += this.gc.TankSpeed;
                            break;
                        // Move tank 1 left
                        case ConsoleKey.A:
                            this.horizontal -= this.gc.TankSpeed;
                            break;
                        // Fire bullet
                        case ConsoleKey.F:
                            if (this.canFire)
                            {
                                this.bullet = new Bullet(this.vertical + this.gc.BulletWidth, this.horizontal + this.gc.BulletHeight, this.direction);
                            }
                            break;
                    }
                }
                else
                {
                    switch (array[i].Key)
                    {
                        // Move tank 2 up
                        case ConsoleKey.UpArrow:
                            this.vertical -= this.gc.TankSpeed;
                            break;
                        // Move tank 2 right
                        case ConsoleKey.RightArrow:
                            this.horizontal += this.gc.TankSpeed;
                            break;
                        // Move tank 2 down
                        case ConsoleKey.DownArrow:
                            this.vertical += this.gc.TankSpeed;
                            break;
                        // Move tank 2 left
                        case ConsoleKey.LeftArrow:
                            this.horizontal -= this.gc.TankSpeed;
                            break;
                        // Fire bullet
                        case ConsoleKey.OemPeriod:
                            if (this.canFire)
                            {
                                this.bullet = new Bullet(this.horizontal + this.gc.BulletWidth, this.vertical + this.gc.BulletHeight, this.direction);
                            }
                            break;
                    }
                }
            }
        }

        // Override toString
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Tank - Direction: ");
            stringBuilder.Append(this.Direction);
            stringBuilder.Append(" Location: ");
            stringBuilder.Append(this.Horizontal);
            stringBuilder.Append(",");
            stringBuilder.Append(this.Vertical);
            stringBuilder.Append(" Hits: ");
            stringBuilder.Append(this.Hits);
            stringBuilder.Append(" Can Fire: ");
            stringBuilder.Append(this.CanFire);

            return stringBuilder.ToString();
        }
    }
}

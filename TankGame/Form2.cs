namespace TankGame
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Form2 : Form
    {
        // Attributes
        private string playerOneName;
        private string playerTwoName;
        private string mapFile;

        Tank tank1;
        Tank tank2;

        Bullet bull1 = new Bullet(-100, -100, 0);
        Bullet bull2 = new Bullet(-100, -100, 0);

        Button greentank = new Button();
        Button redtank = new Button();

        Button bullet1 = new Button();
        Button bullet2 = new Button();

        Button[] walls = new Button[5];
        Button wall1 = new Button();
        Button wall2 = new Button();
        Button wall3 = new Button();
        Button wall4 = new Button();
        Button wall5 = new Button();

        // Load Bitmap images
        Bitmap bulletimage = new Bitmap("Bullet.png");
        Bitmap wallimage = new Bitmap("Wall.jpg");
        Bitmap redimage0 = new Bitmap("RedTank0.jpg");
        Bitmap redimage1 = new Bitmap("RedTank1.jpg");
        Bitmap redimage2 = new Bitmap("RedTank2.jpg");
        Bitmap redimage3 = new Bitmap("RedTank3.jpg");
        Bitmap greenimage0 = new Bitmap("GreenTank0.jpg");
        Bitmap greenimage1 = new Bitmap("GreenTank1.jpg");
        Bitmap greenimage2 = new Bitmap("GreenTank2.jpg");
        Bitmap greenimage3 = new Bitmap("GreenTank3.jpg");

        public Form2(string playerOne, string playerTwo, string mapFile)
        {
            // Load data from previous form
            this.InitializeComponent();
            this.playerOneName = playerOne;
            this.playerTwoName = playerTwo;
            this.mapFile = mapFile;

            // Load MapFile data
            this.Size = new System.Drawing.Size(800, 600);
            MapFile file = new MapFile("C:\\Users\\Frankie\\Documents\\C#\\TankGame\\" + this.mapFile);
            file.LoadData();

            // Load tanks for MapFile
            this.tank1 = (Tank)file.Tanks[0];
            this.tank2 = (Tank)file.Tanks[1];

            // Create tanks --------------------------------------------------------------------------------

            // Set locations of tanks
            Point point1 = new Point(this.tank1.Horizontal, this.tank1.Vertical);
            this.greentank.Location = point1;
            Point point2 = new Point(this.tank2.Horizontal, this.tank2.Vertical);
            this.redtank.Location = point2;

            // Set sizes of tanks
            this.greentank.Size = new System.Drawing.Size(60, 60);
            this.redtank.Size = new System.Drawing.Size(60, 60);

            // Set image of greentank
            switch (this.tank1.Direction)
            {
                case 0:
                    this.greentank.Image = this.greenimage0;
                    break;
                case 1:
                    this.greentank.Image = this.greenimage1;
                    break;
                case 2:
                    this.greentank.Image = this.greenimage2;
                    break;
                case 3:
                    this.greentank.Image = this.greenimage3;
                    break;
            }

            // Set image of redtank
            switch (this.tank2.Direction)
            {
                case 0:
                    this.redtank.Image = this.redimage0;
                    break;
                case 1:
                    this.redtank.Image = this.redimage1;
                    break;
                case 2:
                    this.redtank.Image = this.redimage2;
                    break;
                case 3:
                    this.redtank.Image = this.redimage3;
                    break;
            }

            // Add tanks to form
            this.Controls.Add(this.greentank);
            this.Refresh();
            this.Controls.Add(this.redtank);
            this.Refresh();

            // Create bullets ------------------------------------------------------------------------------

            // Set locations of bullets
            Point point3 = new Point(-100, -100);
            this.bullet1.Location = point3;
            this.bullet2.Location = point3;

            // Set sizes of bullets
            this.bullet1.Size = new System.Drawing.Size(30, 30);
            this.bullet2.Size = new System.Drawing.Size(30, 30);

            // Set image of bullets
            this.bullet1.Image = this.bulletimage;
            this.bullet2.Image = this.bulletimage;

            // Add bullets to form
            this.Controls.Add(this.bullet1);
            this.Refresh();
            this.Controls.Add(this.bullet2);
            this.Refresh();

            // Create walls --------------------------------------------------------------------------------
            this.walls[0] = this.wall1;
            this.walls[1] = this.wall2;
            this.walls[2] = this.wall3;
            this.walls[3] = this.wall4;
            this.walls[4] = this.wall5;

            // Set wall attributes and load to form
            for (int i = 0; i < 5; i++)
            {
                Wall newWall = (Wall)file.Walls[i];
                Point point4 = new Point(newWall.Horizontal, newWall.Vertical);
                this.walls[i].Location = point4;
                this.walls[i].Size = new System.Drawing.Size(60,60);
                this.walls[i].Image = this.wallimage;
                this.Controls.Add(this.walls[i]);
                this.Refresh();
            }

            this.timer1.Start();
            this.Select();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GameConstants gc = new GameConstants();

            // Get current direction, Move tank
            switch (this.tank1.Direction)
            {
                case 0:     // Move tank up
                    this.greentank.Image = this.greenimage0;
                    if (this.tank2.Vertical >= 0)
                    {
                        this.tank1.Vertical -= gc.TankSpeed;
                        Point pointa = new Point(this.tank1.Horizontal, this.tank1.Vertical);
                        this.greentank.Location = pointa;
                    }
                    else    // Recoil
                    {
                        this.tank1.Direction = 2;
                        this.tank1.Vertical += gc.TankSpeed;
                        Point point3 = new Point(this.tank1.Horizontal, this.tank1.Vertical);
                        this.redtank.Location = point3;
                    }

                    break;
                case 1:     // Move tank right
                    this.greentank.Image = this.greenimage1;
                    if (this.tank1.Horizontal <= gc.GameWidth)
                    {
                        this.tank1.Horizontal += gc.TankSpeed;
                        Point pointb = new Point(this.tank1.Horizontal, this.tank1.Vertical);
                        this.greentank.Location = pointb;
                    }
                    else    // Recoil
                    {
                        this.tank1.Direction = 3;
                        this.tank1.Horizontal -= gc.TankSpeed;
                        Point point3 = new Point(this.tank1.Horizontal, this.tank1.Vertical);
                        this.redtank.Location = point3;
                    }

                    break;
                case 2:     // Move tank down
                    this.greentank.Image = this.greenimage2;
                    if (this.tank1.Vertical <= gc.GameHeight)
                    {
                        this.tank1.Vertical += gc.TankSpeed;
                        Point pointc = new Point(this.tank1.Horizontal, this.tank1.Vertical);
                        this.greentank.Location = pointc;
                    }
                    else    // Recoil
                    {
                        this.tank1.Direction = 0;
                        this.tank1.Vertical -= gc.TankSpeed;
                        Point point3 = new Point(this.tank1.Horizontal, this.tank1.Vertical);
                        this.redtank.Location = point3;
                    }

                    break;
                case 3:     // Move tank left
                    this.greentank.Image = this.greenimage3;
                    if (this.tank1.Horizontal >= 0)
                    {
                        this.tank1.Horizontal -= gc.TankSpeed;
                        Point pointd = new Point(this.tank1.Horizontal, this.tank1.Vertical);
                        this.greentank.Location = pointd;
                    }
                    else    // Recoil
                    {
                        this.tank1.Direction = 1;
                        this.tank1.Horizontal += gc.TankSpeed;
                        Point point3 = new Point(this.tank1.Horizontal, this.tank1.Vertical);
                        this.redtank.Location = point3;
                    }

                    break;
            }

            switch (this.tank2.Direction)
            {
                case 0:     // Move tank up
                    this.redtank.Image = this.redimage0;
                    if (this.tank2.Vertical >= 0)
                    {
                        this.tank2.Vertical -= gc.TankSpeed;
                        Point point1 = new Point(this.tank2.Horizontal, this.tank2.Vertical);
                        Point point1 = new Point(this.tank2.Horizontal, this.tank2.Vertical);
                        this.redtank.Location = point1;
                    }
                    else    // Recoil
                    {
                        this.tank2.Direction = 2;
                        this.tank2.Vertical += gc.TankSpeed;
                        Point point3 = new Point(this.tank2.Horizontal, this.tank2.Vertical);
                        this.redtank.Location = point3;
                    }

                    break;
                case 1:     // Move tank right
                    this.redtank.Image = this.redimage1;
                    if (this.tank2.Horizontal <= gc.GameWidth)
                    {
                        this.tank2.Horizontal += gc.TankSpeed;
                        Point point2 = new Point(this.tank2.Horizontal, this.tank2.Vertical);
                        this.redtank.Location = point2;
                    }
                    else    // Recoil
                    {
                        this.tank2.Direction = 3;
                        this.tank2.Horizontal -= gc.TankSpeed;
                        Point point3 = new Point(this.tank2.Horizontal, this.tank2.Vertical);
                        this.redtank.Location = point3;
                    }

                    break;
                case 2:     // Move tank down
                    this.redtank.Image = this.redimage2;
                    if (this.tank2.Vertical <= gc.GameHeight)
                    {
                        this.tank2.Vertical += gc.TankSpeed;
                        Point point3 = new Point(this.tank2.Horizontal, this.tank2.Vertical);
                        this.redtank.Location = point3;
                    }
                    else    // Recoil
                    {
                        this.tank2.Direction = 0;
                        this.tank2.Vertical -= gc.TankSpeed;
                        Point point3 = new Point(tank2.Horizontal, tank2.Vertical);
                        this.redtank.Location = point3;
                    }

                    break;
                case 3:     // Move tank left
                    this.redtank.Image = this.redimage3;
                    if (this.tank2.Horizontal >= 0)
                    {
                        this.tank2.Horizontal -= gc.TankSpeed;
                        Point point4 = new Point(this.tank2.Horizontal, this.tank2.Vertical);
                        this.redtank.Location = point4;
                    }
                    else    // Recoil
                    {
                        this.tank2.Direction = 1;
                        this.tank2.Horizontal += gc.TankSpeed;
                        Point point3 = new Point(this.tank2.Horizontal, this.tank2.Vertical);
                        this.redtank.Location = point3;
                    }

                    break;
            }

            // Get current direction, Move bullet
            switch (this.bull1.Direction)
            {
                case 0:
                    if (this.bull1.Vertical >= 0)
                    {
                        this.bull1.Vertical -= gc.BulletSpeed;
                        Point point = new Point(this.bull1.Horizontal, this.bull1.Vertical);
                        this.bullet1.Location = point;
                    }
                    else
                    {
                        this.bull1.Vertical = -100;
                        this.bull1.Horizontal = -100;
                        this.bull1.Direction = 0;
                        Point point = new Point(this.bull1.Horizontal, this.bull1.Vertical);
                        this.bullet1.Location = point;
                        this.tank1.CanFire = true;
                    }

                    break;
                case 1:
                    if (this.bull1.Horizontal <= gc.GameWidth)
                    {
                        this.bull1.Horizontal += gc.BulletSpeed;
                        Point point = new Point(this.bull1.Horizontal, this.bull1.Vertical);
                        this.bullet1.Location = point;
                    }
                    else
                    {
                        this.bull1.Vertical = -100;
                        this.bull1.Horizontal = -100;
                        this.bull1.Direction = 0;
                        Point point = new Point(this.bull1.Horizontal, this.bull1.Vertical);
                        this.bullet1.Location = point;
                        this.tank1.CanFire = true;
                    }

                    break;
                case 2:
                    if (this.bull1.Vertical <= gc.GameHeight)
                    {
                        this.bull1.Vertical += gc.BulletSpeed;
                        Point point = new Point(this.bull1.Horizontal, this.bull1.Vertical);
                        this.bullet1.Location = point;
                    }
                    else
                    {
                        this.bull1.Vertical = -100;
                        this.bull1.Horizontal = -100;
                        this.bull1.Direction = 0;
                        Point point = new Point(this.bull1.Horizontal, this.bull1.Vertical);
                        this.bullet1.Location = point;
                        this.tank1.CanFire = true;
                    }

                    break;
                case 3:
                    if (this.bull1.Horizontal >= 0)
                    {
                        this.bull1.Horizontal -= gc.BulletSpeed;
                        Point point = new Point(this.bull1.Horizontal, this.bull1.Vertical);
                        this.bullet1.Location = point;
                    }
                    else
                    {
                        this.bull1.Vertical = -100;
                        this.bull1.Horizontal = -100;
                        this.bull1.Direction = 0;
                        Point point = new Point(this.bull1.Horizontal, this.bull1.Vertical);
                        this.bullet1.Location = point;
                        this.tank1.CanFire = true;
                    }

                    break;
            }

            switch (this.bull2.Direction)
            {
                case 0:
                    if (this.bull2.Vertical >= 0)
                    {
                        this.bull2.Vertical -= gc.BulletSpeed;
                        Point point = new Point(this.bull2.Horizontal, this.bull2.Vertical);
                        this.bullet2.Location = point;
                    }
                    else
                    {
                        this.bull2.Vertical = -100;
                        this.bull2.Horizontal = -100;
                        this.bull2.Direction = 0;
                        Point point = new Point(this.bull2.Horizontal, this.bull2.Vertical);
                        this.bullet2.Location = point;
                        this.tank2.CanFire = true;
                    }
                    break;
                case 1:
                    if (this.bull2.Horizontal <= gc.GameWidth)
                    {
                        this.bull2.Horizontal += gc.BulletSpeed;
                        Point point = new Point(this.bull2.Horizontal, this.bull2.Vertical);
                        this.bullet2.Location = point;
                    }
                    else
                    {
                        this.bull2.Vertical = -100;
                        this.bull2.Horizontal = -100;
                        this.bull2.Direction = 0;
                        Point point = new Point(this.bull2.Horizontal, this.bull2.Vertical);
                        this.bullet2.Location = point;
                        this.tank2.CanFire = true;
                    }
                    break;
                case 2:
                    if (this.bull2.Vertical <= gc.GameHeight)
                    {
                        this.bull2.Vertical += gc.BulletSpeed;
                        Point point = new Point(this.bull2.Horizontal, this.bull2.Vertical);
                        this.bullet2.Location = point;
                    }
                    else
                    {
                        this.bull2.Vertical = -100;
                        this.bull2.Horizontal = -100;
                        this.bull2.Direction = 0;
                        Point point = new Point(this.bull2.Horizontal, this.bull2.Vertical);
                        this.bullet2.Location = point;
                        this.tank2.CanFire = true;
                    }
                    break;
                case 3:
                    if (this.bull2.Horizontal >= 0)
                    {
                        this.bull2.Horizontal -= gc.BulletSpeed;
                        Point point = new Point(this.bull2.Horizontal, this.bull2.Vertical);
                        this.bullet2.Location = point;
                    }
                    else
                    {
                        this.bull2.Vertical = -100;
                        this.bull2.Horizontal = -100;
                        this.bull2.Direction = 0;
                        Point point = new Point(this.bull2.Horizontal, this.bull2.Vertical);
                        this.bullet2.Location = point;
                        this.tank2.CanFire = true;
                    }
                    break;
            }

            Refresh();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            GameConstants gc = new GameConstants();

            switch (e.KeyData)
            {
                case Keys.W:    // Tank faces up
                    this.tank1.Direction = 0;
                    this.greentank.Image = this.greenimage0;
                    break;
                case Keys.D:    // Tank faces right
                    this.tank1.Direction = 1;
                    this.greentank.Image = this.greenimage1;
                    break;
                case Keys.S:    // Tank faces down
                    this.tank1.Direction = 2;
                    this.greentank.Image = this.greenimage2;
                    break;
                case Keys.A:    // Tank faces left
                    this.tank1.Direction = 3;
                    this.greentank.Image = this.greenimage3;
                    break;
                case Keys.F:    // Bullet appears
                    if (this.tank1.Direction == 0 && this.tank1.CanFire == true)
                    {
                        Point point1 = new Point(
                            this.tank1.Horizontal + (gc.BulletWidth / 2),
                            this.tank1.Vertical - gc.BulletHeight);
                        this.bullet1.Location = point1;
                        this.bull1.Vertical = this.tank1.Vertical - gc.BulletHeight;
                        this.bull1.Horizontal = this.tank1.Horizontal + (gc.BulletWidth / 2);
                        this.bull1.Direction = 0;
                        this.tank1.CanFire = false;
                    }
                    else if (this.tank1.Direction == 1 && this.tank1.CanFire == true)
                    {
                        Point point2 = new Point(this.tank1.Horizontal + gc.ImageWidth, this.tank1.Vertical
                            + (gc.BulletWidth / 2));
                        this.bullet1.Location = point2;
                        this.bull1.Vertical = (this.tank1.Vertical + (gc.BulletHeight / 2));
                        this.bull1.Horizontal = (this.tank1.Horizontal + gc.ImageWidth);
                        this.bull1.Direction = 1;
                        this.tank1.CanFire = false;
                    }
                    else if (this.tank1.Direction == 2 && this.tank1.CanFire == true)
                    {
                        Point point3 = new Point(
                            this.tank1.Horizontal + (gc.BulletWidth / 2),
                            this.tank1.Vertical + gc.ImageHeight);
                        this.bullet1.Location = point3;
                        this.bull1.Vertical = (this.tank1.Vertical + gc.ImageHeight);
                        this.bull1.Horizontal = (this.tank1.Horizontal + (gc.BulletWidth / 2));
                        this.bull1.Direction = 2;
                        this.tank1.CanFire = false;
                    }
                    else if (this.tank1.Direction == 3 && this.tank1.CanFire == true)
                    {
                        Point point4 = new Point(this.tank1.Horizontal - gc.BulletWidth,
                            this.tank1.Vertical + (gc.BulletWidth / 2));
                        this.bullet1.Location = point4;
                        this.bull1.Vertical = (this.tank1.Vertical + (gc.BulletWidth / 2));
                        this.bull1.Horizontal = (this.tank1.Horizontal - gc.BulletWidth);
                        this.bull1.Direction = 3;
                        this.tank1.CanFire = false;
                    }

                    break;
                case Keys.I:       // Tank faces up
                    this.tank2.Direction = 0;
                    this.redtank.Image = this.redimage0;
                    break;
                case Keys.L:    // Tank faces right
                    this.tank2.Direction = 1;
                    this.redtank.Image = this.redimage1;
                    break;
                case Keys.K:     // Tank faces down
                    this.tank2.Direction = 2;
                    this.redtank.Image = this.redimage2;
                    break;
                case Keys.J:     // Tank faces left
                    this.tank2.Direction = 3;
                    this.redtank.Image = this.redimage3;
                    break;
                case Keys.H:     // Bullet appears
                    if (this.tank2.Direction == 0 && this.tank2.CanFire == true)
                    {
                        Point point1 = new Point(
                            this.tank2.Horizontal + (gc.BulletWidth / 2),
                            this.tank2.Vertical - gc.BulletHeight);
                        this.bullet2.Location = point1;
                        this.bull2.Vertical = this.tank2.Vertical - gc.BulletHeight;
                        this.bull2.Horizontal = this.tank2.Horizontal + (gc.BulletWidth / 2);
                        this.bull2.Direction = 0;
                        this.tank2.CanFire = false;
                    }
                    else if (this.tank2.Direction == 1 && this.tank2.CanFire == true)
                    {
                        Point point2 = new Point(this.tank2.Horizontal + gc.ImageWidth, this.tank2.Vertical
                            + (gc.BulletHeight / 2));
                        this.bullet2.Location = point2;
                        this.bull2.Vertical = (this.tank2.Vertical + (gc.BulletHeight / 2));
                        this.bull2.Horizontal = (this.tank2.Horizontal + gc.ImageWidth);
                        this.bull2.Direction = 1;
                        this.tank2.CanFire = false;
                    }
                    else if (this.tank2.Direction == 2 && this.tank2.CanFire == true)
                    {
                        Point point3 = new Point(this.tank2.Horizontal + (gc.BulletWidth / 2),
                            this.tank2.Vertical + gc.ImageHeight);
                        this.bullet2.Location = point3;
                        this.bull2.Vertical = (this.tank2.Vertical + gc.ImageHeight);
                        this.bull2.Horizontal = (this.tank2.Horizontal + (gc.BulletWidth / 2));
                        this.bull2.Direction = 2;
                        this.tank2.CanFire = false;
                    }
                    else if (tank2.Direction == 3 && tank2.CanFire == true)
                    {
                        Point point4 = new Point(
                            this.tank2.Horizontal - gc.BulletWidth,
                            this.tank2.Vertical + (gc.BulletWidth / 2));
                        this.bullet2.Location = point4;
                        this.bull2.Vertical = (this.tank2.Vertical + (gc.BulletWidth / 2));
                        this.bull2.Horizontal = (this.tank2.Horizontal - gc.BulletWidth);
                        this.bull2.Direction = 3;
                        this.tank2.CanFire = false;
                    }

                    break;
            }
        }
    }
}

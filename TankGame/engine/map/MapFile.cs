namespace TankGame
{
    using System;
    using System.Collections;
    using System.IO;

    using Exception;

    public class MapFile
    {
        private string mapFile;
        private ArrayList tanks = new ArrayList();
        private ArrayList walls = new ArrayList();
        
        public MapFile(string mapFile)
        {
            try
            {
                // TODO add cheking for that mapFile exist
                this.FileMap = mapFile;
            }
            catch (FileMapNotFound ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string FileMap {
            get
            {
                return this.mapFile;
            }

            private set
            {
                if (!File.Exists(value))
                {
                    throw new FileMapNotFound("This mapFile missing!");
                }

                this.mapFile = value;
            }
        }

        public ArrayList Tanks
        {
            get { return tanks; }
        }

        public ArrayList Walls
        {
            get { return walls; }
        }

        public void LoadData()
        {
            try
            {
                StreamReader input = new StreamReader(this.mapFile);
                // Reads tank lines
                String s1 = input.ReadLine();
                String s2 = input.ReadLine();

                // Puts split strings into string array
                string[] split1 = s1.Split(',');
                string[] split2 = s2.Split(',');

                // Creates int arrays
                int[] int1 = new int[3];
                int[] int2 = new int[3];

                int num;

                // Changes split string into split ints
                for (int i = 0; i < split1.Length; i++)
                {
                    num = int.Parse(split1[i]);
                    int1[i] = num;
                }

                for (int i = 0; i < split2.Length; i++)
                {
                    num = int.Parse(split2[i]);
                    int2[i] = num;
                }

                // Creates tank objects
                Tank tank1 = new Tank(null, int1[2], int1[0], int1[1]);
                Tank tank2 = new Tank(null, int2[2], int2[0], int2[1]);

                // Puts tank objects into tank collection
                tanks.Add(tank1);
                tanks.Add(tank2);

                String c = String.Empty;
                while (c != null)
                {
                    c = input.ReadLine();
                    string[] split3 = c.Split(',');
                    int[] int3 = new int[2];

                    for (int i = 0; i < split3.Length; i++)
                    {
                        num = int.Parse(split3[i]);
                        int3[i] = num;
                    }
                    Wall wall = new Wall(int3[0], int3[1]);
                    walls.Add(wall);
                }

                // Closes mapFile
                input.Close();
            }
            catch(System.Exception e)  //TODO remove Exception
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

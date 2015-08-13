namespace TankGame
{
    using System;
    using System.Windows.Forms;

    public static class StartGame
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

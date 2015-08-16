namespace TankGame
{
    using System;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
            this.StartButton.Select();
        }
        
        private void DoneButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this.NamePlayerOne.Text, this.NamePlayerTwo.Text, this.MapFileName.Text);
            form2.ShowDialog();
            form2.Dispose();
        }
        
        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.NamePlayerOne.Text = null;
            this.NamePlayerTwo.Text = null;
            this.MapFileName.Text = null;
        }
    }
}

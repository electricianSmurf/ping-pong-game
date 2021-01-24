using System.Windows.Forms;
using System.Drawing;

namespace tennisGame
{
    class cRacket
    {
        public PictureBox pBox = new PictureBox();
        public bool isRacketMovingUp;
        public bool isRacketMovingDown;

        public cRacket(Image rImage, Point rLocation, Form myForm)
        {
            pBox.Size = new System.Drawing.Size(18, 130);
            pBox.Image = rImage;
            pBox.Location = rLocation;
            //pBox.SizeMode = PictureBoxSizeMode.AutoSize;
            myForm.Controls.Add(pBox);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace War
{
    public partial class GameWindow : Form
    {
        //Constructor
        public GameWindow()
        {
            InitializeComponent();
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game_FormClosed);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;
                return handleParam;
            }
        }

        //Functions

        //Resource from stackoverflow to rotate an image
        //http://stackoverflow.com/questions/2163829/how-do-i-rotate-a-picture-in-c-sharp
        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);
            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            //now rotate the image
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));
            //dispose of our Graphics object
            gfx.Dispose();
            //return the image
            return bmp;
        }

        //Event Handlers
        public void OnViewUpdated(object source, VesselsEventArgs e)
        {
            _Vessels = e.Vessels;
            vesselCounter = _Vessels.Count;
            _GamePanel.Invalidate();

        }
        private void _GamePanel_Paint(object sender, PaintEventArgs e)
        {
            Image image;
            Graphics graphics = _GamePanel.CreateGraphics();
            Pen pen = new Pen(System.Drawing.Color.Red, 2);

            //All vessels /*
            int currentVessel = 0;
            while (currentVessel < _Vessels.Count)
            {
                Vessel vessel = _Vessels[currentVessel];
                if (vessel.Life > 0)
                {
                    switch (vessel.Life)
                    {
                        case 2:
                            image = new Bitmap(global::War.Properties.Resources.barco2);
                            break;
                        case 1:
                            image = new Bitmap(global::War.Properties.Resources.barco1);
                            break;
                        default:
                            image = new Bitmap(global::War.Properties.Resources.barco3);
                            break;
                    }
                    Console.WriteLine("Barco: " + currentVessel + " Action: " + vessel.Action + " Grado: " + vessel.Grade + " Valor: " + vessel.Value);
                    image = RotateImage(image, vessel.Grade);
                    graphics.DrawImage(image, vessel.PosX, vessel.PosY);
                    int currentBullet = 0;
                    /*while (currentBullet < vessel.Bullets.Count)
                    {
                        Bullet bullet = vessel.Bullets[currentBullet];
                        float tempX = bullet.PosX;
                        float tempY = bullet.PosY;
                        for (int xCounter = 0; xCounter < image.Width / 2; xCounter++)
                        {
                            tempX += (float)Math.Cos(vessel.Grade);
                        }
                        for (int yCounter = 0; yCounter < image.Height / 2; yCounter++)
                        {
                            tempY -= (float)Math.Sin(vessel.Grade);
                        }
                        graphics.DrawRectangle(pen, tempX, tempY, 2, 2);
                        currentBullet++;
                    }*/
                }
                currentVessel++;
            }
        }
        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        List<Vessel> _Vessels;
        int vesselCounter;
    }
}
